using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float timerFloat = 20;

    public TextMeshProUGUI timerText;

    public ShotScript script;


    public bool starttimer = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartCounter");

    }

    // Update is called once per frame
    void Update()
    {
        if (starttimer == true)
        {
            //if (script.stopClock == false)
            //{
                timerFloat -= Time.deltaTime;
                timerText.text = timerFloat.ToString("00");
            //}
           /* else
            {

            }*/

        }
        
       
    }

    public IEnumerator StartCounter()
    {

        yield return new WaitForSeconds(2);

        starttimer = true;
    }
}
