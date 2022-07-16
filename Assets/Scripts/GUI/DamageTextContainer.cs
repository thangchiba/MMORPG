using UnityEngine;

public class DamageTextContainer : MonoBehaviour
{
    [SerializeField] GameObject DamageText = null;
	public void Spawn(float damage)
    {
        GameObject instance = Instantiate(DamageText, gameObject.transform);
        instance.GetComponentInChildren<DamageText>().SetDamageText(damage);
    }
}

