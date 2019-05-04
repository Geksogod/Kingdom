using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
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

    public void ChangeCounter(Resource resource)
    {
        switch (resource)
        {
            case Resource.Wood:
                wood++;
                woodCounter.text = wood.ToString();
                break;
        }
    }
}
