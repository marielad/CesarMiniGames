using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorio : MonoBehaviour
{
    public GameObject[] jugadores;
    
    public  List<float>position=new List<float>();
    
    void Start()
    {
        
        

        for (int i = 0; i < 4; i++)
        {
            int ramdom = Random.Range(0, position.Count);

            /*while (ramdom == pos1 || ramdom == pos2 || ramdom == pos3)
            {

                 ramdom = Random.Range(0, position.Length);
                 if(i==)
            }*/
            jugadores[i].transform.position = new Vector3(0, position[ramdom],0);

            position.RemoveAt(ramdom);



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
