using UnityEngine;
using System.Collections;

public class DamageText : MonoBehaviour
{
    [SerializeField] GameObject destroyObject = null;
    public void SelfDestroy()
    {
        Destroy(destroyObject);
    }
}

