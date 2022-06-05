using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCon : MonoBehaviour
{
    [SerializeField] float _hydeLevelofXLeft = 0;
    [SerializeField] float _hydeLevelofXRight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _hydeLevelofXLeft || transform.position.x > _hydeLevelofXRight)
        {
            Destroy(this.gameObject);
        }
    }
}
