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
    public GameObject heartsContainer;
    public GameObject lifeIconPrefab;

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

    public void RemoveAllHearts()
    {
        while (heartsContainer.transform.childCount != 0)
        {
            Destroy(heartsContainer.transform.GetChild(0));
        }
    }

    public void RemoveOneHeart()
    {
        if (heartsContainer.transform.childCount != 0)
        {
            heartsContainer.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(heartsContainer.transform.GetChild(0).gameObject);
        }
    }

    public void InstantiateHearts(int amount)
    {
        for(int heartsCreated = 0; heartsCreated < amount; heartsCreated++)
        { 
            GameObject.Instantiate(lifeIconPrefab, heartsContainer.transform);
        }


    }
}
