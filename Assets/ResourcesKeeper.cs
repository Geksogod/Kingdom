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
        switch (this.gameObject.transform.parent.tag)
        {
            case "Wood":
                resourcesCounter--;
                ChangeSize();
                Debug.Log("Wood");
                return Resources.Resource.Wood;
        }
        return Resources.Resource.Wood;
    }

    private void ChangeSize()
    {
        if (resourcesCounter <= 0)
            Destroy(this.transform.parent.gameObject);

        this.gameObject.transform.localScale = this.gameObject.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f * 0.7f, this.transform.position.z);
    }
}
