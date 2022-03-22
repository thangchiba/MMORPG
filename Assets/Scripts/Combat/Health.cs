using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        Debug.Log("HP : " + health);
        if (health == 0)
        {
            Debug.Log(gameObject.name + " Be Killed!!!");
        }
    }
}
