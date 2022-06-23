using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MMORPG.PortalTranslate
{
    enum ListScene
    {
        Map1,
        Map2,
        Map3
    }
    public class OnTriggerPortal : MonoBehaviour
    {
        [SerializeField] ListScene loadScene;
        TranslateFading fader;
        private void Start()
        {
            //fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<TranslateFading>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(LoadMap());
            }
        }

        IEnumerator LoadMap()
        {
            yield return SceneManager.LoadSceneAsync((int)loadScene);
        }
    }
}