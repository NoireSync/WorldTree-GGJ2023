using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shouldShake;
    public float _dur = .15f;
    public float _mag = .4f;

    private void Update()
    {
        if(shouldShake)
        {
            StartCoroutine(Shake(_dur, _mag));
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;

        }

        transform.localPosition = originalPos;
        shouldShake = false;
    }
}
