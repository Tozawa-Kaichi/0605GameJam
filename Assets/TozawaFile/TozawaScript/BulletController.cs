using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//炎弾丸のスクリプト
public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10;
    [SerializeField] float _hydeLevel = 0;
    Rigidbody2D _rb2d = default;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < _hydeLevel)
        {
            Destroy(this.gameObject);
        }
    }
    
}
