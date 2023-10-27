using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private bool destinationReached;
    private Animator m_Animator;
    private float speed;
    Vector3 pos;
    private bool walk, attack;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        speed = agent.speed;
        walk = false;
        attack = false;
        pos = agent.gameObject.transform.position;

    }

    private void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float horizon = Input.GetAxis("Horizontal");
        
        if (!destinationReached)
        {
            //agent.destination = Target.transform.localPosition;
            
            
        }

        if (vert != 0 || horizon != 0)
        {
            agent.velocity = new Vector3(horizon * agent.speed, agent.velocity.y, vert * agent.speed);
            m_Animator.SetTrigger("Walk_SwordShield");
            m_Animator.SetBool("isWalking", true);
            pos = agent.gameObject.transform.position;
            agent.speed = speed;
            walk = true;
        }
        else
        {
            m_Animator.SetBool("isWalking", false);
            walk = false;
            agent.speed = 1;
            agent.gameObject.transform.position = pos;
            agent.velocity = Vector3.zero;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            m_Animator.SetBool("isAttacking", true);
            m_Animator.SetTrigger("NormalAttack01_SwordShield");
            attack = true;
        }
        else
        {
            m_Animator.SetBool("isAttacking", false);
            attack = false;
        }
        
        if (walk == false && attack == false)
        {
            m_Animator.SetTrigger("Idle_SwordShield");
        }


       

        



    }

}
