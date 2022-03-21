    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    Ray lastRay;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToClickedPoint();
        }
        UpdateAnimator();
    }

    private void MoveToClickedPoint()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        //Grabbing global coordinates move speed
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        //Calc local move speed by global
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        //Local move speed
        float moveSpeed = localVelocity.z;
        //Set Animator move speed
        GetComponent<Animator>().SetFloat("moveSpeed", moveSpeed,0.05f,Time.deltaTime);
        Debug.Log(moveSpeed);
    }
}
