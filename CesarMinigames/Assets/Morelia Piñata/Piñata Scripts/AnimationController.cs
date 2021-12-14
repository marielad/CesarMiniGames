using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public static AnimationController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

   // Update is called once per frame
    public void PaloAnimation()
    {
        anim.Play("palo");
    }
}
