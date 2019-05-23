using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
<<<<<<< HEAD
    public static int wood;
=======
>>>>>>> 99d43a3d9705488fe246dd03989c9325a7f27ff2
    public enum Resource
    {
        Wood
    }

<<<<<<< HEAD



    
=======
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
>>>>>>> 99d43a3d9705488fe246dd03989c9325a7f27ff2
}
