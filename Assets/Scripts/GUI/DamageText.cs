using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] GameObject destroyObject = null;
    public void SelfDestroy()
    {
        Destroy(destroyObject);
    }

    public void SetDamageText(float damage)
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = damage.ToString();
    }
}

