using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShaker : MonoBehaviour
{
    public RectTransform uiElement;
    public float shakeMagnitude = 10f;
    public float shakeDuration = 0.5f;

    private Vector3 originalPosition;

    private void Start()
    {
        if (uiElement == null)
        {
            Debug.LogError("UI Element reference not set!");
            enabled = false;
            return;
        }

        originalPosition = uiElement.localPosition;
    }

    public void Shake()
    {
        if (uiElement != null)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            Vector3 newPos = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            uiElement.localPosition = newPos;

            elapsed += Time.deltaTime;

            yield return null;
        }

        uiElement.localPosition = originalPosition;
    }
}
