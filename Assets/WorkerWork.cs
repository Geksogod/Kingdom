using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerWork : MonoBehaviour
{
    // Start is called before the first frame update
    float currCountdownValue;
    GameObject target;
  
    private void GetResources(GameObject ResourcesKeeper)
    {
        if (ResourcesKeeper!=null&& ResourcesKeeper.GetComponent<ResourcesKeeper>().resourcesCounter > 0)
        {
            StartCoroutine(RechargeGetResources());
            ResourcesKeeper.GetComponent<ResourcesKeeper>().GiveResources();
        }
        else
        {
            this.GetComponent<workerMove>().FindNextResources();
        }
    }
    public IEnumerator RechargeGetResources(float countdownValue = 3)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(3);
            GetResources(target);
            currCountdownValue -= 3;
        }
    }
    public void StartProduction(GameObject ResourcesKeeper)
    {
        target = ResourcesKeeper;
        StartCoroutine(RechargeGetResources());
    }
    private void Production(GameObject ResourcesKeeper)
    {
        if(ResourcesKeeper.GetComponent<ResourcesKeeper>().resourcesCounter>0)
            StartCoroutine(RechargeGetResources());
    }
}
