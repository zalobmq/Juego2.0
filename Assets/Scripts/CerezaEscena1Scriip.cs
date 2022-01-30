
using UnityEngine;

public class CerezaEscena1Scriip : MonoBehaviour
{
    PlayerOneMovement pm;
   private void Start(){
       pm =FindObjectOfType<PlayerOneMovement>();
   }

    private void OnTriggerEnter2D(Collider2D collision){
   
    Debug.Log("CEREZA COGIDA");
      if(collision.gameObject.CompareTag("Player")){
           pm.CambiarEscena2();
       }
    }
}
