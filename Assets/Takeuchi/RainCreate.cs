using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCreate : MonoBehaviour
{
    private const int CREAT_COUNT = 200;
    [SerializeField]
    private Transform _leftRainRine = default;
    [SerializeField]
    private Transform _rightRainRine = default;
    [SerializeField]
    private int _rainCount = 10;
    [SerializeField]
    private float _rainSpan = 0.1f;
    [SerializeField]
    private GameObject _rainPrefab = null;
    [SerializeField]
    private ParticleSystem _rainParticleSystem = null;
    private float _rainTimer = 0;
    private List<GameObject> _rains = default;
    private bool _isRaining = false;
    private void Start()
    {
        CreateRain();
    }
    private void Update()
    {
        if (!_isRaining) { return; }
        _rainTimer += Time.deltaTime;
        if (_rainTimer > _rainSpan)
        {
            _rainTimer = 0;
            MakeItRain();
        }
    }
    private void CreateRain()
    {
        _rains = new List<GameObject>();
        for (int i = 0; i < CREAT_COUNT; i++)
        {
            var rain = Instantiate(_rainPrefab);
            rain.transform.SetParent(transform);
            rain.SetActive(false);
            _rains.Add(rain);
        }
    }
    private void MakeItRain()
    {
        for (int i = 0; i < _rainCount; i++)
        {
            var rain = GetRain();
            var rainLine = Random.Range(_leftRainRine.position.x, _rightRainRine.position.x);
            var rainPos = transform.position;
            rainPos.x = rainLine;
            rain.transform.position = rainPos;
            rain.gameObject.SetActive(true);
        }
    }
    private GameObject GetRain()
    {
        foreach (var instanceRain in _rains)
        {
            if (instanceRain.activeInHierarchy)
            {
                continue;
            }
            return instanceRain;
        }
        var rain = Instantiate(_rainPrefab);
        rain.transform.SetParent(transform);
        rain.SetActive(false);
        return rain;
    }
    public void StartRain()
    {
        _isRaining = true;
        if (_rainParticleSystem)
        {
            _rainParticleSystem.Play();
        }
    }
    public void StopRain()
    {
        _isRaining = false; 
        if (_rainParticleSystem)
        {
            _rainParticleSystem.Stop();
        }
    }
    public void ChangeRainCount(int count)
    {
        _rainCount = count;
    }
}
