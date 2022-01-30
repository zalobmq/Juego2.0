using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    
    //PUBLIC
    public GameObject PlayerOne;

    //PRIVATE
    // Update is called once per frame
    void Update()
    {
       Vector3 posicion = transform.position;
       posicion.x = PlayerOne.transform.position.x; 
    }
}
