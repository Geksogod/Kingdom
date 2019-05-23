using UnityEngine;

public class ResourcesKeeper : MonoBehaviour
{
    public int resourcesCounter;
    private  Vector3 startSize;
    public void Start()
    {
        resourcesCounter = Random.Range(3, 10);
        float changeSize = (float)resourcesCounter * 0.1F;
        this.gameObject.transform.localScale = this.gameObject.transform.localScale + new Vector3(changeSize, changeSize, changeSize);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + changeSize * 0.7f, this.transform.position.z);
    }
<<<<<<< HEAD
    public Resources.Resource GiveResources()
=======
    public void GiveResources()
>>>>>>> 99d43a3d9705488fe246dd03989c9325a7f27ff2
    {
        switch (this.gameObject.transform.parent.tag)
        {
            case "Wood":
                resourcesCounter--;
                GameObject.Find("ResourcesSystem").GetComponent<Resources>().ChangeCounter(Resources.Resource.Wood);
                ChangeSize();
<<<<<<< HEAD
                Debug.Log("Wood");
                return Resources.Resource.Wood;
        }
        return Resources.Resource.Wood;
=======
                break;
        }
>>>>>>> 99d43a3d9705488fe246dd03989c9325a7f27ff2
    }

    private void ChangeSize()
    {
        if (resourcesCounter <= 0)
            Destroy(this.transform.parent.gameObject);

        this.gameObject.transform.localScale = this.gameObject.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f * 0.7f, this.transform.position.z);
    }
}
