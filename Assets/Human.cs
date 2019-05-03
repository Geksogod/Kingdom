using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    // Start is called before the first frame update

    public float life;
    public float armor;
    public float damage;
    public float capacity;
    public float maxCapacity;
    public float speed;
    public float startSpeed;
    private float maxSpeed;

    public bool readyForWork = false;
    public bool readyToMove = false;
    public bool relaxation = false;
    public Dictionary<string, float> inventory = new Dictionary<string, float>(5);
    public GameObject target;

    private WorkerWork Work;
    private WorkerFindResources Find;
    private workerMove Move;
    private bool isFull;
    public enum ProfesionList
    {
        Worker
    }
    public ProfesionList profesion;

    void Awake()
    {
        switch (profesion)
        {
            case ProfesionList.Worker:
                life = 60;
                armor = 5;
                damage = 10;
                capacity = 0;
                maxCapacity = 60;
                speed = 3;
                startSpeed = maxSpeed =speed;
                this.gameObject.GetComponent<NavMeshAgent>().speed = speed;
                isFull = false;
                this.gameObject.AddComponent<WorkerFindResources>();
                this.gameObject.AddComponent<workerMove>();
                this.gameObject.AddComponent<WorkerWork>();
                break;
        }
        Find = this.gameObject.GetComponent<WorkerFindResources>();
        Move = this.gameObject.GetComponent<workerMove>();
        Work = this.gameObject.GetComponent<WorkerWork>();
        RecalculationSpeed();
        Doing();
    }

    public void Doing()
    {
        if (!relaxation&&target == null && !readyToMove)
        {
            target = Find.FindResources("Wood");
            if (target != null)
                readyToMove = true;
            else
                readyToMove = false;
        }
        if (!relaxation&&!isFull&&readyForWork)
            Work.StartProduction(target.transform.GetChild(0).gameObject);
    }
    private void Update()
    {
        
        if (!relaxation&&readyToMove)
        {
             Move.MoveTo();
        }
        if (relaxation)
            Debug.Log("Worker relaxation");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(readyToMove)
            Move.OnTriggerEnter(other);
    }

    public void Filling(float newResources)
    {
        capacity -= newResources;
        if (capacity >= maxCapacity)
            isFull = true;
        foreach (KeyValuePair<string, float> keyValue in inventory)
        {
            Debug.Log(keyValue.Key + " - " + keyValue.Value);
        }
        RecalculationSpeed();
    }

    public void RecalculationSpeed()
    {
        if (!isFull)
        {
            speed = startSpeed;
            speed = speed * (1-(capacity/ startSpeed));
            if (speed > startSpeed)
                speed = startSpeed;
            else if (speed < 0.5f)
                speed = 0.5f;
        }
        this.gameObject.GetComponent<NavMeshAgent>().speed = speed;
            
    }
}


