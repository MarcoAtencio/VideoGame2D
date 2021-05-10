using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject container;
    public GameObject PlayerController;
   


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Jojo")
        {

            playerControler.PlayerControler.lifeUpdate(-1);
            scoreManager.ScoreManager.RaiseScore(1);
            Destroy(gameObject);

        }
    }



}
