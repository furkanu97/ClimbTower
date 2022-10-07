using UnityEngine;

public class Nest : MonoBehaviour, ICollectable
{
    public void ReleaseBirds()
    {
        
    }
    
    public void Use()
    {
        ReleaseBirds();
    }
}