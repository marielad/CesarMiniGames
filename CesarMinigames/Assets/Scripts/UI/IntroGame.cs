using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IntroGame : MonoBehaviour
{
    public static IntroGame instance;
    public GameObject leftText, rightText, downText;
    private Vector2 leftEndPos = new Vector2(0f, 0f);
    private Vector2 rightEndPos = new Vector2(0f, 0f);
    private Vector2 downEndPos = new Vector2(0f, 0f);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            AnimateScreen();
        }
        else
        {
            Destroy(this);
        }
    }
    public void AnimateScreen()
    {
        gameObject.SetActive(true);
        /*leftEndPos = leftText.transform.position;
        leftText.transform.position = new Vector3(-1200f, leftEndPos.y, 0.0f);

        rightEndPos = rightText.transform.position;
        rightText.transform.position = new Vector3(1300f, rightEndPos.y, 0.0f);


        downEndPos = downText.transform.position;
        downText.transform.position = downEndPos - new Vector2(0, 200f);

        LeanTween.move(leftText, leftEndPos, 0.75f).setEaseOutBounce().setOnComplete(LeftTextOnComplete);
        LeanTween.move(rightText, rightEndPos, 0.75f).setEaseOutBounce().setOnComplete(RightTextOnComplete);
        LeanTween.move(downText, downEndPos, 0.75f).setEaseOutBounce().setOnComplete(DownTextOnComplete); ;*/
    }
    
    /*
    void LeftTextOnComplete()
    {
        leftEndPos -= new Vector2(50f, 0);
        LeanTween.move(leftText, leftEndPos, 0.75f).setLoopPingPong();
    }

    void RightTextOnComplete()
    {
        rightEndPos += new Vector2(50f, 0);
        LeanTween.move(rightText, rightEndPos, 0.75f).setLoopPingPong();
    }

    void DownTextOnComplete()
    {
        downEndPos += new Vector2(0f, -50f);
        LeanTween.move(downText, downEndPos, 0.75f).setLoopPingPong();
    }
    */

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            GameController.instance.LoadMiniGame();
            gameObject.SetActive(false);
        }
    }
    
}
