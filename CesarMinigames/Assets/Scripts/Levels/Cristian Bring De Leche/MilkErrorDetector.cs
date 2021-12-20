using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MilkErrorDetector : MonoBehaviour
{
    public float speed = 5f;
    public Transform targetLimitError;
    public Transform targetLimitEnough;

    public MilkController scriptMilkController;

    public TextMeshProUGUI pointsMilkText;
    public float pointsMilk;
    public float inicialMilk = 300f;
    public float moreCountMilk = 50f;

    public bool victory;

    public void Start()
    {
        victory = false;
    }
    void Update()
    {
        pointsMilkText.text = inicialMilk.ToString("0000");

        if (scriptMilkController.MilkOn == true)
        {
            SubirDetectando();
        }

        if(victory == false && scriptMilkController.timerMilk <= 0f)
        {
            scriptMilkController.timerMilk = 15f;
            StartCoroutine(PerderPorNoLlegar());
        }
    }
    public void SubirDetectando()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetLimitError.position, step);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MilkLimitError"))
        {
            victory = false;
            Debug.Log("Victory = false");
            StartCoroutine(GameController.instance.FailMiniGame());
            Debug.Log("¡HAS PASADO DEL LIMITE! ¡ERROOOOOOOOOOOOOOOOR!");
        }
        
        if (other.gameObject.CompareTag("MilkLimitEnough"))
        {
            victory = true;
            Debug.Log("Victory = true");
            StartCoroutine(GameController.instance.MiniGameSuceeded());
            Debug.Log("¡SI PARAS, HAS GANADO!");
        }

        if (other.gameObject.CompareTag("SpawnMilk"))
        {
            inicialMilk += moreCountMilk;
            Debug.LogWarning("SPAWWWWWWWWWWWN");
        }
    }

    IEnumerator PerderPorNoLlegar()
    {
        StartCoroutine(GameController.instance.FailMiniGame());
        yield return new WaitForSeconds(3);
        Debug.Log("¡HAS PASADO DEL LIMITE! ¡ERROOOOOOOOOOOOOOOOR!");
    }
}
