using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{
    public Text WoodCounter;


    public void Update()
    {
        WoodCounter.text = Resources.wood.ToString();
    }
    
}
