using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMilkController : MonoBehaviour
{
    public float speed;
    public Transform target1;
    public Transform target2;

    public void IrLejos()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
        Debug.Log("¡La camara se va a mover lejos!");
    }
    
    public void IrCerca()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        Debug.Log("¡La camara se va a mover cerca!");
    }
}
