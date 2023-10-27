using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    private Camera cam;
    private void Start()
    {
        Target = GameObject.Find("Target");
        cam = Camera.main;
    }

    private void Update()
    {
        if (Target != null)
        {
            SetTarget();
        }
        else
        {
            Debug.LogError("Set Target Instance");
        }
    }

    private void SetTarget()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Target.transform.position = hit.point;
            }
        }
    }
}
