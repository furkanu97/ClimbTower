using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableList
{
    Empty,
    Hammer,
    Nest,
    Shield,
    ThrowSnow,
    Bomb
};
public class SetCollectable : MonoBehaviour
{
    [SerializeField] public CollectableList list;
    void Start()
    {
        gameObject.name = list.ToString();
    }
}
