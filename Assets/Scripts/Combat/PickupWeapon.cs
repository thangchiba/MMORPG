using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class PickupWeapon : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Fight>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
