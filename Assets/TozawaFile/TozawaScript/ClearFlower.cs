using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))] 
public class ClearFlower : MonoBehaviour
{
    ///// <summary>
    ///// インスペクターからGameManagerを指定してください
    ///// </summary>
    //[SerializeField] public GameManager gamemanager;//インスペクターからGameManagerを指定してください
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameManagerFlower.Instance != null)
            {
                GameManagerFlower.Instance.GameClear();
            }
            else
            {
                Debug.Log("Hit!");
            }
        }
    }
}
