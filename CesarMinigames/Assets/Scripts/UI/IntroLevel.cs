using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroLevel : MonoBehaviour
{
    public static IntroLevel instance;
    public GameObject leftGameObject, rightGameObject, textGameObject;
    private Animator anim;
    public float timeAnimation = 3.0f;
    private Vector2 leftInitialPos = new Vector2(-480f, 0f);
    private Vector2 rightInitialPos = new Vector2(480f, 0f);


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
            DontDestroyOnLoad(this.gameObject);
          //  leftInitialPos = leftGameObject.transform.position;
          //  rightInitialPos = rightGameObject.transform.position;

            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }

    public void AnimateScreen(string title)
    {
        gameObject.SetActive(true);
        anim.SetTrigger("OpenStage");
        textGameObject.GetComponent<TextMeshProUGUI>().text = title;
    }
    public void AnimateScreen()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("OpenStage");
    }

    public void AnimationFinished()
    {
        gameObject.SetActive(false);
        GameController.instance.StartMiniGame();


    }
}
