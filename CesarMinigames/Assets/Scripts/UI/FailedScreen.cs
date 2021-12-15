using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedScreen : MonoBehaviour
{

    public float timeShowed = 0.0f;
    public float durationShowed = 2.0f;
    public GameObject crossIcon;

    void OnEnable()
    {
        LeanTween.scale(crossIcon, new Vector3(5f, 5f, 5f), 0.5f).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        timeShowed += Time.deltaTime;
        if (timeShowed > durationShowed)
        {
            timeShowed = 0.0f;
            this.gameObject.SetActive(false);
        }
    }
}
