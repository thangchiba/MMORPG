using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MMORPG.Cinematic
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool isIntroPlayed = false;
        private void OnTriggerEnter(Collider other)
        {
            if (isIntroPlayed == false && other.gameObject.tag == "Player")
            {
                isIntroPlayed = true;
                GetComponentInParent<PlayableDirector>().Play();
            }
        }
    }
}
