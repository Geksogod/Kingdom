using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    // Start is called before the first frame update
    private int capacity;
    private int filling;
    public bool open;
    void Start()
    {
        Recalculation();
    }

    // Update is called once per frame
    private void Recalculation()
    {
        if (filling < capacity)
            open = true;
        else
            open = false;
    }

    public void AddResources(int newResources)
    {
        filling += newResources;
        Recalculation();
    }

}
