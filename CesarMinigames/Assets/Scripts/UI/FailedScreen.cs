using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedScreen : MonoBehaviour
{

    public float timeShowed = 0.0f;
    public float durationShowed = 2.0f;
    public GameObject crossIcon;

    [SerializeField] private Vector2 _cameraShake;
    Vector3 _initialScale, _initialPos;


    private void Awake()
    {
        _initialScale = crossIcon.transform.localScale;
        _initialPos = crossIcon.transform.localPosition;
    }
    void OnEnable()
    {
        LeanTween.scale(crossIcon, new Vector3(5f, 5f, 5f), 0.5f).setLoopPingPong();
        LeanTween.moveLocalX(crossIcon, _cameraShake.x, 0.05f).setLoopPingPong();
        LeanTween.moveLocalY(crossIcon, _cameraShake.y, 0.05f).setLoopPingPong(); 
    }

    private void OnDisable()
    {
        LeanTween.cancel(crossIcon);
        crossIcon.transform.localScale = _initialScale;
        crossIcon.transform.localPosition = _initialPos;

    }

    void EndShake()
    {
        LeanTween.scale(crossIcon, _initialScale, 0.01f);
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
