using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMORPG.Core
{
    enum ListScene
    {
        Map1,
        Map2
    }
    public class OnTriggerPortal : MonoBehaviour
    {
        [SerializeField] ListScene loadScene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(LoadMap());
            }
        }

        IEnumerator LoadMap()
        {
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync((int)loadScene);
            Debug.Log("Triggered with portal");
            print("Trigged portal");
            Destroy(gameObject);
        }
    }
}