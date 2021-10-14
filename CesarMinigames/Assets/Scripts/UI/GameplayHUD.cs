using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameplayHUD : MonoBehaviour
{
    public static GameplayHUD instance;
    public Slider timeSlider;
    public TextMeshProUGUI timeText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    public void UpdateRemaningTime(float remaingTime)
    {
        timeSlider.value = remaingTime;
        timeText.text = ((int)remaingTime + 1).ToString();
    }
}
