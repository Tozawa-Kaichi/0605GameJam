using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    private WaitForFixedUpdate _waitForFixed = default;
    private bool _isPlaying = false;
    private Vector3 _startPos = Vector3.zero;
    private void OnEnable()
    {
        _waitForFixed = new WaitForFixedUpdate();
        CameraShakeController.OnShake += StartShake;
        _startPos = transform.localPosition;
    }
    private void OnDisable()
    {
        CameraShakeController.OnShake -= StartShake;
    }
    private void StartShake(float power)
    {
        if (_isPlaying)
        {
            return;
        }
        _isPlaying = true;
        StartCoroutine(Shake(power));
    }
    private IEnumerator Shake(float power)
    {
        Vector3 pos = _startPos;
        pos.x += Random.Range(-power, power);
        pos.y += Random.Range(-power, power);
        transform.localPosition = pos;
        yield return _waitForFixed;
        transform.localPosition = _startPos;
        _isPlaying = false;
    }
}
