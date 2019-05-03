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
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wood").Length; i++)
        {
            Vector3 directionToTarget = GameObject.FindGameObjectsWithTag("Wood")[i].transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                target = GameObject.FindGameObjectsWithTag("Wood")[i];
            }
        }
            

        return target;
    }

    
}
    
