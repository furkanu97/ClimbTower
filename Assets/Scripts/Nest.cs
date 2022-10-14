using UnityEngine;

public class Nest : CollectableBase
{
    public void ReleaseBirds()
    {
        
    }
    
    public override void Use()
    {
        ReleaseBirds();
    }
}