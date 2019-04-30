using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool finish = false;
    private bool flag = false;
    public GameObject Eye;
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
        if (!flag)
        {
            this.transform.LookAt(GameObject.FindWithTag("Wood").transform);
            flag = true;
        }
        if (!finish)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.FindWithTag("Wood").transform.position, 5f * Time.fixedDeltaTime);

        } 
    }
    public void FindNextResources()
    {
        finish = false;
        flag = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wood")
        {
            finish = true;
            flag = false;
            this.gameObject.GetComponent<WorkerWork>().StartProduction(other.gameObject);
            Debug.Log("dsdsadsaa");
        }
    }

}
