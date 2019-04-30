using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool finish = false;
    private bool flag = false;
    private bool found = false;
    private GameObject target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindResources();
    }


    public void FindResources()
    {
        if (!found)
        {
            target = GameObject.FindGameObjectsWithTag("Wood")[0];
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wood").Length; i++)
            {
                GameObject checktarget = GameObject.FindGameObjectsWithTag("Wood")[i];
                if (transform.transform.position.magnitude - target.transform.position.magnitude < transform.position.magnitude - checktarget.transform.position.magnitude)
                    target = checktarget;

            }
            found = true;
        }
        Debug.Log(target);
        MoveToResources(target);
    }
    public void MoveToResources(GameObject target)
    {
        if (!flag)
        {
            this.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
            flag = true;
        }
        if (!finish)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 5f * Time.fixedDeltaTime);

        }
    }
    public void FindNextResources()
    {
        finish = false;
        flag = false;
        found = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent.gameObject == target.gameObject)
        {
            finish = true;
            flag = false;       
            this.gameObject.GetComponent<WorkerWork>().StartProduction(other.gameObject);
        }
    }

}
