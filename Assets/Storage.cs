using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{



    public void AddRes(Resources.Resource res)
    {
        switch (res)
        {
            case Resources.Resource.Wood:
                Resources.wood++;
                break;
        }
    }
}
