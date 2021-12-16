using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rimAnimation : MonoBehaviour
{

    public Animation net;
    public ShotScript script;

    // Start is called before the first frame update
    void Start()
    {
        net = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
      if (script.startAnimation == true)
        {
            net.Play();
        }
    }
}
