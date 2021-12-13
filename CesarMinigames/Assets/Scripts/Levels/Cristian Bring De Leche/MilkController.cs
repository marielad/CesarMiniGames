using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MilkController : MonoBehaviour
{
    public float points;
    public TextMeshProUGUI textPoints;
    public float timer;
    public TextMeshProUGUI textTimer;

    public ParticleSystem particleLiquid;

    public GameObject cubeCollision;

    public Slider sliderLiquid;
    public float limitPoints;
    public GameObject limitLine;

    public Image temperatureImage; //Para hacer crecer la temperatura "temperatureImage.fillAmount.value...."

    void Start()
    {
        if (particleLiquid.isPlaying)
        {
            //  particleLiquid.Stop();
        }

        points = 0f;
        timer = 10f;

        limitPoints = Random.Range(25, 95);
        //limitLine.transform.localPosition.y = new Vector3(0, limitPoints, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (Input.GetKey(KeyCode.Space))
        {
            //particleLiquid.GetComponent<ParticleSystem>();
            //particleLiquid
            particleLiquid.Play();

            if (particleLiquid.isPlaying)
            {
                points += Time.deltaTime;
                sliderLiquid.value = points * 0.15f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            particleLiquid.Stop();

            //Recharge();
        }

        textPoints.text = points.ToString("0000");
        textTimer.text = timer.ToString("00");

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
    /* IEnumerator Recharge()
     {
         particleLiquid.Stop();
         yield return new WaitForSeconds(1);
     }*/
}
