using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] int _enemyHealthPoint = 100;
    [SerializeField] int _rainDamage = 5;
    [SerializeField] float _deathDelay = 2f;
    ParticleSystem _fireParticle = default;
    // Start is called before the first frame update
    void Start()
    {
        _fireParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyHealthPoint <= 0)
        {
            Extinguished();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rain")
        {
            _enemyHealthPoint -= _rainDamage;
            Destroy(collision.gameObject);
        }
        
    }
    void Extinguished()//Á‰»‚³‚ê‚½‚Æ‚«‚Ìˆ—
    {
        _fireParticle.Stop();
        Destroy(this.gameObject,_deathDelay);
    }
}
