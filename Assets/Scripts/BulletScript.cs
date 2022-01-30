
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public AudioClip sonido;
        private Rigidbody2D Rigidbody2D;
        public float velocidad;
        
        private Vector2 Direccion;

       


    // Start is called before the first frame update
    void Start()
    {
         Rigidbody2D = GetComponent<Rigidbody2D>();
         Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
         

    }

    // Update is called once per frame
    void Update()
    {
        //Realiza un dispara en la direccion asignada y con la velocidad dada.
        Rigidbody2D.velocity = Direccion * velocidad;
    }

    public void setDireccion(Vector2 direccion){
        Direccion = direccion;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }
    //Si la bala colisiona con la ranita, cuenta como un Hit y le resta 1 de vida.
    private void OnTriggerEnter2D(Collider2D collision){

        EnemigoScript SoldadoEspacial = collision.GetComponent<EnemigoScript>();
        if (SoldadoEspacial != null){
            SoldadoEspacial.Hit();
        }
        
    }
}
