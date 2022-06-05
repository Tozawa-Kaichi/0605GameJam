using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RainController : MonoBehaviour
{
    [SerializeField]
    private float _hydeLevel = -2f;
    [SerializeField]
    private Rigidbody2D _rigidbody = default;
    private void FixedUpdate()
    {
        if (transform.position.y < _hydeLevel)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
