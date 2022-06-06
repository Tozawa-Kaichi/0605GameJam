using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))] 
public class ClearFlower : MonoBehaviour
{
    ///// <summary>
    ///// �C���X�y�N�^�[����GameManager���w�肵�Ă�������
    ///// </summary>
    //[SerializeField] public GameManager gamemanager;//�C���X�y�N�^�[����GameManager���w�肵�Ă�������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                Debug.Log("Hit!");
            }
        }
    }
}
