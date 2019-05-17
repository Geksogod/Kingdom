using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Human
{
    public List<Resources.Resource> inventory = new List<Resources.Resource>();
    void Start()
    {
       target = ChooseTarget(Target.Type.Wood);
    }

    // Update is called once per frame
    void Update()
    {
        Move(target);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject == target && other.gameObject.GetComponent<ResourcesKeeper>()!=null)
        {
            if (ready)
            {
                inventory.Add(other.gameObject.GetComponent<ResourcesKeeper>().GiveResources());
                ready = false;
            }
            else
            {
                KD();
            }
            
        }
    }

   
}
