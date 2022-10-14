using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pickaxe : MonoBehaviour
{
    [SerializeField] public Character character;
	[SerializeField] public UseCollectable button;
    [SerializeField] public GameObject step;
    [SerializeField] public Material hammerMaterial;
    [SerializeField] public Material pickaxeMaterial; 
    [HideInInspector] public bool rotate;
    [HideInInspector] public bool hammerMode;
    [SerializeField] public int rotateSpeed;

    private void Start()
    {
        rotate = false;
        hammerMode = false;
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
	    rotate = false;
	    if (hammerMode)
	    {
		    TransformPickaxe();
		    Swing(collision.collider.gameObject);
	    }
	    if (collision.gameObject.CompareTag("Concrete"))
	    {
		    transform.eulerAngles = new Vector3(0, 0, 0);
		    if (collision.gameObject.name != "Concrete")
		    {
			    DestroyCollectable();
			    button.GetComponent<Button>().interactable = true;
			    AddCollectable(collision.collider.gameObject.name);
		    }
	    }
	    else if (collision.gameObject.CompareTag("Holdable") && !hammerMode)
	    {
		    PutStep();
	    }
    }
    
	private void AddCollectable(string collectableName)
	{
		character.collectable = collectableName switch
		{
			"Hammer" => FindObjectOfType<Hammer>(),
			"Nest" => FindObjectOfType<Nest>(),
			"Bomb" => FindObjectOfType<Bomb>(),
			"ThrowSnow" => FindObjectOfType<ThrowSnow>(),
			"Shield" => FindObjectOfType<Shield>(),
			_ => character.collectable
		};
		button.ChangeIcon(collectableName);
	}

	private void DestroyCollectable()
	{
		if(character.GetComponent<CollectableBase>())
		{
			Destroy(character.GetComponent<CollectableBase>());
			button.GetComponent<Button>().interactable = false;
		}
	}
    
    private void PutStep()
    {
        character.GetComponent<Rigidbody>().velocity = Vector3.zero;
        step.transform.position = transform.position - new Vector3(0.2f,0.7f,-0.2f);
        step.SetActive(true);
    }

    private void TransformPickaxe()
    {
	    hammerMode = false;
	    transform.Find("Top").localScale = new Vector3(0.3f, 0.07f, 0.05f);
        GetComponentInChildren<MeshRenderer>().material = pickaxeMaterial;
    }
    
    private void Swing(GameObject go)
    {
        go.transform.position += Vector3.right*1.1f;
        go.GetComponent<Rigidbody>().useGravity = true;
    }
}
