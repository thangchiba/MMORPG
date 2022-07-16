using UnityEngine;
using System.Collections;
using System;

public class DamageTextContainer : MonoBehaviour
{
    [SerializeField] GameObject DamageText = null;
    [SerializeField] TextMesh text;
	public void Spawn(float damage)
    {
        GameObject instance = Instantiate(DamageText, gameObject.transform);
        Debug.Log("take damage : "+damage);
        instance.GetComponentInChildren<DamageText>().SetDamageText(damage);
    }
}

