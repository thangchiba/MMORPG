using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MMORPG.Move;
using MMORPG.Combat;

namespace MMORPG.Control
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        // Start is called before the first frame update
        void Awake()
        {
            Application.targetFrameRate = 60;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckHit();
            }
        }

        private void CheckHit()
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GetComponent<Mover>().MoveToPoint(hit.point);
                GameObject hitObject = hit.collider.gameObject;
                GetComponent<Fight>().SetTarget(hitObject);
            }
        }
    }
}