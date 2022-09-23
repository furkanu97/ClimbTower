using System;
using UnityEditor.Rendering;
using UnityEngine;
using Random = System.Random;

public class Check : MonoBehaviour
{
    [SerializeField] public Control ctrl;
    [SerializeField] public Material hammerMaterial;
    [SerializeField] public Material pickaxeMaterial; 
    private bool _hammerMode;

    private void Start()
    {
        _hammerMode = false;
    }

    private void TransformHammer()
    {
        ctrl.rotate = false;
        ctrl.ResetRotation();
        _hammerMode = true;
        transform.localScale = new Vector3(0.25f, 0.25f, 0.2f);
        gameObject.GetComponent<MeshRenderer>().material = hammerMaterial;
    }

    private void TransformPickaxe()
    {
        ctrl.rotate = false;
        ctrl.ResetRotation();
        _hammerMode = false;
        transform.localScale = new Vector3(0.3f, 0.07f, 0.05f);
        gameObject.GetComponent<MeshRenderer>().material = pickaxeMaterial;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_hammerMode)
        {
            Debug.Log("BUM! Hit " + collision.gameObject.name);
            Swing(collision.gameObject);
            TransformPickaxe();
        }
        if (collision.gameObject.CompareTag("Concrete"))
        {
            ctrl.rotate = false;
            ctrl.ResetRotation();
        }
        else if (collision.gameObject.CompareTag("Holdable"))
        {
            ctrl.rotate = false;
            ctrl.PutStep();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Concrete"))
        {
            Debug.Log("Reset!");
            ctrl.hammerCounter = 0;
        }
        else if (other.gameObject.CompareTag("Holdable"))
        {
            ctrl.hammerCounter++;
            if (ctrl.hammerCounter == 3)
            {
                TransformHammer();
            }
            Debug.Log("Counter: " + ctrl.hammerCounter);
        }
    }

    private void Swing(GameObject go)
    {
        go.transform.position += Vector3.right*1.1f;
        go.GetComponent<Rigidbody>().useGravity = true;
    }
}
