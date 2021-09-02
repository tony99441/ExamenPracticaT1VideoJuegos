using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHatBoyController : MonoBehaviour
{
    public float velocityX;
    public float JumpForce; 
    
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Run = 0;
    private const int Jump = 1;
    private const int Slide = 2;
    private const int Idle =4;
    private const int Dead = 3;

   
    private const string Tag_Enemigo = "Enemigo";

    public bool EstadoMuerte = false;
    private int contadorSalto = 0;
    private int Parar = 0; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(5, rb.velocity.y);
        animator.SetInteger("Estado",0);

        if (Parar == 10)
        {
            velocityX = 0f;
            rb.velocity = new Vector2(0, rb.velocity.y);
            changeAnimation(Idle);
        }

        //&& Input.GetKey(KeyCode.RightArrow)
        if (Input.GetKey(KeyCode.X) )
        {
            rb.velocity = new Vector2(velocityX, 0); 
            changeAnimation(Slide);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Forma simple
            //rb.velocity = Vector2.up * 4; 
            rb.AddForce(Vector2.up*JumpForce, ForceMode2D.Impulse);
            changeAnimation(Jump);
            contadorSalto++;
            Parar++;
            if (contadorSalto == 1)
            {
                velocityX = velocityX + 1.5f;
                contadorSalto = 0; 
            }
           
            
        }

     




    }
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(Input.GetKey(KeyCode.X) && collision.gameObject.CompareTag(Tag_Enemigo )){
            Destroy(collision.gameObject);
            velocityX = velocityX + 1.5f;
        }else if (collision.gameObject.CompareTag(Tag_Enemigo))
        {
            changeAnimation(Dead);
            velocityX = 0; 
        }




    }
  

}
