using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyController : EnemyController
{
    //継承先はUpdate（）Start（）を核と継承元の同じ関数の処理が上書きされる
    //追加で書きたいときはヴァーチャルメソッドを使う
    [SerializeField] GameObject _bulletPrefab = default;//発射する炎のプレハブ
    [SerializeField] GameObject _barrel = default; // 発射口
    [SerializeField] float _shootInterval = 4f; // 発射間隔
    Transform _barrelTransform = default; //バレルの位置
    float _time = 0;
    // Start is called before the first frame update
    
    protected override void UpdateSet()//派生元のアップデートに処理を書き"加える"
    {
        Shoot();
    }
    void Shoot()//弾を撃ち放つ
    {
        _barrelTransform = _barrel.transform;
        _time += Time.deltaTime;
        if(_time >= _shootInterval)
        {
            _time = 0;
            Instantiate(_bulletPrefab,_barrelTransform.position,_barrel.transform.rotation);
        }
    }
}
