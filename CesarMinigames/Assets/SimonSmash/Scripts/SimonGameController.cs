using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimonGameController : MonoBehaviour
{

    public Color[] m_colors;

    [Header("LightsBulbs")]
    public List<Light> m_LightBulbs = new List<Light>();

    public List<GameObject> m_BulbsObj = new List<GameObject>();
    public List<GameObject> m_BulbsBrokenObj = new List<GameObject>();

    public float m_LightIntensity = 2f;

    [Header("PrincipalLightBulb")]
    public Light m_PrincipalLight;

    public GameObject m_PrincipalBulbObj;
    public GameObject m_PrincipalBulbBrokenObj;

    [Header("OtherLights")]

    public Light m_GameOverLight;
    public float m_GameOverLightIntensity = 12f;

    public GameObject[] m_AmbientLights;

    [Header("Times")]
    public float m_TimeToReact = 1f;

    public float m_TimeToStart = 1.5f;
    public float m_TimeToGameOver = 3f;

    public float m_BrokenFlashTime = 0.02f;

    private bool m_GameLoop;
    private bool m_GameOver;

    private int m_RandomBulb;

    private int m_PreviousColor;
    private int m_IndexRandomColor;

    [Header("Sounds")]
    public SimonSoundsController m_SoundController;


    public void Start()
    {
        foreach (Light bulb in m_LightBulbs)
        {
            bulb.intensity = 0;
        }

        m_GameLoop = false;
        m_GameOver = false;

        m_IndexRandomColor = 0;

        StartCoroutine(StartGame());
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && m_GameLoop == true)
        {
            CheckHit();
        }*/

        if(m_GameOver == true)
        {
            m_GameOverLight.intensity = Random.Range(500f, 10000f) * Time.deltaTime;
        }
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed && m_GameLoop == true)
        {
            CheckHit();
        }
    }


    public IEnumerator LoopOfLights()
    {

        while (m_GameLoop)
        {
            SelectRandomBulb();
            m_LightBulbs[m_RandomBulb].color = RandomColor();
            m_LightBulbs[m_RandomBulb].intensity = m_LightIntensity;

            m_SoundController.PlayChangeBulb();

            yield return new WaitForSeconds(m_TimeToReact);

            if (m_LightBulbs[m_RandomBulb] != null && m_GameOver != true) //Si la luz que deberia ocupar ese puesto en la lista "existe" (no ha sido destruida ya por el GoodHit), y si tampoco es el final de partida
            {
                m_LightBulbs[m_RandomBulb].intensity = 0;
                yield return new WaitForSeconds(0.05f);
            }

        }
    }


    public void SelectRandomBulb()
    {
        m_RandomBulb = Random.Range(0, m_LightBulbs.Count);
    }



    public Color RandomColor()
    {

        //Selecciona un color random, y que no sea el mismo que el anterior para que siempre cambie
        int whatColor = Random.Range(0, m_colors.Length);

        while (whatColor == m_PreviousColor)
        {
            whatColor = Random.Range(0, m_colors.Length);
        }

        m_PreviousColor = whatColor;



        Color bulbColor = m_colors[whatColor];



        //Comprueba si el color que ha salido es igual al de la bombilla, y si no lo es, va contando cuantas veces cambia de color sin ser el mismo que la bombilla principal
        if (bulbColor != m_PrincipalLight.color)
        {
            m_IndexRandomColor = m_IndexRandomColor + 1;
        }
        else
        {
            m_IndexRandomColor = 0;
        }


        //Si el conteo de veces donde la bombilla no es del mismo color que la principal supera el numero de colores que hay, no se selecciona un color aleatorio sino que se selecciona el mismo color que la bombilla principal y se resetea el contador 
        if (m_IndexRandomColor > m_colors.Length)
        {
            bulbColor = m_PrincipalLight.color;
            m_IndexRandomColor = 0;
        }
        //Esto para que si la aleatoriedad no muestra el color que necesita el jugador (el de la bombilla principal) en un par de intentos, se le asegure si o si ese color para que no sea injusto y tenga oportunidad ganar antes de que finalice el tiempo

        return bulbColor;
    }

    public IEnumerator StartGame()
    {
        m_PrincipalLight.intensity = 0f;

        yield return new WaitForSeconds(m_TimeToStart);

        m_PrincipalLight.color = RandomColor();

        m_PrincipalLight.intensity = m_LightIntensity;

        m_SoundController.PlayBackground();

        TurnOffExternalLights();

        yield return new WaitForSeconds(m_TimeToStart + 0.5f);

        m_GameLoop = true;

        StartCoroutine(LoopOfLights());
    }


    public void CheckHit()
    {

        if (m_PrincipalLight.color == m_LightBulbs[m_RandomBulb].color)
        {
            StartCoroutine(GoodHit());
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }



    public IEnumerator GoodHit()
    {
        m_GameLoop = false;

        m_BulbsObj[m_RandomBulb].SetActive(false);
        m_BulbsObj.RemoveAt(m_RandomBulb);

        m_BulbsBrokenObj[m_RandomBulb].SetActive(true);
        m_BulbsBrokenObj.RemoveAt(m_RandomBulb);

        m_LightBulbs[m_RandomBulb].color = Color.white;
        m_LightBulbs[m_RandomBulb].intensity = m_LightIntensity * 5f;

        m_SoundController.PlayRandomExplosion(Random.Range(-3, 4));

        yield return new WaitForSeconds(m_BrokenFlashTime);

        m_LightBulbs[m_RandomBulb].intensity = 0f;
        m_LightBulbs[m_RandomBulb].gameObject.SetActive(false);
        m_LightBulbs.RemoveAt(m_RandomBulb);


        StartCoroutine(CheckVictory());
    }



    public IEnumerator GameOver()
    {
        m_GameLoop = false;
        m_GameOver = true;

        m_PrincipalLight.color = Color.white;
        m_PrincipalLight.intensity = m_LightIntensity * 5f;

        m_SoundController.PlayRandomExplosion(Random.Range(-3, 4));
        m_SoundController.PlayGameOver();

        yield return new WaitForSeconds(m_BrokenFlashTime);

        m_PrincipalBulbObj.SetActive(false);
        m_PrincipalBulbBrokenObj.SetActive(true);

        m_PrincipalLight.intensity = 0f;

        //Por si en el loopLights ya se ha apagado esa bombilla, que a veces pasa
        if(m_LightBulbs[m_RandomBulb].intensity == 0f)
        {
            m_LightBulbs[m_RandomBulb].intensity = m_LightIntensity;
        }


        Debug.Log("GameOver");

        yield return new WaitForSeconds(m_TimeToGameOver);

        m_LightBulbs[m_RandomBulb].intensity = 0f;


        TurnOnExternalLights();


        yield return new WaitForSeconds(m_TimeToGameOver);

        //SceneManager.LoadScene(0);   Cuando pierdes partida

    }

    public IEnumerator CheckVictory()
    {
        if (m_LightBulbs.Count == 0)
        {
            Debug.Log("You Win");

            TurnOnExternalLights();

            yield return new WaitForSeconds(m_TimeToGameOver);

            //StartCoroutine(GameController.instance.MiniGameSuceeded()); Cuando ganes partida
        }
        else
        {
            m_PrincipalLight.intensity = 0f;

            yield return new WaitForSeconds(0.5f);

            m_PrincipalLight.color = RandomColor();
            m_PrincipalLight.intensity = m_LightIntensity;

            yield return new WaitForSeconds(m_TimeToReact);

            m_GameLoop = true;
            StartCoroutine(LoopOfLights());
        }
    }


    public void TurnOffExternalLights()
    {
        foreach (GameObject light in m_AmbientLights)
        {
            light.SetActive(false);
        }
    }

    public void TurnOnExternalLights()
    {
        foreach (GameObject light in m_AmbientLights)
        {
            light.SetActive(true);
        }
    }

}
