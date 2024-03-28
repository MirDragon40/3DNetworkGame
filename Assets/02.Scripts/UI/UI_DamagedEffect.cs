using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UI_DamagedEffect : MonoBehaviour
{
    public static UI_DamagedEffect Instance { get; private set; }
    public AnimationCurve showCurve;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        Instance = this;

        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    public void Show(float duration)
    {
        _canvasGroup.alpha = 1f;
        StartCoroutine(Show_Cotoutine(duration));
    }

    private IEnumerator Show_Cotoutine(float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;

            //_canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime/duration);
            _canvasGroup.alpha = showCurve.Evaluate(elapsedTime / duration);

            yield return null;
        }
        _canvasGroup.alpha = 0f;
    }
}
