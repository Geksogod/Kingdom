using System.Collections;
using UnityEngine;

public class WorkerWork : MonoBehaviour
{
    // Start is called before the first frame update
    private float currCountdownValue;
    private Human human;
    private void Start()
    {
        human = gameObject.GetComponent<Human>();
    }

    private void GetResources(GameObject ResourcesKeeper)
    {
        
        if (ResourcesKeeper != null && ResourcesKeeper.GetComponent<ResourcesKeeper>().resourcesCounter > 0)
        {
            StartCoroutine(RechargeGetResources());
            human.inventory.Add(ResourcesKeeper.GetComponent<ResourcesKeeper>().GiveResources().Item1, ResourcesKeeper.GetComponent<ResourcesKeeper>().GiveResources().Item2);
        }
        else
        {
            human.target = null;
            human.readyForWork = false;
            human.Doing();
        }
    }
    public IEnumerator RechargeGetResources(float countdownValue = 3)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(3);
            GetResources(human.target);
            currCountdownValue -= 3;
        }
    }
    public void StartProduction(GameObject ResourcesKeeper)
    {
        human.target = ResourcesKeeper;
        StartCoroutine(RechargeGetResources());
    }
    private void Production(GameObject ResourcesKeeper)
    {
        if (ResourcesKeeper.GetComponent<ResourcesKeeper>().resourcesCounter > 0)
            StartCoroutine(RechargeGetResources());
    }


}
