using UnityEngine;

public class Human : MonoBehaviour
{
    // Start is called before the first frame update

    public float life;
    public float armor;
    public float damage;
    public float capacity;
    public float speed;

    public bool readyForWork = false;
    public bool readyToMove = false;
    public bool relaxation = false;

    public GameObject target;

    private WorkerWork Work;
    private WorkerFindResources Find;
    private workerMove Move;
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
                capacity = 70;
                speed = 40;
                this.gameObject.AddComponent<WorkerFindResources>();
                this.gameObject.AddComponent<workerMove>();
                this.gameObject.AddComponent<WorkerWork>();
                break;
        }
        Find = this.gameObject.GetComponent<WorkerFindResources>();
        Move = this.gameObject.GetComponent<workerMove>();
        Work = this.gameObject.GetComponent<WorkerWork>();
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
        if (!relaxation&&readyForWork)
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

}


