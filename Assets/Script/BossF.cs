using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BossF : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] Animator animator1;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Player;
    [SerializeField] Animator animator3;
    float Distance;
    // Start is called before the first frame update
    bool dead = true;
    // Update is called once per frame
    void Update()
    {
      


        if (Boss.IsDestroyed() && dead)
        {
            animator.SetBool("dead",true);
            animator1.SetBool("dead", true);
           
        }
        else
        {
            bossM();
        }

    }

    void bossM()
    {
        Distance = Vector3.Distance(Player.transform.position, Boss.transform.position);
        if (Distance <= 2f)
        {
            animator3.SetBool("Player", true);
        }
    }
}
