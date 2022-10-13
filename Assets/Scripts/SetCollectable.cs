using System;
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
    private Transform _child;
    void Start()
    {
        gameObject.name = list.ToString();
        _child = transform.Find(list.ToString());
    }

    private void Update()
    {
        if (list != CollectableList.Empty)
        {
            _child.gameObject.SetActive(true);
        }
    }
}
