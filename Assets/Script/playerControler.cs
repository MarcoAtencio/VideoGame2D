using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public static playerControler PlayerControler;
    bool canJump;
    Rigidbody2D m_Rigidbody2D;
    Animator m_Animator;
    SpriteRenderer m_SpriteRenderer;

    //public Image Barravida;

    //float vidaActual = 5;
    //float vidaMax = 5;
    float runSpeed = 3;
    float jumpSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerControler == null)
        {
            PlayerControler = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            m_Rigidbody2D.velocity = new Vector2(-runSpeed, m_Rigidbody2D.velocity.y);
            m_Animator.SetBool("Correr", true);
            m_SpriteRenderer.flipX = true;
        }

        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            m_Animator.SetBool("Correr", false);
        }
        if (Input.GetKey("right"))
        {
            m_Rigidbody2D.velocity = new Vector2(runSpeed, m_Rigidbody2D.velocity.y);
            m_Animator.SetBool("Correr", true);
            m_SpriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpSpeed);
            m_Animator.SetBool("Saltar", true);
        }


        /*
        if (Barravida == null)
        {
            Barravida = GameObject.Find("life").GetComponent<Image>();
            Barravida.fillAmount = vidaActual / vidaMax;

        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
            m_Animator.SetBool("Saltar", false);

        }
    }
}
