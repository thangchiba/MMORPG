using UnityEngine;
using System.Collections;

namespace MMORPG.Common
{
    public class PlayAudioSourceOnAwake : MonoBehaviour
    {
        [SerializeField] AudioSource audio = null;
        [SerializeField] float destroyAfter = 5f;
        void Awake()
        {
            if (audio != null)
            {
                audio.Play();
                Destroy(audio, destroyAfter);
            }
        }
    }

}