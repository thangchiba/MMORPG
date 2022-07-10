using System;
using System.Collections;
using System.Collections.Generic;
using MMORPG.Control;
using UnityEngine;

namespace MMORPG.Combat
{
    public class PickupWeapon : MonoBehaviour, IRaycastable
    {
        [SerializeField] string weaponName;
        [SerializeField] float respawnTime = 3f;
        Fight player;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Fight>();
        }

        bool triggering = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                triggering = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                triggering = false;
            }
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowPickup(false);
            yield return new WaitForSeconds(seconds);
            ShowPickup(true);
        }

        private void ShowPickup(bool shouldShow)
        {
            GetComponent<Collider>().enabled = shouldShow;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(shouldShow);
            }
        }

        public CursorType GetCursorType()
        {
            return CursorType.Pickup;
        }

        public bool HandleRaycast()
        {
            if (!triggering) return false;
            if (Input.GetMouseButton(0))
            {
                var weapon = Resources.Load<Weapon>("Weapons/" + weaponName);
                player.EquipWeapon(weapon);
                StartCoroutine(HideForSeconds(respawnTime));
            }
            return true;
        }
    }
}
