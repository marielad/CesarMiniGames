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
    public bool isPlaying = false;
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

       // AudioController.instance.PlayBackgroundMusic();
    }

    void Update()
    {
        timerpaEmpezar -= Time.deltaTime;
        UIAnimation.instance.Open();
        cuentaPaEmpezar.text = "We start in " + timerpaEmpezar.ToString("f0");
        
        if (startTimer == true)
        {
            timerpaEmpezar = 0;    
            isPlaying = true;
            timer += Time.deltaTime;
            timerText.text = timer.ToString("f0") + " s";
            if (timer >= stopTime)
            {
              Loser();
            }
            else if (numPiñataDestruida >= numPiñata)
            {
                Winner();
            }
        }
    }

    public void Loser()
    {
        startTimer = false;
        isPlaying = false;
        UIAnimation.instance.Open();
        gameOverScreen.SetActive(true);
        loserWindow.SetActive(true);
        AudioController.instance.LostSound();
    }

    public void Winner()
    {
        startTimer = false;
        isPlaying = false;
        UIAnimation.instance.Open();
        gameOverScreen.SetActive(true);
        winnerWindow.SetActive(true);
        AudioController.instance.WinSound();
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
    public void OnJump(InputValue input)
    {
        Debug.Log("HAGO LA¿¿ALGO");
        if (isPlaying == true) 
        {
            AudioController.instance.SwooshSound();
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
        
    }

    public IEnumerator ChangePiñata()
    {
        yield return new WaitForSeconds(1f);
        pinataImage.sprite = pinataList[Random.Range(0, 2)];

    }

    public IEnumerator StartTimer()
    {
       
        yield return new WaitForSeconds(5f);
        AudioController.instance.PlayWhistle();
        startTimer = true;
        cuentaPaEmpezar.text = "0 ";
        UIAnimation.instance.Close();
         paEmpezar.SetActive(false);
    }

}
