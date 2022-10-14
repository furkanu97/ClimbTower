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
    [SerializeField] public List<Sprite> sprites;
    private Sprite _sprite;
    private Transform _child;
    void Start()
    {
        gameObject.name = list.ToString();
        _child = transform.Find("Feature");
        _sprite = sprites.Find(sp => sp.name == list.ToString());
        _child.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
    }
}
