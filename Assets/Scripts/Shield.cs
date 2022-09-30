using UnityEngine;

public class Shield : MonoBehaviour, ICollectable
{
    public string Name { get { return Name; } set { Name = "Shield"; }
    }
    
    public void ActivateShield()
    {
        
    }
    
    public void Use()
    {
        ActivateShield();
    }
}