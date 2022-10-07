using UnityEngine;

public class Bomb : MonoBehaviour, ICollectable
{    
    public void PlantBomb()
    {
        
    }
    
    public void Use()
    {
        PlantBomb();
    }
}