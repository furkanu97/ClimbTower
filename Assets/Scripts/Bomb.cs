using UnityEngine;

public class Bomb : CollectableBase
{    
    public void PlantBomb()
    {
        
    }
    
    public override void Use()
    {
        PlantBomb();
    }
}