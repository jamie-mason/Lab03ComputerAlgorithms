using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator m_Animator;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {
        agent.destination = Target.transform.position;
        m_Animator.speed = agent.velocity.magnitude;


    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Target")
        {
            m_Animator.SetTrigger("NormalAttack01_SwordShield");
        }
    }
}
