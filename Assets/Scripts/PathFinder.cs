using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    LineRenderer lr;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        lr = this.GetComponent<LineRenderer>();
        lr.startWidth = lr.endWidth = 1.0f;
        lr.material.color= Color.red;
        lr.enabled = false ;
       
    }

    public void makePath()
    {
        lr.enabled= true ;
        StartCoroutine(makePathCoroutine());
    }

    void drawPath()
    {
        int length = agent.path.corners.Length;

        lr.positionCount = length;
        for(int i = 1; i < length; i++)
            lr.SetPosition(i, agent.path.corners[i]);
    }
    IEnumerator makePathCoroutine()
    {
        Debug.Log("Coroutine ���۵�!");
        agent.SetDestination(target.transform.position);
        lr.SetPosition(0, this.transform.position);

        while (Vector3.Distance(this.transform.position, target.transform.position) > 0.1f)
        {
            lr.SetPosition(0, this.transform.position);

            drawPath();

            yield return null;
        }

        lr.enabled = false;
    }
}


