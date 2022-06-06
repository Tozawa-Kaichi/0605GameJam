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
    [SerializeField]
    private float _maxSize = 2f;
    [SerializeField]
    private float _maxSpeed = 12f;
    [SerializeField]
    private float _shakeRange = 0.02f;
    [SerializeField]
    private float _heavyRainSize = 0.0f;
    [SerializeField]
    private float _heavyRainSpeed = 0.2f;
    [SerializeField]
    private int _heavyRainPower = 5;
    [SerializeField]
    private ParticleSystem _heavyRainParticle = default;
    private int _currentPower = 1;
    private float _thundercloudTimer = 0f;
    private bool _isThundercloudRaining = false;
    private float _currentSize = 1f;
    private float _currentSpeed = default;
    private Vector2 _moveDir = Vector2.zero;
    private bool _isHeavyRaining = false;
    /// <summary>
    /// 10î{Ç∑ÇÈÇ∆1ïbä‘ÇÃç~âJó 
    /// </summary>
    public int RainCount { get => (int)(_rainCount * _currentSize) * _currentPower; }
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
        if (_currentSize > _startSize + _heavyRainSize && Input.GetButton("Jump"))
        {
            _isHeavyRaining = true;
            _currentPower = _heavyRainPower;
            ChangeSize();
            _heavyRainParticle.Play();
            _currentSize -= _heavyRainSpeed * Time.deltaTime;
            CameraShakeController.PlayShake(_shakeRange);
        }
        else if (_isHeavyRaining)
        {
            _isHeavyRaining = false;
            _currentPower = 1;
            ChangeSize();
        }
    }
    private void FixedUpdate()
    {
        _currentSpeed = _moveSpeed / _currentSize;
        if (_currentSpeed > _maxSpeed)
        {
            _currentSpeed = _maxSpeed;
        }
        _rigidbody.velocity = _moveDir.normalized * _currentSpeed;
    }
    private void ChangeSize()
    {
        foreach (var cloudBody in _cloudBodys)
        {
            cloudBody.localScale = Vector3.one * _currentSize;
        }
        _rainCreate.ChangeRainCount(RainCount);
    }
    private IEnumerator ThundercloudRain()
    {
        while (_thundercloudTimer < _thundercloudTime)
        {
            CameraShakeController.PlayShake(_shakeRange);
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
        if (_currentSize > _maxSize)
        {
            _currentSize = _maxSize;
        }
        ChangeSize();
    }
}
