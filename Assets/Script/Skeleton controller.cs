using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Skeletoncontroller : MonoBehaviour



{

    public Transform[] tragetPoint;
    public int currentPoint;

    public NavMeshAgent agent;

    public Animator Animator;

    public float waitAtPoint = 2f;
    private float waitCounter;


    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(tragetPoint[currentPoint].position);

        if (agent.remainingDistance <= .2f)
        {
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
                Animator.SetBool("Run", false);
            }
            else
            {
                currentPoint++;
                waitCounter = waitAtPoint;
                Animator.SetBool("Run", true);
            }

            if (currentPoint >= tragetPoint.Length)
            {
                currentPoint = 0;
            }
            agent.SetDestination(tragetPoint[currentPoint].position);
        }
    }
}
