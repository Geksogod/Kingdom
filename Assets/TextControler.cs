using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{
    public Text WoodCounter;
    public Text RockCounter;
    public Text BerriesCounter;


    public void Update()
    {
        WoodCounter.text = Resources.wood.ToString();
        RockCounter.text = Resources.rock.ToString();
        BerriesCounter.text = Resources.berries.ToString();
    }
    
}
