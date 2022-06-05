using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CloudController cloud = collision.GetComponent<CloudController>();
            if (cloud != null)
            {
                cloud.StartThundercloud();

            }
            Destroy(gameObject);
        }
    }
}
