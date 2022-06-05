using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField]
    private HPBar _hPBar = default;
    [SerializeField]
    private int[] _sizeChangePoints = { 10, 30, 60, 80 };
    [SerializeField]
    private float[] _upSizes = { 1.2f, 1.5f, 1.8f, 2f };
    [SerializeField]
    private float[] _upPos = { 1.2f, 1.5f, 1.8f, 2f };
    [SerializeField]
    private Transform _plantTransform = default;
    [SerializeField]
    private ParticleSystem _plantSystem = null;
    private int _currentSize = 0;
    private void Update()
    {
        if (_currentSize > 0 && _plantTransform.localPosition != Vector3.up * _upPos[_currentSize - 1])
        {
            _plantTransform.localPosition = Vector3.Lerp(_plantTransform.localPosition, Vector3.up * _upPos[_currentSize - 1], Time.deltaTime);
        }
        if (_currentSize >= _sizeChangePoints.Length)
        {
            return;
        }
        if (_hPBar.currentHp >= _sizeChangePoints[_currentSize])
        {
            _plantTransform.localScale = Vector3.one * _upSizes[_currentSize];
            _currentSize++;
            if (_currentSize >= _sizeChangePoints.Length)
            {
                _plantSystem.Play();
                return;
            }
        }
    }
}