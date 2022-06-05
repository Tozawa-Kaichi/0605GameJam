using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyController : EnemyController
{
    //�p�����Update�i�jStart�i�j���j�ƌp�����̓����֐��̏������㏑�������
    //�ǉ��ŏ��������Ƃ��̓��@�[�`�������\�b�h���g��
    [SerializeField] GameObject _bulletPrefab = default;//���˂��鉊�̃v���n�u
    [SerializeField] GameObject _barrel = default; // ���ˌ�
    [SerializeField] float _shootInterval = 4f; // ���ˊԊu
    [SerializeField]int  angle;
    Transform _barrelTransform = default; //�o�����̈ʒu
    bool _right = true;
    float _time = 0;
    // Start is called before the first frame update
    
    protected override void UpdateSet()//�h�����̃A�b�v�f�[�g�ɏ���������"������"
    {
        Shoot();
        LRcheck();
        if(_right == true)
        {
            _barrel.transform.eulerAngles = new Vector3(0,0,-angle) ;
        }
        else
        {
            _barrel.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
    void Shoot()//�e����������
    {
        _barrelTransform = _barrel.transform;
        _time += Time.deltaTime;
        if(_time >= _shootInterval)
        {
            _time = 0;
            Instantiate(_bulletPrefab,_barrelTransform.position,_barrel.transform.rotation);
        }
    }
    void LRcheck()
    {
        if (transform.position.x < 0)
        {
            _right = true;
        }
        else
        {
            _right = false;
        }
    }
}
