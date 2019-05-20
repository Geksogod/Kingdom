using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    public float health;
    public float speed;
    protected float maxSpeed;
    public float damage;
    public GameObject target;
    public GameObject newTarget;
    public bool ready;
    public float timeToKd;
    private float timer;

    void Start()
    {
        this.gameObject.GetComponent<NavMeshAgent>().speed = speed;
        timer = timeToKd;
    }

    void Update()
    {
        
    }


    public GameObject ChooseTarget(Target.Type targetType)
    {
        float nearstDist = float.MaxValue;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag(targetType.ToString()).Length; i++)
        {
            if(Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectsWithTag(targetType.ToString())[i].transform.position) < nearstDist)
            {
                nearstDist = Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectsWithTag(targetType.ToString())[i].transform.position);
                newTarget = GameObject.FindGameObjectsWithTag(targetType.ToString())[i];
            }
        }
        return newTarget;
    }

    public GameObject ChooseTarget(string targetType)
    {
        float nearstDist = float.MaxValue;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag(targetType.ToString()).Length; i++)
        {
            if (Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectsWithTag(targetType.ToString())[i].transform.position) < nearstDist)
            {
                nearstDist = Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectsWithTag(targetType.ToString())[i].transform.position);
                newTarget = GameObject.FindGameObjectsWithTag(targetType.ToString())[i];
            }
        }
        return newTarget;
    }

        public void Move(GameObject target)
    {
        this.gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
    }

    public void KD()
    {
        if (!ready)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ready = true;
                timer = timeToKd;
            }
        }
    }
}
