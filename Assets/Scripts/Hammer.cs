using UnityEngine;

public class Hammer : MonoBehaviour, ICollectable
{
    public void TransformHammer()
    {
        Debug.Log("Hammer!!");
    }
    
    public void Use()
    {
        TransformHammer();
    }
}