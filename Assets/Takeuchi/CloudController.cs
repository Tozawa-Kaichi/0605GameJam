using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1f;
    [SerializeField]
    private Rigidbody2D _rigidbody = default;
    [SerializeField]
    private Transform[] _cloudBodys = default;
    [SerializeField]
    private float _startSize = 0.5f;
    [SerializeField]
    private RainCreate _rainCreate = default;
    [SerializeField]
    private int _rainCount = 10;
    [SerializeField]
    private RainCreate _thundercloud = default;
    [SerializeField]
    private float _thundercloudTime = 3f;
    private float _thundercloudTimer = 0f;
    private bool _isThundercloudRaining = false;
    private float _currentSize = 1f;
    private Vector2 _moveDir = Vector2.zero;
    private void Start()
    {
        _currentSize = _startSize;
        ChangeSize();
        _rainCreate.StartRain();
    }
    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        _moveDir.x = h;
        _moveDir.y = v;
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDir.normalized * _moveSpeed;
    }
    private void ChangeSize()
    {
        foreach (var cloudBody in _cloudBodys)
        {
            cloudBody.localScale = Vector3.one * _currentSize;
        }
        _rainCreate.ChangeRainCount((int)(_rainCount * _currentSize));
    }
    private IEnumerator ThundercloudRain()
    {
        while (_thundercloudTimer < _thundercloudTime)
        {
            _thundercloudTimer += Time.deltaTime;
            yield return null;
        }
        _thundercloud.StopRain();
        _isThundercloudRaining = false;
    }
    public void StartThundercloud()
    {
        _thundercloudTimer = 0f;
        _thundercloud.StartRain();
        if (!_isThundercloudRaining)
        {
            StartCoroutine(ThundercloudRain());
        }
    }
    public void AddSize(float size)
    {
        _currentSize += size;
        ChangeSize();
    }
}
