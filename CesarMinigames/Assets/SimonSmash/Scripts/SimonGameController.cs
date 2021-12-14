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

    [Header("Times")]
    public float m_TimeToReact = 1f;

    private bool m_GameLoop;
    private bool m_GameOver;

    private int m_RandomBulb;

    private int m_PreviousColor;
    private int m_IndexRandomColor;


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

    /*void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && m_GameLoop == true)
        {
            CheckHit();
        }
    }*/

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

            yield return new WaitForSeconds(m_TimeToReact);

            if (m_LightBulbs[m_RandomBulb] != null && m_GameOver != true) //Si la luz que deberia ocupar ese puesto en la lista "existe" (no ha sido destruida ya por el GoodHit), y si tampoco es el final de partida
            {
                m_LightBulbs[m_RandomBulb].intensity = 0;
                yield return new WaitForSeconds(0.1f);
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

        yield return new WaitForSeconds(1.5f);

        m_PrincipalLight.color = RandomColor();

        m_PrincipalLight.intensity = m_LightIntensity;

        yield return new WaitForSeconds(2f);

        m_GameLoop = true;

        StartCoroutine(LoopOfLights());
    }


    public void CheckHit()
    {

        if (m_PrincipalLight.color == m_LightBulbs[m_RandomBulb].color)
        {
            GoodHit();
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }



    public void GoodHit()
    {
        m_GameLoop = false;

        m_LightBulbs[m_RandomBulb].intensity = 0f;
        m_LightBulbs[m_RandomBulb].gameObject.SetActive(false);
        m_LightBulbs.RemoveAt(m_RandomBulb);

        m_BulbsObj[m_RandomBulb].SetActive(false);
        m_BulbsObj.RemoveAt(m_RandomBulb);

        m_BulbsBrokenObj[m_RandomBulb].SetActive(true);
        m_BulbsBrokenObj.RemoveAt(m_RandomBulb);



        StartCoroutine(CheckVictory());
    }



    public IEnumerator GameOver()
    {
        m_GameLoop = false;
        m_GameOver = true;

        m_PrincipalLight.intensity = 0f;

        m_PrincipalBulbObj.SetActive(false);
        m_PrincipalBulbBrokenObj.SetActive(true);

        Debug.Log("GameOver");

        yield return new WaitForSeconds(3f);

        m_LightBulbs[m_RandomBulb].intensity = 0f;

        yield return new WaitForSeconds(1f);

        //SceneManager.LoadScene(0);

    }

    public IEnumerator CheckVictory()
    {
        if (m_LightBulbs.Count == 0)
        {
            Debug.Log("You Win");

            yield return new WaitForSeconds(3f);

            StartCoroutine(GameController.instance.MiniGameSuceeded());
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
}
