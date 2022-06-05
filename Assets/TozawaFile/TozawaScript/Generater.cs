using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generater : MonoBehaviour
{
    [SerializeField] GameObject _spawnPrefab;// �X�|�[��������Ώ�
    [SerializeField] Transform [] _transformArray; // �X�|�[���ꏊ�̔z��
    [SerializeField] float _spawnInterval = 8f;// �����C���^�[�o��
    [SerializeField] float _getFasterIntervalValue = 1f;// �C���^�[�o����Z������l
    [SerializeField] float _minIntervalTime = 2f;//�C���^�[�o���̍Œ�l
    [SerializeField] int _spawnCount = 5; // ����X�|�[����������C���^�[�o����Z�����邩
    float _time = 0;
    int _count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomGenerate();
    }
    void RandomGenerate()
    {
        
        int random = Random.Range(0, _transformArray.Length); //�z��̒����烉���_��
        
        _time += Time.deltaTime; //�^�C�}�[
        if (_time >= _spawnInterval) // 
        {
            _time = 0;
            _count++;
            Instantiate(_spawnPrefab, _transformArray[random]); // �����_���Ȕz����̏ꏊ�ɐ���
            Debug.Log("SpawnSomethingAt"+random);
            if (_spawnInterval > _minIntervalTime && _count > _spawnCount) //�C���^�[�o�����ŏ��l����Ȃ� ���� ����̉񐔃X�|�[����������
            {
                _spawnInterval -= _getFasterIntervalValue; // ����̒l�ŊԊu��Z������
                Debug.Log("���̃X�|�[���Ԋu��" + _spawnInterval);
                _count = 0;
            }
        }
    }
}
