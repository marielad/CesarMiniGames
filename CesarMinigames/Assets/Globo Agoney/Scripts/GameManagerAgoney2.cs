using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManagerAgoney2 : MonoBehaviour
{

    public Sprite globoContento2;
    public Sprite globoTriste2;
    public Sprite infladorArriba2;
    public Sprite infladorAbajo2;

    public GameObject inflador_object2;
    public GameObject globo_object2;
    public GameObject gameManager2;
    public GameObject explosion2;

    private Image globo2;
    private Image inflador2;

    private SoundManagerAgoney soundmanager2;

    public void Awake()
    {
        soundmanager2 = FindObjectOfType<SoundManagerAgoney>();
    }
    void Start()
    {
        globo2 = globo_object2.GetComponent<Image>();
        inflador2 = inflador_object2.GetComponent<Image>();
        globo2.sprite = globoTriste2;
    }
    public void PressedButton(InputAction.CallbackContext callback)
    {
        if ((callback.performed && callback.duration != 0.0f) && GameController.instance.isPlaying)
        {
            soundmanager2.SeleccionAudio(1, 5f);
            globo_object2.transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
            globo_object2.transform.position += new Vector3(0, 0.5f, 0);
            StartCoroutine("CambiarInflador2");

            if (globo_object2.transform.localScale.y >= 2.2f)
            {
                globo2.sprite = globoContento2;
            }
        }
    }

    public void Update()
    {
        if (globo_object2 != null)
        {
            globo_object2.transform.localScale -= new Vector3(0.0002f, 0.0002f, 0.0002f);
            globo_object2.transform.position -= new Vector3(0, 0.00018f, 0);


            if (globo_object2.transform.localScale.y < 2.2f)
            {
                globo2.sprite = globoTriste2;
            }

            if (globo_object2.transform.localScale.y >= 4f)
            {
                StartCoroutine(GameController.instance.MiniGameSuceeded());
                soundmanager2.SeleccionAudio(0, 5f);
                explosion2.SetActive(true);
                Destroy(globo_object2);
            }
        }
    }
    IEnumerator CambiarInflador2()
    {
        inflador2.sprite = infladorAbajo2;
        yield return new WaitForSeconds(0.2f);
        inflador2.sprite = infladorArriba2;
    }
}

