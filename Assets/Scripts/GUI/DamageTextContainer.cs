using UnityEngine;
using System.Collections;

public class DamageTextContainer : MonoBehaviour
{
    [SerializeField] GameObject DamageText = null;
	public void Spawn()
    {
        Instantiate(DamageText, gameObject.transform);
        Debug.Log("Spawn");
    }
}

