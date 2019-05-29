using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public static List<Builder> NeedToBuild = new List<Builder>();
    public List<GameObject> PrefabBuilds_House = new List<GameObject>();

    public void AddBuildingToBuild(int id)
    {
        switch (id)
        {
            case 0:
                Builder main = new Builder("House",10,10,new Vector3(26.4008f, 20.28f, 167.0808f));
                NeedToBuild.Add(main);
                GameObject mainBuild = Instantiate(PrefabBuilds_House[0], main.builderPosition,new Quaternion(0f,0f,0f,0f));
                Build build = mainBuild.AddComponent<Build>();
                build.NeedResources[Resources.Resource.Wood] = main.needWood;
                build.NeedResources[Resources.Resource.Rock] = main.needRock;
                build.PrefabBuilds = PrefabBuilds_House;
                build.Start_();
                break;
        }
        
    }
}
