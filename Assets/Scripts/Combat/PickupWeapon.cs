using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat { 
public class PickupWeapon : MonoBehaviour
{
        [SerializeField] Weapon weapon = null;
        private void OnTriggerEnter(Collider other)
        {

            print("cham vao vukhi");
            if (other.gameObject.tag == "Player")
            {
                print("Da cham vao vu khi");
                other.gameObject.GetComponent<Fight>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
