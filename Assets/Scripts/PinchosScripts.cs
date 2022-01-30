using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosScripts : MonoBehaviour
{

PlayerOneMovement pm;
   private void Start(){
       pm =FindObjectOfType<PlayerOneMovement>();
   }

    private void OnTriggerEnter2D(Collider2D collision){
    Debug.Log("TE HAS PINCHADO");
       // Destroy(collision.gameObject);
       if(collision.gameObject.CompareTag("Player")){
           pm.ResertPosition();
       }
    }
}
