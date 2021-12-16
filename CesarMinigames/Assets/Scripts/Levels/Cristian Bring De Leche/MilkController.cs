using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

using TMPro;

public class MilkController : MonoBehaviour
{
    public float pointsMilk;
    public TextMeshProUGUI pointsMilkText;
    public float timerMilk;
    //public TextMeshProUGUI timerMilkText;
    //private float timerMilkoriginal;
    public float milkSpeedIncrease = 0.15f;
    public float thermometerSpeedIncrease = 0.07f;
    public float totalMilkPoints;

    public ParticleSystem particleLiquid;

    public GameObject cubeCollision;

    //public Slider sliderLiquid;
    public Image milkImage;
    public float limitPoints;
    public GameObject limitLine;

    public Image temperatureImage; //Para hacer crecer la temperatura "temperatureImage.fillAmount"

    public CameraMilkController scriptCameraMilk;

    public bool MilkOn;
    public bool SobrecalentamientoOFF;

    public Transform cameraMilk;

    public Transform[] spawnsLimitMilkLine;

    public GameObject milkErrorDetector;
    public Transform targetMaxMilk;

    public GameObject luzMilkOn;
    public GameObject luzSobrecalentamiento;

    void Start()
    {
        MilkOn = false;
        SobrecalentamientoOFF = true;
        /*if (particleLiquid.isPlaying)
        {
            particleLiquid.Stop();
        }*/
        particleLiquid.Stop();

        pointsMilk = 0f;
        timerMilk = 15f;

        //limitPoints = Random.Range(25, 95);
        limitLine.transform.position = spawnsLimitMilkLine[Random.Range(0, spawnsLimitMilkLine.Length)].position;

        milkImage.fillAmount = 0.01f;
        temperatureImage.fillAmount = 0.01f;
        //limitLine.transform.localPosition.y = new Vector3(0, limitPoints, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        pointsMilkText.text = totalMilkPoints.ToString("0000");

        if (MilkOn == true) //Esto antes estaba en QuieroLeche()
        {
            scriptCameraMilk.IrLejos();
            pointsMilk += Time.deltaTime;
            milkImage.fillAmount = pointsMilk * 0.15f;
            luzMilkOn.SetActive(true);

            temperatureImage.fillAmount += thermometerSpeedIncrease * Time.deltaTime;
            MaxMilk();
        }
        else
        {
            if(SobrecalentamientoOFF == true)
            {
                temperatureImage.fillAmount -= 0.1f * Time.deltaTime;
            }

            luzMilkOn.SetActive(false);
            scriptCameraMilk.IrCerca();
        }

        if (temperatureImage.fillAmount >= 1f)
        {
            StartCoroutine(Sobrecalentamiento());
        }
    }

    public void Timer()
    {
        timerMilk -= Time.deltaTime;
        //timerMilkText.text = timerMilk.ToString("00");

        if (timerMilk <= 0f)
        {
            Debug.Log("Se acabó");
        }
    }
    public void PressButton(InputAction.CallbackContext callback)
    {
        /*if (callback.started)
        {
            QuieroLeche();
            scriptCameraMilk.IrLejos();
        }
        else if(callback.performed)
        {
            StopLeche();
        }*/

        if(callback.performed && callback.duration > 0.1)
        {
            if(MilkOn == false && SobrecalentamientoOFF == true)
            { 
                QuieroLeche();
            }
            else if (MilkOn == true)
            {
                StopLeche();
            }

            Debug.Log("Tiempo presionado " + callback.duration);
        }

    }

    public void QuieroLeche()
    {
        MilkOn = true;
        particleLiquid.Play(); //Si las particulas funcionan, ocurre el Update() y este codigo
        //scriptCameraMilk.IrLejos();
    }

    public void StopLeche()
    {
        MilkOn = false;

        /*if(thermometerMOVE == true)
        {
            scriptCameraMilk.IrCerca();
        }*/
        particleLiquid.Stop(); //Si las particulas no funcionan, el Update() dejaria de tener utilidad y funciona este codigo
    }
    
    IEnumerator Sobrecalentamiento()
     {
        StopLeche();
        SobrecalentamientoOFF = false;
        cameraMilk.position = scriptCameraMilk.target1.position;
        luzSobrecalentamiento.SetActive(true);
        /*while(cameraMilk.position != scriptCameraMilk.target1.position)
        {
            yield return null;
        }*/
        scriptCameraMilk.speed = 0f;
        yield return new WaitForSeconds(3);
        SobrecalentamientoOFF = true;
        scriptCameraMilk.speed = scriptCameraMilk.saveSpeed;

        yield return new WaitForSeconds(2);
        luzSobrecalentamiento.SetActive(false);
     }

    public void MaxMilk()
    {
        float speed = 5f * Time.deltaTime;
        float step = speed * Time.deltaTime;
        milkErrorDetector.transform.position = Vector3.MoveTowards(milkErrorDetector.transform.position, targetMaxMilk.position, step);
        Debug.Log("¡La leche esta subiendo!");
    }
}
