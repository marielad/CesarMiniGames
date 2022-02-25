using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{   
    
    private Coroutine a;
    private Vector3 newPos;
    private bool isStopped;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 1.77f);
    }
    public IEnumerator CandyRotation()
    {
        Debug.Log("Checasdasdasdking: ");

        if (transform.position.y <= -1.8f)
        {
            transform.position = new Vector3(transform.position.x, 1.77f);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
        }

        yield return null;
        a = StartCoroutine(CandyRotation());
    }

    public void StopCandy() {
        isStopped = true;
        StopCoroutine(a);
        StopCoroutine(CandyRotation());
    }

    public string CorrectPosition()
    {
        string image = "";
        if (transform.position.y <= (-1.55f))
        {
            Debug.Log("1: "+ (transform.position.y <= (-1.55f)));
            newPos = new Vector3(transform.position.x, -1.8f, transform.position.z);
            image = "palo";
        }
        else if (transform.position.y > (-1.55f) && transform.position.y <= (-1.05))
        {
            Debug.Log("2: " + (transform.position.y > (-1.55f) && transform.position.y <= (-1.05)));
            image = "rueda";

            newPos = new Vector3(transform.position.x, -1.3f);
        }
        else if(transform.position.y > (-1.05) && transform.position.y <= (-0.55))
        {
            Debug.Log("3: " + (transform.position.y > (-1.05) && transform.position.y <= (-0.55)));
            image = "tubo";

            newPos = new Vector3(transform.position.x, -0.8f);
        }
        else if (transform.position.y > (-0.55) && transform.position.y <= (-0.05))
        {
            Debug.Log("4: " + (transform.position.y > (-0.55) && transform.position.y <= (-0.05)));
            image = "caramelo";

            newPos = new Vector3(transform.position.x, -0.3f);
        }
        else if (transform.position.y > (-0.05) && transform.position.y <= (0.45))
        {
            Debug.Log("5: " + (transform.position.y > (-0.05) && transform.position.y <= (0.45)));
            image = "judias";

            newPos = new Vector3(transform.position.x, 0.2f);
        }
        else if (transform.position.y > (0.45) && transform.position.y <= (0.95))
        {
            Debug.Log("6: " + (transform.position.y > (0.45) && transform.position.y <= (0.95)));
            image = "piruleta";

            newPos = new Vector3(transform.position.x, 0.7f);
        }
        else if (transform.position.y > (0.95) && transform.position.y <= (1.45))
        {
            Debug.Log("7: " + (transform.position.y > (0.95) && transform.position.y <= (1.45)));
            image = "huevo";

            newPos = new Vector3(transform.position.x, 1.2f);
        }
        else if (transform.position.y > (1.45))
        {
            Debug.Log("8: " + (transform.position.y > (1.45)));
            image = "palo";

            newPos = new Vector3(transform.position.x, 1.77f);
        }

        Debug.Log("9: " + transform.position.y.ToString());

        transform.position = new Vector3(newPos.x, newPos.y);

        Debug.Log("10: " + transform.position.y.ToString());

        return image;
    }

    public string CheckPosition() {
        string image = "";
        StartCoroutine(CorrectPosition());
        switch (transform.position.y)
        {
            case -1.8f:
                image = "palo";
                break;
            case -1.3f:
                image = "rueda";
                break;
            case -0.8f:
                image = "tubo";
                break;
            case -0.3f:
                image = "caramelo";
                break;
            case 0.2f:
                image = "judias";
                break;
            case 0.7f:
                image = "piruleta";
                break;
            case 1.2f:
                image = "huevo";
                break;
            case 1.77f:
                image = "palo";
                break;
            default:
                
                break;
        }
        return image;
    }

}
