using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] public GameObject step;
    [SerializeField] public Transform pickAxe;
    [SerializeField] public int forceFactor;
    private Rigidbody _mRigidBody;
    private bool _onAir;
    private float _decimalPart;
    private float _y;
    private float _pullRate;
    void Start()
    {
        _onAir = false;
        _mRigidBody = GetComponent<Rigidbody>();
        _pullRate = 0;
        _y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pickAxe.position = transform.position + new Vector3(0.2f, 0, -0.2f);
        if (_onAir)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("On Air");
                // _y = transform.position.y;
                // _decimalPart = _y % 1;
                pickAxe.eulerAngles = new Vector3(0, 0, -30);
                step.transform.position = pickAxe.position - new Vector3(0.1f,1f,-0.2f);
                step.SetActive(true);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _y = Input.mousePosition.y;
                Debug.Log("Y: " + _y);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _pullRate = Input.mousePosition.y - _y;
                Debug.Log("Y: " + Input.mousePosition.y);
                Debug.Log("Pulled: " + _pullRate);
                _mRigidBody.AddForce(Vector3.down * forceFactor * _pullRate);
                _onAir = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Step"))
        {
            _onAir = false;
            pickAxe.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
