
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject bulletPrefab;
    private int Health = 2; //VIDA POR DEFECTO DEL ENEMIGO, 2 disparos.
    private float LastShoot;

   
    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = PlayerOne.transform.position - transform.position;
        if(direccion.x >= 0.0f){
            transform.localScale = new Vector3 (1.0f , 1.0f , 1.0f);
        }else{
            transform.localScale = new Vector3 (-1.0f , 1.0f , 1.0f);
        }
        //Calcular la distancia ente el PlayerOne y el enemigo
        float distancia = Mathf.Abs(PlayerOne.transform.position.x - transform.position.x) ; //Paraque no de valores negativos.

        //Rango de disparo --> 1m
        if(distancia < 0.5f && Time.time > LastShoot  + 0.20f){
            ShootNormal();
            LastShoot = Time.time;
        }
        
    }
    private void ShootNormal(){

            //Para saber si vamos hacia la derecha o la izquierda cogemos el parametro x de la rotacion.
            //Si vale -1 es izquierda si vale 1 es derecha.

            Vector3 direccionDisparo;
            if(transform.localScale.x == 1.0f){
                direccionDisparo = Vector3.right;
            }else {
                 direccionDisparo = Vector3.left;

            }
            //Instancia el prefab asignado, en nuestra posicion y sin rotacion.
           GameObject bulletNormal =  Instantiate(bulletPrefab , transform.position + direccionDisparo * 0.1f , Quaternion.identity);
           bulletNormal.GetComponent<BulletScript>().setDireccion(direccionDisparo);
        }
    //RESTAR VIDA POR DISPARO
    public void Hit(){
        Health = Health - 1;
        if(Health == 0){
            Destroy(gameObject);
        } 
    }   
    
    
}
