using System;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public string typeRes;
    public float mass;
    public enum Resource
    {
        Wood
    }
    public Resource selectedResurces;
    public Text woodCounter;
    public int wood;
    // Start is called before the first frame update
    void Start()
    {
        woodCounter.text = wood.ToString();
    }

    public Tuple<string,float> ChangeCounter(Resource resource)
    {
        switch (resource)
        {
            case Resource.Wood:
                typeRes = "Wood";
                mass = 10f;
                //woodCounter.text = wood.ToString();
                break;
        }
        return Tuple.Create(typeRes, mass);
    }
}
