using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakItAll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube, cube1, cube2, cube3, cube4;

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            cube.SetActive(false);
            cube1.SetActive(true);
            cube2.SetActive(true);
            cube3.SetActive(true);
            cube4.SetActive(true);
            cube1.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            cube2.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            cube3.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            cube4.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);

            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
    }

}
