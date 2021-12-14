using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

using TMPro;

public class MilkController : MonoBehaviour
{
    public float points;
    public float timer;

    public ParticleSystem particleLiquid;

    public GameObject cubeCollision;

    //public Slider sliderLiquid;
    public Image milkImage;
    public float limitPoints;
    public GameObject limitLine;

    public Image temperatureImage; //Para hacer crecer la temperatura "temperatureImage.fillAmount"

    public CameraMilkController scriptCameraMilk;

    void Start()
    {
        if (particleLiquid.isPlaying)
        {
            //  particleLiquid.Stop();
        }

        points = 0f;
        timer = 10f;

        limitPoints = Random.Range(25, 95);

        milkImage.fillAmount = 0.01f;
        temperatureImage.fillAmount = 0.01f;
        //limitLine.transform.localPosition.y = new Vector3(0, limitPoints, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        /*if (Input.GetKey(KeyCode.Space))
        {
            //particleLiquid.GetComponent<ParticleSystem>();
            //particleLiquid
            particleLiquid.Play();

            if (particleLiquid.isPlaying)
            {
                points += Time.deltaTime;
                sliderLiquid.value = points * 0.15f;
            }
        }*/

        QuieroLeche();

        StopLeche();

        if (temperatureImage.fillAmount == 1f)
        {
            Sobrecalentamiento();
        }
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
            particleLiquid.Stop();

            //Recharge();
        }*/
    }

    public void Timer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Debug.Log("Se acabó");
            Time.timeScale = 0;
        }
    }
    public void PressButton(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            QuieroLeche();
        }
        else if(callback.performed)
        {
            StopLeche();
        }
    
    }


    public void QuieroLeche()
    {
        particleLiquid.Play();

        if (particleLiquid.isPlaying)
        {
            points += Time.deltaTime;
            milkImage.fillAmount = points * 0.15f;

            temperatureImage.fillAmount += 0.25f * Time.deltaTime;
        }

        scriptCameraMilk.IrLejos();
    }

    public void StopLeche()
    {
        scriptCameraMilk.IrCerca();
        particleLiquid.Stop();
        temperatureImage.fillAmount -= 0.5f * Time.deltaTime;
    }
    
    IEnumerator Sobrecalentamiento()
     {
         particleLiquid.Stop();
         yield return new WaitForSeconds(1);
     }
}
