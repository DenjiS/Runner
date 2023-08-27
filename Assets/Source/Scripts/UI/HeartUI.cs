using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HeartUI : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, EndFill));
    }

    public void StartDestroy()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, EndDestroy));
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;

        while(elapsed < duration)
        {
            _image.fillAmount = Mathf.Lerp(startValue, endValue, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void EndFill(float value)
    {
        _image.fillAmount = value;
    }

    private void EndDestroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }
}
