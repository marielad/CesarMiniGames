using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManagerAgoney : MonoBehaviour
{

    public Sprite globoContento;
    public Sprite globoTriste;
    public Sprite infladorArriba;
    public Sprite infladorAbajo;

    public GameObject inflador_object;
    public GameObject globo_object;
    public GameObject gameManager;

    private Image globo;
    private Image inflador;

    private SoundManagerAgoney soundmanager;

    public void Awake()
    {
        soundmanager = FindObjectOfType<SoundManagerAgoney>();
    }
    void Start()
    {
        globo = globo_object.GetComponent<Image>();
        inflador = inflador_object.GetComponent<Image>();
        globo.sprite = globoTriste;
    }
    public void PressedButton(InputAction.CallbackContext callback)
    {
        if ((callback.performed && callback.duration != 0.0f) && GameController.instance.isPlaying)
        {
            soundmanager.SeleccionAudio(1, 5f);
            globo_object.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            globo_object.transform.position += new Vector3(0, 0.18f, 0);
            StartCoroutine("CambiarInflador");

            if (globo_object.transform.localScale.y >= 2.2f)
            {
                   globo.sprite = globoContento;
            }
        }
    }

    public void Update()
    {
        if (globo_object != null)
        {
            globo_object.transform.localScale -= new Vector3(0.0002f, 0.0002f, 0.0002f);
            globo_object.transform.position -= new Vector3(0, 0.00018f, 0);
        
        
            if (globo_object.transform.localScale.y < 2.2f)
            {
                globo.sprite = globoTriste;
            }

            if (globo_object.transform.localScale.y >= 4f)
            {
                StartCoroutine(GameController.instance.MiniGameSuceeded());
                soundmanager.SeleccionAudio(0, 5f);
                Destroy(globo_object);
            }
        }
    }
    IEnumerator CambiarInflador()
    {
        inflador.sprite = infladorAbajo;
        yield return new WaitForSeconds(0.2f);
        inflador.sprite = infladorArriba;
    }
}
