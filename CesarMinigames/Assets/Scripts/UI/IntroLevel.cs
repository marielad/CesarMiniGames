using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroLevel : MonoBehaviour
{
    public static IntroLevel instance;
    public GameObject leftGameObject, rightGameObject, textGameObject, currentLvelGameObject;
    private Animator anim;
    public float timeAnimation = 3.0f;
    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
            DontDestroyOnLoad(this.gameObject);


            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }


    public IEnumerator AnimateScreen(string title, int level)
    {
        textGameObject.GetComponent<TextMeshProUGUI>().text = title;

        gameObject.SetActive(true);
        LeanTween.scale(currentLvelGameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.75f);
        yield return new WaitForSeconds(0.5f);
        UpdateLevelText(level);

        anim.SetTrigger("OpenStage");
        
    }
    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
        LeanTween.scale(currentLvelGameObject, Vector3.one, 1f);
    }


    public void AnimateScreen()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("OpenStage");

    }

    public void AnimationFinished()
    {
        Debug.Log("Finish animation");
        gameObject.SetActive(false);
        GameController.instance.StartMiniGame();


    }
}
