using UnityEngine;
using System.Collections;

public class DestroyAfterEffect : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (!GetComponent<ParticleSystem>().IsAlive())
        {
			Destroy(gameObject);
        }
	}
}

