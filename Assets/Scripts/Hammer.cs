using UnityEngine;

public class Hammer : MonoBehaviour, ICollectable
{
    private string name;
    public string Name { get { return name; } set { name = value; } }
    
    public void Start()
    {
        name = "Hammer";
    }
    
    public void TransformHammer()
    {
        Debug.Log("Hammer!!");
    }
    
    public void Use()
    {
        TransformHammer();
    }
}