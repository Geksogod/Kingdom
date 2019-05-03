using UnityEngine;
using UnityEngine.AI;

public class workerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Human human;
    private bool flag = false;
    private bool go = false;
    NavMeshAgent agent;


    private void Start()
    {
        human = gameObject.GetComponent<Human>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    public void MoveTo()
    {
        if (!flag)
        {
            transform.LookAt(new Vector3(human.target.transform.position.x, human.target.transform.position.y, human.target.transform.position.z));
            flag = true;
        }
        agent.SetDestination(human.target.transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, human.target.transform.position, 3f * Time.fixedDeltaTime);

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.gameObject == human.target.gameObject)
        {
            flag = false;
            human.readyForWork = true;
            human.readyToMove = false;
            human.Doing();
        }
    }

}
