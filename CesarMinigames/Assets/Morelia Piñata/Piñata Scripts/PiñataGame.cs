using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PiñataGame : MonoBehaviour
{
    public float timer;
    public bool startTimer = false;
    public float stopTime;
    public float timerpaEmpezar = 5f;
    public int numPiñata;
    public int numPiñataDestruida;
    public int numPulsaciones;
    public int numPulsacionesNecesarias;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pinatasDestroyedText;
    public TextMeshProUGUI pinatasLeftText;
    public TextMeshProUGUI cuentaPaEmpezar;

    public Sprite burro, burroRoto, estrella, estrellaRota, pinata, pinataRota;
    public Sprite[] pinataList;
    public Image pinataImage;
    public GameObject gameOverScreen;
    public GameObject winnerWindow; 
    public GameObject loserWindow;
    public GameObject paEmpezar;


    // Start is called before the first frame update
    void Start()
    {
        pinataImage.GetComponent<Image>();
        pinataImage.sprite = pinataList[Random.Range(0, 2)];

        numPulsacionesNecesarias = Random.Range(10, 20);


        pinatasLeftText.text = numPiñata.ToString();
        pinatasDestroyedText.text = numPiñataDestruida.ToString();

        StartCoroutine(StartTimer());
    }

    void Update()
    {
        timerpaEmpezar -= Time.deltaTime; 
        cuentaPaEmpezar.text = "Empezamos en " + timerpaEmpezar.ToString("f0");
        if (startTimer == true)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("f0") + " s";
        }

        if (timer >= stopTime)
        {
            startTimer = false;
            gameOverScreen.SetActive(true);
            loserWindow.SetActive(true);
        }

        else if (numPiñataDestruida >= numPiñata)
        {
            startTimer = false;
            gameOverScreen.SetActive(true);
            winnerWindow.SetActive(true);
        }

    }
    public void RomperPiñata()
    {


        if (pinataImage.sprite == burro)
        {
            pinataImage.sprite = burroRoto;
        }

        else if (pinataImage.sprite == estrella)
        {
            pinataImage.sprite = estrellaRota;
        }
        else if (pinataImage.sprite == pinata)
        {
            pinataImage.sprite = pinataRota;
        }
    }
    public void OnButton(InputValue input)
    {
        AnimationController.instance.PaloAnimation();
        numPulsaciones++;
        if (numPulsaciones >= numPulsacionesNecesarias)
        {
            numPulsacionesNecesarias = Random.Range(10, 20);
            RomperPiñata();
            numPulsaciones = 0;
            numPiñataDestruida++;
            pinatasDestroyedText.text = numPiñataDestruida.ToString() + " /";
            StartCoroutine(ChangePiñata());
        }
    }

    public IEnumerator ChangePiñata()
    {
        yield return new WaitForSeconds(1f);
        pinataImage.sprite = pinataList[Random.Range(0, 2)];

    }

    public IEnumerator StartTimer()
    {
       
        yield return new WaitForSeconds(5f);
        startTimer = true;
        cuentaPaEmpezar.text = " ";
        paEmpezar.SetActive(false);
    }

}
