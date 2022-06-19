using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat { 
public class PickupWeapon : MonoBehaviour
{
        [SerializeField] Weapon weapon = null;
        private void OnCollisionEnter(Collision collision)
        {
            print("cham vao vukhi");
            if(collision.gameObject.tag == "Player")
            {
                print("Da cham vao vu khi");
                 collision.gameObject.GetComponent<Fight>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
