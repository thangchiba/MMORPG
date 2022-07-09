using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class PickupWeapon : MonoBehaviour
    {
        [SerializeField] string weaponName;
        [SerializeField] float respawnTime=3f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                var weapon = Resources.Load<Weapon>("Weapons/"+weaponName);
                other.gameObject.GetComponent<Fight>().EquipWeapon(weapon);
                //Destroy(gameObject);
                StartCoroutine(HideForSeconds(respawnTime));
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
    }
}
