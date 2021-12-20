using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RespondeGameControllerDificil : MonoBehaviour
{
    //Texto que muestra las operaciones
    public TextMeshProUGUI operacion;

    //Variables operaciones n1 & n2
    // timer n3 si es 0 o 1 suma o resta(n1 + n2 / n1 - n2)
    private int n1, n2;
    private int n3;

    // n1 + n2 = resultado
    //n1 - n2 = resultado
    private int resultado;

    //Variables respuestas cuadr�cula
    public TextMeshProUGUI[] respuestas;
    private int respuesta;
    private bool lighon;

    //Timer cambio luces y GameObject Luz
    private float timer = 0.2f;
    public GameObject[] luces;
    private int nluz;


    //Timer al fallar y apagar luces
    private float timerfail = 3f;
    // Start is called before the first frame update
    void Start()
    {        
        lighon = true;
        nluz = 0;
        luces[nluz].SetActive(true);

        Operaciones();
    }

    void Update()
    {
        timer = timer - Time.deltaTime;
        timerfail = 3f;

        if (timer < 0f && lighon == true)
        {
            luces[nluz].SetActive(false);
            nluz = nluz + 1;
            if (nluz >= luces.Length)
            {
                nluz = 0;
            }
            luces[nluz].SetActive(true);
            timer = 0.2f;

        }
        //Al pulsar espacio se parar� el timer y la luz, indicando si acertaste o fallaste
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lighon = false;
            int nrespuesta;
            nrespuesta = int.Parse(respuestas[nluz].text);

            if (resultado == nrespuesta)
            {
                //Ganaste si respondiste correctamente y coincide la respuesta de la cuadr�cula con el resultado de la operaci�n
                Debug.Log("YOU WIN");

                luces[nluz].SetActive(false);
                lighon = false;
                nluz = 0;
                lighon = true;
                nluz = nluz + 1;

                if (nluz == luces.Length)
                {
                    nluz = 0;
                }
                luces[nluz].SetActive(true);
                timer = 1.3f;

                Operaciones();
            }
            else
            {
                //Fallaste, no acertaste correctamente
                Debug.Log("YOU LOST");                
            }



        }
    }

    public void Operaciones()
    {
        n1 = Random.Range(0, 9);
        n2 = Random.Range(0, 9);
        n3 = Random.Range(0, 2);

        //n1 y n2 son n�meros aleatorios para operar
        //Si n3 es 0 o 1, puede ser Suma o Resta
        if (n3 == 0)
        {
            operacion.text = n1.ToString() + "  +  " + n2.ToString();
            resultado = n1 + n2;
        }

        if (n3 == 1)
        {
            operacion.text = n1.ToString() + "  -  " + n2.ToString();
            resultado = n1 - n2;
        }

        while (resultado > 8 || resultado < 0)
        {
            Operaciones();

        }

    }
   
}