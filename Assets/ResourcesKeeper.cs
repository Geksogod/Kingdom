using System;
using UnityEngine;

public class ResourcesKeeper : MonoBehaviour
{
    public int resourcesCounter;
    private  Vector3 startSize;
    public void Start()
    {
        resourcesCounter = UnityEngine.Random.Range(3, 10);
        float changeSize = (float)resourcesCounter * 0.1F;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale + new Vector3(changeSize, changeSize, changeSize);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + changeSize * 0.7f, this.transform.position.z);
    }
    public Resources.Resource GiveResources()
    {
        Resources.Resource res = Resources.Resource.Wood;
        switch (this.gameObject.transform.parent.tag)
        {
            case "Wood":               
                res =  Resources.Resource.Wood;
                break;
            case "Rock":             
                res = Resources.Resource.Rock;
                break;
            case "Berries":
                res = Resources.Resource.Berries;
                break;
        }
        resourcesCounter--;
        ChangeSize();
        return res;
    }

    private void ChangeSize()
    {
        if (resourcesCounter <= 0)
            Destroy(this.transform.parent.gameObject);

        this.gameObject.transform.localScale = this.gameObject.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f * 0.7f, this.transform.position.z);
    }
}
