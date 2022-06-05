using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouditemu : MonoBehaviour
{
    [SerializeField]
    private float _addSize = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CloudContact cloud = collision.GetComponent<CloudContact>();
            if (cloud != null)
            {
                cloud.AddSize(_addSize);
                
            }
            Destroy(gameObject);

        }
    }
}
