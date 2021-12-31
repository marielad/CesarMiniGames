using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class BombTimeController : MonoBehaviour
{
    public GameObject segundosBombGameObject;
    public TextMeshProUGUI segundosBombText;
    public float segundosBomb;
    public float realtimeBomb = 1f;

    public TextMeshProUGUI numAleatorioText;
    public float numAleatorio;
    public float offsetSegundosBomb = 0.49f;

    public bool BombON;
    public bool SegundosON;
    public bool lightGreenON;
    public bool secondBomb = false;

    public GameObject lightGreenBomb;
    public GameObject lightRedBomb;
    public GameObject lightRedBomb2;

    public int resultBomb;
    public int calculo;

    public GameObject titleText1;
    public GameObject titleText2;

    public GameObject particlesBomb;

    public AudioBomb scriptAudioBomb;
    void Start()
    {
        ResetBomb();

        calculo = ((int)(numAleatorio + offsetSegundosBomb));
    }


    void Update()
    {
        if(SegundosON == true)
        {
            segundosBomb += Time.deltaTime * realtimeBomb;

            scriptAudioBomb.BombActiveSound();
        }

        segundosBombText.text = segundosBomb.ToString("00");

        numAleatorioText.text = numAleatorio.ToString("00");

        if(segundosBomb >= 3.5f && BombON == true)
        {
            segundosBombGameObject.SetActive(false);
        }

        if(segundosBomb > (numAleatorio + offsetSegundosBomb))
        {
            if(segundosBombGameObject.activeInHierarchy == true)
            {
                Debug.Log("BOOOOOOOMB!! HAS PULSADO TARDE");
            }
        }

        if(lightGreenON == true)
        {
            lightGreenBomb.SetActive(true);
        }
    }

    public void PressButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            if (BombON == false)
            {
                NoActionBomb();
            }
            else if (BombON == true)
            {
                StopTimeBomb();
            }

            Debug.Log("Tiempo presionado " + callback.duration);
        }
    }

    public void StopTimeBomb()
    {
        SegundosON = false;
        resultBomb = (int)segundosBomb;
        segundosBombGameObject.SetActive(true);
        BombON = false;

        if (segundosBomb <= (calculo + 1) && segundosBomb >= (calculo - 1))
        {
            particlesBomb.SetActive(true);
            scriptAudioBomb.ChispasSound();
            Debug.Log("VICTORIA");
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
    }

    public void NoActionBomb()
    {
        if(secondBomb == false)
        {
            if(segundosBomb <= (calculo - 1) || segundosBomb >= (calculo + 1))
            {
                StartCoroutine(ReiniciarBomb());
            }
        }

        if(secondBomb == true)
        {
            if (segundosBomb <= (calculo - 1) || segundosBomb >= (calculo + 1))
            {
                Debug.Log("DERROTA");
                StartCoroutine(GameController.instance.FailMiniGame());
            }
        }
    }

    public void ResetBomb()
    {
        segundosBomb = 0f;
        numAleatorio = Random.Range(4, 10);
        BombON = true;
        SegundosON = true;
        lightRedBomb.SetActive(false);
        lightGreenON = false;
    }

    IEnumerator ReiniciarBomb()
    {
        lightRedBomb.SetActive(true);
        Debug.Log("Reiniciando");
        yield return new WaitForSeconds(2);
        ResetBomb();
        Debug.Log("Reiniciada");
        lightRedBomb2.SetActive(true);
        lightGreenBomb.SetActive(false);
        titleText1.SetActive(false);
        titleText2.SetActive(true);
        secondBomb = true;
    }
}
