using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public Hammer hammer;
    [SerializeField] public CollectableList collectable;
    public void Start()
    {
        collectable = CollectableList.Empty;
    }

    public void UseOnClick()
    {
        if (character.GetComponent<Hammer>())
        {
            character.GetComponent<Hammer>().Use();
        }
        else if (character.GetComponent<Bomb>())
        {
            character.GetComponent<Bomb>().Use();
        }
        else if (character.GetComponent<Nest>())
        {
            character.GetComponent<Nest>().Use();
        }
        else if (character.GetComponent<ThrowSnow>())
        {
            character.GetComponent<ThrowSnow>().Use();
        }
        else if (character.GetComponent<Shield>())
        {
            character.GetComponent<Shield>().Use();
        }
    }
}
