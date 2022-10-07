using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    [SerializeField] public Character character;
	[SerializeField] public UseCollectable button;
    [SerializeField] public GameObject step;
    [HideInInspector] public bool rotate;
    [SerializeField] public int rotateSpeed;

    private void Start()
    {
        rotate = false;
    }

    private void Update()
    {
        RotateAxe();
    }

    private void RotateAxe()
    {
        if (rotate)
        {
            transform.Rotate(rotateSpeed * 100 * Time.deltaTime * Vector3.back);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Concrete"))
        {
            rotate = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
			if(collision.collider.gameObject.name != CollectableList.Empty.ToString())
			{
				DestroyCollectable();
				AddCollectable(collision.collider.gameObject.name);
			}
        }
        else if (collision.gameObject.CompareTag("Holdable"))
        {
            rotate = false;
            PutStep();
        }
    }
    
	private void AddCollectable(string name)
	{
		if(name == "Hammer")
		{
			character.gameObject.AddComponent<Hammer>();
			character.collectable = CollectableList.Hammer;
			button.collectable = CollectableList.Hammer;
		}
		else if(name == "Nest")
		{
			character.gameObject.AddComponent<Nest>();
			character.collectable = CollectableList.Nest;
			button.collectable = CollectableList.Nest;
		}
		else if(name == "Bomb")
		{
			character.gameObject.AddComponent<Bomb>();
			character.collectable = CollectableList.Bomb;
			button.collectable = CollectableList.Bomb;
		}
		else if(name == "ThrowSnow")
		{
			character.gameObject.AddComponent<ThrowSnow>();
			character.collectable = CollectableList.ThrowSnow;
			button.collectable = CollectableList.ThrowSnow;
		}
		else if(name == "Shield")
		{
			character.gameObject.AddComponent<Shield>();
			character.collectable = CollectableList.Shield;
			button.collectable = CollectableList.Shield;
		}
	}

	private void DestroyCollectable()
	{
		if(character.GetComponent<Hammer>())
		{
			Destroy(character.GetComponent<Hammer>());
		}
		if(character.GetComponent<Nest>())
		{
			Destroy(character.GetComponent<Nest>());
		}
		if(character.GetComponent<Bomb>())
		{
			Destroy(character.GetComponent<Bomb>());
		}
		if(character.GetComponent<ThrowSnow>())
		{
			Destroy(character.GetComponent<ThrowSnow>());
		}
		if(character.GetComponent<Shield>())
		{
			Destroy(character.GetComponent<Shield>());
		}
		
	}
    
    private void PutStep()
    {
        character.GetComponent<Rigidbody>().velocity = Vector3.zero;
        step.transform.position = transform.position - new Vector3(0.2f,0.7f,-0.2f);
        step.SetActive(true);
    }
    
    
    
    // [SerializeField] public Material hammerMaterial;
    // [SerializeField] public Material pickaxeMaterial; 
    // private bool _hammerMode;
    //
    // private void TransformHammer()
    // {
    //     ctrl.rotate = false;
    //     ctrl.ResetRotation();
    //     _hammerMode = true;
    //     transform.localScale = new Vector3(0.25f, 0.25f, 0.2f);
    //     gameObject.GetComponent<MeshRenderer>().material = hammerMaterial;
    // }
    //
    // private void TransformPickaxe()
    // {
    //     ctrl.rotate = false;
    //     ctrl.ResetRotation();
    //     _hammerMode = false;
    //     transform.localScale = new Vector3(0.3f, 0.07f, 0.05f);
    //     gameObject.GetComponent<MeshRenderer>().material = pickaxeMaterial;
    // }
    //
    //
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Concrete"))
    //     {
    //         Debug.Log("Reset!");
    //         ctrl.hammerCounter = 0;
    //     }
    //     else if (other.gameObject.CompareTag("Holdable"))
    //     {
    //         ctrl.hammerCounter++;
    //         if (ctrl.hammerCounter == 3)
    //         {
    //             TransformHammer();
    //         }
    //         Debug.Log("Counter: " + ctrl.hammerCounter);
    //     }
    // }
    //
    // private void Swing(GameObject go)
    // {
    //     go.transform.position += Vector3.right*1.1f;
    //     go.GetComponent<Rigidbody>().useGravity = true;
    // }
}
