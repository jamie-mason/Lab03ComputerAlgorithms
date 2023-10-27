using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshEnemy : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    [SerializeField] private NavMeshAgent agent1;

    private bool destinationReached;
    private Animator m_Animator;
    private float speed;
    [SerializeField] Vector3 targetPosition;
    bool canLaunch;
    bool isLaunching;
    bool countdown;
   
    public bool gotTargetPosition;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        targetPosition = Target.transform.position;
        canLaunch = false;
        gotTargetPosition = true;
        countdown = false;
    }
    IEnumerator CountdownBetweenLaunch(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(seconds);
            counter--;
        }

    }
    IEnumerator CoundownBeforeLaunchDuration(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {

            yield return new WaitForSeconds(1);
            counter--;

        }
        Debug.Log("Run");
        countdown = true;


    }

    IEnumerator LaunchDuration(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(seconds);
            counter--;
        }
        gotTargetPosition = true;
    }
    void launch()
    {

    }
    void Update()
    {
    

        if (gotTargetPosition)
        {
            agent1.destination = targetPosition;
            if (agent1.gameObject.transform.position.x == targetPosition.x &&
                agent1.gameObject.transform.position.z == targetPosition.z)
            {
                countdown = true;
                gotTargetPosition = false;
            }
        }
        else
        {
            targetPosition = Target.transform.position;
            if (countdown)
            {
                StartCoroutine(LaunchDuration(2));
                agent.destination = agent1.gameObject.transform.position;
                agent.updatePosition = true;
                countdown = false;
            }



        }



        


    }








}

