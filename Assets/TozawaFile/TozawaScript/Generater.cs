using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generater : MonoBehaviour
{
    [SerializeField] GameObject _spawnPrefab;// スポーンさせる対象
    [SerializeField] Transform [] _transformArray; // スポーン場所の配列
    [SerializeField] float _spawnInterval = 8f;// 初期インターバル
    [SerializeField] float _getFasterIntervalValue = 1f;// インターバルを短くする値
    [SerializeField] float _minIntervalTime = 2f;//インターバルの最低値
    [SerializeField] int _spawnCount = 5; // 何回スポーンさせたらインターバルを短くするか
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
        
        int random = Random.Range(0, _transformArray.Length); //配列の中からランダム
        
        _time += Time.deltaTime; //タイマー
        if (_time >= _spawnInterval) // 
        {
            _time = 0;
            _count++;
            Instantiate(_spawnPrefab, _transformArray[random]); // ランダムな配列内の場所に生成
            Debug.Log("SpawnSomethingAt"+random);
            if (_spawnInterval > _minIntervalTime && _count > _spawnCount) //インターバルが最小値じゃない 且つ 既定の回数スポーンさせたら
            {
                _spawnInterval -= _getFasterIntervalValue; // 既定の値で間隔を短くする
                Debug.Log("今のスポーン間隔は" + _spawnInterval);
                _count = 0;
            }
        }
    }
}
