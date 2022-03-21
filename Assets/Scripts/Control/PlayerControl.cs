using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MMORPG.Move;
using MMORPG.Combat;

namespace MMORPG.Control
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        void Awake()
        {
            Application.targetFrameRate = 60;
        }

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
                String hitObjectTag = hit.collider.gameObject.tag;
                if (hitObjectTag == "Enemy" || hitObjectTag == "Minion")
                {
                    GetComponent<Fight>().SetTarget(hit.collider.gameObject);
                }
            }
        }
    }
}