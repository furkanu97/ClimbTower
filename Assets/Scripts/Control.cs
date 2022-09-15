using UnityEngine;

public class Control : MonoBehaviour
{
    [HideInInspector] public bool rotate;
    [SerializeField] public GameObject step;
    [SerializeField] public Transform pickAxe;
    [SerializeField] public int forceFactor;
    [SerializeField] public int rotateSpeed;
    private Rigidbody _mRigidBody;
    private bool _onAir;
    private float _y;
    private float _pullRate;
    void Start()
    {
        _onAir = false;
        rotate = false;
        _mRigidBody = GetComponent<Rigidbody>();
        _y = 0;
    }

    void Update()
    {
        CarryPickaxe();
        GetInput();
        RotateAxe();
    }

    private void CarryPickaxe()
    {
        pickAxe.position = transform.position + new Vector3(0.2f, 0, -0.2f);
    }
    
    private void GetInput()
    {
        if (_onAir)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rotate = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _y = Input.mousePosition.y;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _pullRate = Input.mousePosition.y - _y;
                if(_pullRate < 0) Jump();
            }
        }
    }
    
    private void RotateAxe()
    {
        if (rotate)
        {
            pickAxe.Rotate(rotateSpeed * 100 * Time.deltaTime * Vector3.back);
        }
    }

    public void ResetRotation()
    {
        pickAxe.eulerAngles = new Vector3(0, 0, 0);
    }
    
    private void Jump()
    {
        ResetRotation();
        _mRigidBody.AddForce(Vector3.down * forceFactor * _pullRate);
        _onAir = true;
    }

    public void PutStep()
    {
        _mRigidBody.velocity = Vector3.zero;
        step.transform.position = pickAxe.position - new Vector3(0.2f,0.5f,-0.2f);
        step.SetActive(true);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Step"))
        {
            _onAir = false;
        }
    }
}
