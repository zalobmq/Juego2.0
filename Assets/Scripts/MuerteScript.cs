using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteScript : MonoBehaviour
{
   PlayerOneMovement pm;
   private void Start(){
       pm = GetComponent<PlayerOneMovement>();
   }
   private void OnCollisionEntre2D(Collider2D collision){
       if(collision.gameObject.CompareTag("Player")){
           pm.ResertPosition();
       }
   }
}
