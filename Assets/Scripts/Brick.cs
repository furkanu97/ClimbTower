using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, ICollectable
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
