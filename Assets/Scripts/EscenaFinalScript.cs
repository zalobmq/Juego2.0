
using UnityEngine;

public class EscenaFinalScript : MonoBehaviour
{
    PlayerOneMovement pm;
   private void Start(){
       pm =FindObjectOfType<PlayerOneMovement>();
   }

    private void OnTriggerEnter2D(Collider2D collision){
   
    Debug.Log("CEREZA 2  COGIDA");
      if(collision.gameObject.CompareTag("Player")){
           pm.CambiarFinal();
       }
    }
}
