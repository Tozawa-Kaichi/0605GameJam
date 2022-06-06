using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCheck : MonoBehaviour
{
    public static bool dead = false;
    [SerializeField]
    private int _maxLife = 1;
    [SerializeField]
    private ParticleSystem _deadParticle = default;
    [SerializeField]
    private PlantController _plantController = default;
    private int _currentLife = default;
    private void Start()
    {
        _currentLife = _maxLife;
        _plantController.StartControl();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            AddDamage();
        }
    }
    private void AddDamage()
    {
        _currentLife--;
        if (_currentLife == 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        _deadParticle.Play();
        _plantController?.StopControl();
        dead = true;
    }
}
