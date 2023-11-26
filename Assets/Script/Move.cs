using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movmentS;
    [SerializeField] Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      


    }
    void move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movmentS, rb.velocity.y, verticalInput * movmentS);
        bool dead = false;


        if (transform.position.y < -5f && !dead )
        {
            Gameover();
        }

        animator.SetFloat("horizontalWalking", horizontalInput);
        animator.SetFloat("verticalMovement", verticalInput);
    }

    // Update is called once per frame
    void Update()
    {
        move();
     
    }
    void Gameover()
    {
        SceneManager.LoadScene("Gameover");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pionts"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(4);
        }


    }
}
  
