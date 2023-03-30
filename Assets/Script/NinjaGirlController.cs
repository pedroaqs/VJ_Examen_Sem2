using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirlController : MonoBehaviour
{
    bool live = true;
    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator animator;
    // Estados del personaje
    const int DEAD = 100; 
    const int IDLE = 0; 
    const int RUN = 1;
    const int ATACK = 2; 
    const int SLIDE = 3; 
    const int THROW = 4; 
    
    const int vStop = 0;
    const int vRun = 10;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(live) {
            rb.velocity = new Vector2(vStop,rb.velocity.y);
            SetAnimacion(IDLE);

            
            if(Input.GetKey(KeyCode.RightArrow)) {
                Debug.Log("Correr derecha");
                sr.flipX = false ;
                rb.velocity = new Vector2(vRun,rb.velocity.y);
                SetAnimacion(RUN);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                sr.flipX = true;
                rb.velocity = new Vector2(-vRun,rb.velocity.y);
                SetAnimacion(RUN);
            }

            if(Input.GetKeyDown(KeyCode.L)) {
                Debug.Log("Correr golpear");
                SetAnimacion(ATACK);
            }

            if(Input.GetKey(KeyCode.E)) {
                Debug.Log("Correr throw");
                SetAnimacion(THROW);
            }

            if(Input.GetKey(KeyCode.D)) {
                sr.flipX = false;
                rb.velocity = new Vector2(vRun,rb.velocity.y);
                SetAnimacion(SLIDE);
            }
            if(Input.GetKey(KeyCode.A)) {
                sr.flipX = true;
                rb.velocity = new Vector2(-vRun,rb.velocity.y);
                SetAnimacion(SLIDE);
            }
            if(Input.GetKeyDown(KeyCode.F)) {
                SetAnimacion(DEAD);
                live = false;
            }
        }
        
    }

    void SetAnimacion(int animacion) {
        animator.SetInteger("Estado",animacion);
    }
}
