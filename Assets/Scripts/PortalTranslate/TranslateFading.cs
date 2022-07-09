using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.PortalTranslate
{
    enum FadeMode
    {
        Fade = 1,
        UnFade = -1
    }

    public class TranslateFading : MonoBehaviour
    {
        [SerializeField] float timeFade;
        CanvasGroup canvasGroup;
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeScreen()
        {
            StartCoroutine(ChangeAlpha(FadeMode.Fade));
        }
        public void UnFadeScreen()
        {
            StartCoroutine(ChangeAlpha(FadeMode.UnFade));
        }

        IEnumerator ChangeAlpha(FadeMode fadeMode)
        {
            while (canvasGroup.alpha > 0 && canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += ((float)fadeMode * Time.deltaTime) / timeFade;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
