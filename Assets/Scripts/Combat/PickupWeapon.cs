using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class PickupWeapon : MonoBehaviour
    {
        [SerializeField] string weaponName;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                var weapon = Resources.Load<Weapon>(weaponName);
                other.gameObject.GetComponent<Fight>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
