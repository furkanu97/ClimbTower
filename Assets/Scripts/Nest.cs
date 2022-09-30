using UnityEngine;

public class Nest : MonoBehaviour, ICollectable
{
    private string name;
    public string Name { get { return name; } set { name = value; } }
    
    public void Start()
    {
        name = "Hammer";
    }

    public void ReleaseBirds()
    {
        
    }
    
    public void Use()
    {
        ReleaseBirds();
    }
}