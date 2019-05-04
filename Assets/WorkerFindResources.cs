using UnityEngine;

public class WorkerFindResources : MonoBehaviour
{
    private Human human;
    private GameObject target;

    private void Start()
    {
        human = gameObject.GetComponent<Human>();
    }

    public  GameObject FindResources(string resoursec)
    {
        if(GameObject.FindGameObjectsWithTag(resoursec).Length>0)
            target = GameObject.FindGameObjectsWithTag(resoursec)[0];
        for (int i = 0; i < GameObject.FindGameObjectsWithTag(resoursec).Length; i++)
        {
            GameObject checktarget = GameObject.FindGameObjectsWithTag(resoursec)[i];
            if (transform.position.magnitude - target.transform.position.magnitude > transform.position.magnitude - checktarget.transform.position.magnitude)
                target = checktarget;
        }
        if(target==null)
            human.relaxation = true;
        return target;
    }

    
}
    
