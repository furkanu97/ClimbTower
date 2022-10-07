using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableList
{
    Empty,
    CollectHammer,
    CollectNest,
    CollectShield,
    CollectThrowSnow,
    CollectBomb
};
public class SetCollectable : MonoBehaviour
{
    [SerializeField] public CollectableList list;
    void Start()
    {
        Debug.Log("Collectable selected: " + list);
        gameObject.name = list.ToString();
    }
}
