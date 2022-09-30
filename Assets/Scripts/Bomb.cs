using UnityEngine;

public class Bomb : MonoBehaviour, ICollectable
{
    private string name;
    public string Name { get { return name; } set { name = value; } }
    
    public void Start()
    {
        name = "Hammer";
    }
    
    public void PlantBomb()
    {
        
    }
    
    public void Use()
    {
        PlantBomb();
    }
}