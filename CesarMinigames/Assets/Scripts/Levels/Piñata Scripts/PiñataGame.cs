using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PiñataGame : MonoBehaviour
{
    public float timer;
    public float stopTime;
    public int numPiñata;
    public int numPiñataDestruida;
    public int numPulsaciones;
    public int numPulsacionesNecesarias;
    public TextMeshPro timerText;

    public SpriteRenderer sRenderer;
    public Sprite burro, burroRoto, estrella, estrellaRota, pinata, pinataRota;

    // Start is called before the first frame update
    void Start()
    {

        sRenderer = GetComponent<SpriteRenderer>();
        burro = Resources.Load<Sprite>("Burro");
        burroRoto = Resources.Load<Sprite>("BurroRoto");
        estrella = Resources.Load<Sprite>("Estrella");
        estrellaRota = Resources.Load<Sprite>("EstrellaRota");
        pinata = Resources.Load<Sprite>("Piñata");
        pinataRota = Resources.Load<Sprite>("PiñataTodaRota");
        /*
         if (dependiendo del nivel el stop time cambiara nivel 1)
         {
             stopTime = 10f;
             numPiñata = 5;
         }

         if(nivel 2 )
         {
             stopTime = 15f;
             numPiñata = 10;

         }

         If(nivel3)
         {
             stopTime = 20f;
             numPiñata = 15;
         }
         */
        numPulsacionesNecesarias = Random.Range(10, 20);
    }

    void Update()
    {
        stopTime -= Time.deltaTime;

     

     /*   if (Input.GetKeyDown(KeyCode.Space))
        {
            numPulsaciones++;

        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RomperPiñata();
        }   

        else if (timer <= stopTime)
        {
            TimerDone();
        }
    }
     
    public void RomperPiñata()
    {
        if(sRenderer.sprite == burro)
        {
            sRenderer.sprite = burroRoto;
        }

        else if (sRenderer.sprite == estrella)
        {
            sRenderer.sprite = estrellaRota;
        }
        else if (sRenderer.sprite == pinata)
        {
            sRenderer.sprite = pinataRota;
        }
        //change sprite and get down another piñata 

    }

    public void TimerDone()
    {
        //Gameover screen or whatever happens 
    }
}
