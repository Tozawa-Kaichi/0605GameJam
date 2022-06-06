using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    bool _right = true;
    // Start is called before the first frame update
    Rigidbody2D m_rb = default;
    [SerializeField] float _speed = 1f;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        RLCheck();
        Move();
    }
    void RLCheck()
    {
        if (transform.position.x < 0)
        {
            _right = true;
        }
        else
        {
            _right = false;
        }
    }
    private void Move()
    {
        if (_right)
        {
            m_rb.velocity = Vector2.right * _speed;
        }
        else
        {
            m_rb.velocity = Vector2.left * _speed;
        }
    }
}
