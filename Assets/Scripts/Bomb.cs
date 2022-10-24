using UnityEngine;

public class Bomb : CollectableBase
{    
    public void PlantBomb()
    {
        Debug.Log("Planted!!!");
    }
    
    public override void Use()
    {
        PlantBomb();
    }
}