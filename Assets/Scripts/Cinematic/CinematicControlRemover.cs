using System;
using System.Collections;
using System.Collections.Generic;
using MMORPG.Control;
using MMORPG.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace MMORPG.Cinematic
{
    public class CinematicControlRemover : MonoBehaviour
    {
        GameObject player;
        void Start()
        {
            GetComponent<PlayableDirector>().played += OnStartIntro;
            GetComponent<PlayableDirector>().stopped += OnFinishIntro;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void OnStartIntro(PlayableDirector playableDirector)
        {
            DisableController();
        }

        private void DisableController()
        {
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        void OnFinishIntro(PlayableDirector playableDirector)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}