using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public List<Sprite> sprites;
    private SpriteRenderer m_SpriteRenderer;
    private void Start()
    {
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

    public void ChangeIcon(CollectableList collectable)
    {
        if (collectable != CollectableList.Empty)
        {
            foreach (var sp in sprites)
            {
                Debug.Log("Name: " + sp.name);
                Debug.Log("Cl Name: " + collectable.ToString());
                if (sp.name == collectable.ToString())
                {
                    m_SpriteRenderer.sprite = sp;
                }
            }
        }
    }
}
