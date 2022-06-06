using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderItem : MonoBehaviour
{
    [SerializeField]
    AudioClip audio = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (audio)
            {
                AudioSource.PlayClipAtPoint(audio, transform.position);
            }
            CloudContact cloud = collision.GetComponent<CloudContact>();
            if (cloud != null)
            {
                cloud.StartThundercloud();

            }
            Destroy(gameObject);
        }
    }
}
