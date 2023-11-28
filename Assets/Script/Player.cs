using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 1.9f;
    public float playerSprint = 4f;

    [Header("Player Camera")]
    public Transform playerCamera;

    [Header("Player Animator and Gravity")]
    public CharacterController characterCon;
    public float gravity = -9.81f;
    public Animator animator;

    [Header("Player Jumping and velocity")]
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;
    public float jumpRange = 1f;
    Vector3 velocity;
   
   


    private void Update()
    {
      
        


        velocity.y += gravity * Time.deltaTime;
        characterCon.Move(velocity * Time.deltaTime);

        playerMove();
       
    }

    void playerMove()
    {
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");
        bool dead = false;

        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;

        if(direction.magnitude >= 0.1f)
        {
            


            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnCalmVelocity, turnCalmTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            characterCon.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
            
        }
        if (transform.position.y < -5f && !dead)
        {
            Gameover();
        }

        animator.SetFloat("horizontalWalking", horizontal_axis);
        animator.SetFloat("verticalMovement", vertical_axis);

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
  


    
 