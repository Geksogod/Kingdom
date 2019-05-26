using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{



    public List<Resources.Resource> AddRes(List<Resources.Resource> inventory)
    {
        Debug.Log(inventory[0]);
        switch (inventory[0])
        {
            case Resources.Resource.Rock:
                Resources.rock++;
                break;
            case Resources.Resource.Wood:
                Resources.wood++;
                break;
            case Resources.Resource.Berries:
                Resources.berries++;
                break;
        }
        inventory.RemoveAt(0);
        return inventory;
    }
}
