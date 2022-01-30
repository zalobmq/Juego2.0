using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    // Start is called before the first frame update
   
   public void ReiniciarJuego(){

       SceneManager.LoadScene("SampleScene");
   }

   public void CerrarJuego(){

       Debug.Log("Cerrar JUEGO");
       Application.Quit();
       
   }
}
