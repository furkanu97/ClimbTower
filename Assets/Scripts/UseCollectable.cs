using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseCollectable : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] public List<Sprite> sprites;
    private Sprite _sprite;
    private Image _image;
    private void Start()
    {
        _image = transform.Find("Feature").gameObject.GetComponent<Image>();
        GetComponent<Button>().interactable = false;
    }
    public void UseOnClick()
    {
        if (character.GetComponent<CollectableBase>())
        {
            character.GetComponent<CollectableBase>().Use();
            _image.sprite = null;
            _image.color = Color.red;
        }
    }

    public void ChangeIcon(string collectableName)
    {
        if (collectableName != "Empty")
        {
            _sprite = sprites.Find(sp => sp.name == collectableName);
            _image.sprite = _sprite;
            _image.color = Color.white;
        }
    }
}
