using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    [SerializeField]
    private float _outAreaRange = 8f;
    private void FixedUpdate()
    {
        if (transform.position.x > _outAreaRange || transform.position.x < -_outAreaRange)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > _outAreaRange || transform.position.y < -_outAreaRange)
        {
            Destroy(gameObject);
        }
    }
}
