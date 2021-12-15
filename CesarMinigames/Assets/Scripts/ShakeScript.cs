using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    [SerializeField] private Vector2 objectShake;

    public void ShakeObject()
    {
        LeanTween.moveLocalX(this.gameObject, objectShake.x, 0.05f).setLoopPingPong();
        LeanTween.moveLocalY(this.gameObject, objectShake.y, 0.05f).setLoopPingPong();
    }
}
