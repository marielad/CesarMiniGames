using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MilkErrorDetector : MonoBehaviour
{
    public float speed = 5f;
    public Transform targetLimitError;

    public MilkController scriptMilkController;

    public TextMeshProUGUI pointsMilkText;
    public float pointsMilk;
    public float inicialMilk = 300f;

    void Update()
    {
        pointsMilkText.text = inicialMilk.ToString("0000");

        if (scriptMilkController.MilkOn == true)
        {
            SubirDetectando();
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
            StartCoroutine(GameController.instance.FailMiniGame());
            Debug.Log("¡HAS PASADO DEL LIMITE! ¡ERROOOOOOOOOOOOOOOOR!");
        }
        
        if (other.gameObject.CompareTag("MilkLimitEnough") && !other.gameObject.CompareTag("MilkLimitError"))
        {
                StartCoroutine(GameController.instance.MiniGameSuceeded());
                Debug.Log("¡HAS GANADO!");
        }

        if (other.gameObject.CompareTag("SpawnMilk"))
        {
            inicialMilk += 50;
            Debug.LogWarning("SPAWWWWWWWWWWWN");
        }
    }
}
