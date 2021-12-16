using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMilkController : MonoBehaviour
{
    public float speed;
    public Transform target1;
    public Transform target2;
    public Quaternion target2Q;

    public float saveSpeed;

    private void Start()
    {
        saveSpeed = speed;
    }
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
        transform.rotation = target2.transform.localRotation;
        Debug.Log("¡La camara se va a mover cerca!");
    }
}
