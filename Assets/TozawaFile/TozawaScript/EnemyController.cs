using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] public int _enemyHealthPoint = 100; //���̗̑�
    [SerializeField] int _rainDamage = 5; // �J�̉Η�
    [SerializeField] public float _deathDelay = 2f; //�΂�������܂ł̗]�C
    ParticleSystem _fireParticle = default; //���̃p�[�e�B�N��
    // Start is called before the first frame update
    void Start()
    {
        _fireParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSet();
        if (_enemyHealthPoint <= 0)//�̗͂��O�ȉ��ɂȂ�����
        {
            Extinguished();//���΂Ƃ����Ӗ��̉p�P��
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//�R���C�_�[��IsTrigger���`�F�b�N�����ĂȂ��Ƌ@�\���Ȃ���
    {
        if(collision.gameObject.tag == "Rain")//�������������I�u�W�F�N�g�̃^�O��Rain��������
        {
            _enemyHealthPoint -= _rainDamage;//����̃_���[�W���̗͂��猸�炷
            collision.gameObject.SetActive(false); //���������J�����ł�����
        }
        
    }
    protected virtual void UpdateSet() { }//���@�[�`�������\�b�h
    public void Extinguished()//����(�̗͂��O)���ꂽ�Ƃ��̏���
    {
        _fireParticle.Stop();//�p�[�e�B�N�����~����
        Destroy(gameObject,_deathDelay);//�]�C���c���ď���
    }
}
