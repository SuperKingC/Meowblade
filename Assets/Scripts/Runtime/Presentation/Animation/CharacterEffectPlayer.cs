using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public sealed class CharacterEffectPlayer : MonoBehaviour
    {
        [SerializeField] private Graphic target;
        [SerializeField] private float pulseScale = 1.08f;
        [SerializeField] private float pulseDuration = 0.12f;
        [SerializeField] private Color flashColor = Color.white;
        [SerializeField] private float flashDuration = 0.1f;

        private Coroutine effectRoutine;
        private Color baseColor = Color.white;

        private void Awake()
        {
            if (target != null)
            {
                baseColor = target.color;
            }

            ResetEffects();
        }

        public void Pulse()
        {
            StartEffect(PulseRoutine());
        }

        public void Flash()
        {
            StartEffect(FlashRoutine());
        }

        public void ResetEffects()
        {
            if (effectRoutine != null)
            {
                StopCoroutine(effectRoutine);
                effectRoutine = null;
            }

            transform.localScale = Vector3.one;
            if (target != null)
            {
                target.color = baseColor;
                target.canvasRenderer.SetAlpha(1f);
            }
        }

        private void StartEffect(IEnumerator routine)
        {
            ResetEffects();
            effectRoutine = StartCoroutine(routine);
        }

        private IEnumerator PulseRoutine()
        {
            float halfDuration = Mathf.Max(0.01f, pulseDuration * 0.5f);
            yield return ScaleOverTime(Vector3.one, Vector3.one * pulseScale, halfDuration);
            yield return ScaleOverTime(Vector3.one * pulseScale, Vector3.one, halfDuration);
            effectRoutine = null;
        }

        private IEnumerator FlashRoutine()
        {
            if (target == null)
            {
                yield break;
            }

            target.color = flashColor;
            yield return new WaitForSeconds(Mathf.Max(0f, flashDuration));
            target.color = baseColor;
            effectRoutine = null;
        }

        private IEnumerator ScaleOverTime(Vector3 from, Vector3 to, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.unscaledDeltaTime;
                transform.localScale = Vector3.Lerp(from, to, Mathf.Clamp01(elapsed / duration));
                yield return null;
            }

            transform.localScale = to;
        }
    }
}
