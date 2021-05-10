using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

     private Animator animator_bala;
     private Rigidbody2D Bala;
     float timer;
     public bool impacto = false;
     public bool direction = false;
     // Start is called before the first frame update



    private float speed = 4;
    private Vector2 Direction;
    private Rigidbody2D m_Rigidbody2D;
    void Start()
    {

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Bala = GetComponent<Rigidbody2D>();
        animator_bala = gameObject.GetComponent<Animator>();
        animator_bala.SetBool("impacto", false);


    }

    // Update is called once per frame
    void Update()
    {
   
        if(impacto == true)
        {
            Bala.velocity = new Vector2(0, 0);
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                
                Destroy(gameObject);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "ground")
        {

            animator_bala.SetBool("impacto", true);
            impacto = true;
            
        }
    }


    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity = Direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}
