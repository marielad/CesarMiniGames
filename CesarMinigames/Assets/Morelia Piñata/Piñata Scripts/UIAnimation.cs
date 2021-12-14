using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        transform.localScale = Vector2.zero;
    }


    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.8f);

    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
