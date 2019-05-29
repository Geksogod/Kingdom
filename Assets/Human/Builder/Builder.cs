
using UnityEngine;

public class Builder 
{
    public string nameBuilder { get; set; }
    public  int needWood { get; set; }
    public  int needRock { get; set; }
    public Vector3 builderPosition { get; set; }

    public Builder(string name,int wood,int rock,Vector3 positin)
    {
        this.nameBuilder = name;
        this.needWood = wood;
        this.needRock = rock;
        this.builderPosition = positin;
    }


}
