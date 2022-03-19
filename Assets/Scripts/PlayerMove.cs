using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    Transform target;
    [SerializeField] Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    Ray lastRay;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToClickedPoint();
        }
    }

    private void MoveToClickedPoint()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
        }
        GetComponent<NavMeshAgent>().destination = hit.point;
        Debug.Log(hit.collider.name);
        //draw ray from camera to clicked point
        Debug.DrawRay(lastRay.origin, lastRay.direction * 5000);
    }
}
