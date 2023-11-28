using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossF : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] Animator animator1;
    [SerializeField] GameObject Boss;
    // Start is called before the first frame update
    bool dead = true;
    // Update is called once per frame
    void Update()
    {
             
        if (Boss.IsDestroyed() && dead)
        {
            animator.SetBool("dead",true);
            animator1.SetBool("dead", true);
            dead = false;
        }
    }
}
