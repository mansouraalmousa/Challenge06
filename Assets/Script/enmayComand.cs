using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
public class enmayComand : MonoBehaviour
{
    [SerializeField] Transform[] position;
    NavMeshAgent agent;
   // [SerializeField] float maX, maZ, miX, miZ;
    int index;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enmey;
    [SerializeField] AudioSource audioS;
float  Distance;
    /// <summary>
    //[SerializeField] Animator animator;
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        agent.SetDestination( position[0].position);
        

    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, Enmey.transform.position);
       
        if ( ! agent.pathPending &&agent.remainingDistance <= 0.2f )
        {
            Paht();
        }
       if (Distance <= 5f)
        {
            agent.SetDestination(Player.transform.position);
            audioS.Play();
        }
    }
    void Paht()
    {
       
        if (index != position.Length-1)
        {
            index = index + 1 % position.Length;
            float x = position[index].transform.position.x;
            float z = position[index].transform.position.x;
            Vector3 dis = new Vector3(x, transform.position.y, z);

            position[index].position = dis;
            agent.SetDestination(dis);
        }
            
    }
}
