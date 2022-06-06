using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] bool _right = true;
    // Start is called before the first frame update
    Rigidbody2D m_rb = default;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_right)
        {
            m_rb.velocity = Vector2.right;
        }
        else
        {
            m_rb.velocity = Vector2.left;
        }
    }
}
