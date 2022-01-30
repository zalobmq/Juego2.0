
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //VARIABLES GLOBALES

    //PRIVATE
    private Rigidbody2D Rigidbody2D;
    private Animator  Animator;  
    private float Horizontal;
    private float LastShoot;
   private int Health = 5; //VIDA POR DEFECTO DEL Personaje, 2 disparos.
    private int vida;
    private Vector3 initPosition;

    //PUBLIC 
    public float FuerzaSalto;
    public float velocidad;
    public GameObject bulletPrefab;
    public GameObject bulletLaserPrefab;




    public bool Grounded;   //Si esta a true--> estamos en el suelo , si vale false--> no lo estamos.
    void Start()
    {
        //Asignarle el componente  al Rigidbody2D y al Animator
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        //Posicion inicial del PlayerOne para el respaun
        initPosition = this.transform.position;
        Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Si pulsa la:
          A:Obtenemos un -1 
          D:Obtenemos un 1 
          Si no pulsa nada obtenemos un 0
        */

        //MOVERNOS DE IZQUIERDA A DERECHA
        Horizontal = Input.GetAxisRaw("Horizontal") * velocidad;

        //PARA GIRAR EL PERSONAJE

        if(Horizontal < 0.0f){
            //Vamos hacia la izquierda      <---
            transform.localScale = new Vector3(-1 , 1.0f , 1.0f );

        }else if (Horizontal > 0.0f){
            //Vamos hacia la derecha      --->
            transform.localScale = new Vector3(1 , 1.0f , 1.0f );
        }
        // -------------------------------------------
        //-> PARA PONER EL VARIABLE RUNNING <-

        //1º parametro el nombre que le hayamos puesto , 2º parmetro el valor que tiene
        //Si Horizontal es diferente de 0 , vale true , si no vale false(no nos estamos moviendo).
        Animator.SetBool("running" , Horizontal != 0.0f);
        // -------------------------------------------

        //El rycast lanza un "rayo" bajo el muñeco que si choca con el sulo vale true si no vale false.
        //Para ver el resultado del rayo la siguente linea.
        Debug.DrawRay(transform.position , Vector3.down *0.1f , Color.red);
        if(Physics2D.Raycast(transform.position , Vector3.down, 0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }

        //SALTAR
            // --> Si presionamos la W y esta en el suelo, nuestro personaje saltaria.
        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Salto();
        }

        //DISPARO NORMAL
        if(Input.GetKeyDown(KeyCode.K) && Time.time > LastShoot +0.25f){
       
            ShootNormal();  
            LastShoot  = Time.time;
        }
        //DISPARO LASER
        if(Input.GetKeyDown(KeyCode.L) && Time.time > LastShoot +0.25f){
            ShootLaser(); 
            LastShoot  = Time.time; 
        }

    }

    //Obtener vida actual del personaje
    public int getVida(){
        vida = Health;
        return vida;
    }
    //RESTAR VIDA POR DISPARO
     public void Hit(){
        Health = Health - 1;
        if(Health == 0){
           ResertPosition(); 
        } 
    } 
    /*  
    public void resetearVida(){
        this.vidaIncial = 4;
    }
    */
    //Funicon Muerte y respaunt
        public void ResertPosition(){
            this.transform.position = initPosition;
            //Reinicia la vida a 5 
            Health = 5;
        }

    //Cambiar escena 2 
     public void CambiarEscena2 (){
        SceneManager.LoadScene("Scene2");
        
    }

    
    //Cambiar Final
     public void CambiarFinal (){
        SceneManager.LoadScene("Scene3");
    }

    //Funcion saltar.
    // -->  Añadiria una fuerda al verctor 2 que simula el personaje subiendo.
        private void Salto(){
            
            Rigidbody2D.AddForce(Vector2.up * FuerzaSalto);

        }
    //Disparo normal

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
         private void ShootLaser(){

            //Para saber si vamos hacia la derecha o la izquierda cogemos el parametro x de la rotacion.
            //Si vale -1 es izquierda si vale 1 es derecha.

            Vector3 direccionDisparo;
            if(transform.localScale.x == 1.0f){
                direccionDisparo = Vector3.right;
            }else {
                 direccionDisparo = Vector3.left;

            }
            //Instancia el prefab asignado, en nuestra posicion y sin rotacion.
           GameObject bulletLaser =  Instantiate(bulletLaserPrefab , transform.position + direccionDisparo * 0.1f , Quaternion.identity);
           bulletLaser.GetComponent<BulletScript>().setDireccion(direccionDisparo);
        }
    //Se ejecuta mas constante el que update.
    public void FixedUpdate(){
        /*
        - VECTOR2 --> Indica dos elementos la X y la Y del mundo
        - AL pulsar la A la variable Horizontal valdra -1 , e ira a la izquierda
        - AL pulsar la D la variable Horizontal valdra 1 , e ira a la derecha
        - Si no pulsa nada valdra 0 por lo que no se movera.
        */
        Rigidbody2D.velocity = new Vector2(Horizontal , Rigidbody2D.velocity.y);
    }
}
