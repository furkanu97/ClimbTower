using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public Pickaxe pickaxe;
    [SerializeField] public CollectableList collectable;
    public bool onAir;
    
    void Start()
    {
        onAir = false;
        collectable = CollectableList.Empty;
    }

    void Update()
    {
        CarryPickaxe();
    }

    private void CarryPickaxe()
    {
        pickaxe.transform.position = transform.position + new Vector3(0.2f, 0, -0.3f);
    }

    public void Jump(Vector3 force)
    {
        pickaxe.transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(force);
        onAir = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Step"))
        {
            onAir = false;
        }
    }
}
