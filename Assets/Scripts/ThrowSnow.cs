using UnityEngine;

public class ThrowSnow : MonoBehaviour, ICollectable
{
    private string name;
    public string Name { get { return name; } set { name = value; } }
    
    public void Start()
    {
        name = "Hammer";
    }
    
    public void ThrowSnowBall()
    {
        
    }
    
    public void Use()
    {
        ThrowSnowBall();
    }
}