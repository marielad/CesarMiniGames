using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float timerFloat = 10;

    public TextMeshProUGUI timerText;

    public ShotScript script;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (script.stopClock == false)
        {
            timerFloat -= Time.deltaTime;
            timerText.text = timerFloat.ToString("00");
        }
        else
        {

        }
       
    }
}
