using System.Collections.Generic;
using UnityEngine;

public class Worker : Human
{
    public List<Resources.Resource> inventory = new List<Resources.Resource>();
    public Transform Debuging;
    public enum WhatToDo
    {
        goToStorage,
        working,
        Moving,
        Stop,
        Build,
        readyToChoseTarget

    }
    public WhatToDo Do;
    void Start()
    {
        //Do = WhatToDo.readyToChoseTarget;
        Do = WhatToDo.Build;
        maxSpeed = speed;
        Doing();
    }


    public void Doing()
    {
        switch (Do)
        {
            case WhatToDo.Stop:
                Stop();
                break;
            case WhatToDo.goToStorage:
                if (target.tag != "Storage")
                    target = ChooseTarget("Storage");
                else
                    Move(target);
                break;
            case WhatToDo.readyToChoseTarget:
                target = ChooseTarget(typeTarget);
                if (target != null)
                    Do = WhatToDo.Moving;
                break;
            case WhatToDo.Moving:
                if (target != null)
                    Move(target);
                else
                    Do = WhatToDo.readyToChoseTarget;
                break;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (target != null)
        {


            if (other.gameObject.transform.parent != null && other.gameObject.transform.parent.gameObject == target && other.gameObject.GetComponent<ResourcesKeeper>() != null)
            {
                if (inventory.Count >= 3)
                {
                    ready = false;
                    Do = WhatToDo.goToStorage;
                }
                else
                {
                    Do = WhatToDo.Stop;
                    if (ready)
                    {
                        inventory.Add(other.gameObject.GetComponent<ResourcesKeeper>().GiveResources());
                        Inventory();
                        ready = false;
                    }
                    else
                    {
                        
                        KD();
                        Do = WhatToDo.working;
                    }
                }
            }
            else if (other.gameObject == target && Do == WhatToDo.goToStorage)
            {
                if (ready)
                {
                    if (inventory.Count > 0)
                    {
                        inventory = other.gameObject.GetComponent<Storage>().AddRes(inventory);
                        ready = false;
                    }
                    else
                    {
                        Do = WhatToDo.readyToChoseTarget;
                    }
                }
                else
                {
                    KD();
                }
            }           
        }
        else
        {
            Do = WhatToDo.readyToChoseTarget;
        }
        Doing();
    }

    public void Inventory()
    {
        if (inventory.Count == 0)
        {
            speed = maxSpeed;
        }
        else
        {
            speed = speed * 1 - (inventory.Count / maxSpeed);
        }
    }


}
