using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] AudioSource death;
    [SerializeField] public int _enemyHealthPoint = 100; //炎の体力
    [SerializeField] int _rainDamage = 5; // 雨の火力
    [SerializeField] public float _deathDelay = 2f; //火が消えるまでの余韻
    [SerializeField] protected CountText _count = default;
    ParticleSystem _fireParticle = default; //炎のパーティクル
    [SerializeField]
    CubeMove _cubeMove = default;

    void Start()
    {
        _fireParticle = GetComponent<ParticleSystem>();
        if (_count)
        {
            _count.Count = _enemyHealthPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSet();
        if (_enemyHealthPoint <= 0)//体力が０以下になったら
        {
            Extinguished();//鎮火という意味の英単語
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//コライダーのIsTriggerがチェック入ってないと機能しないよ
    {
        if(collision.gameObject.tag == "Rain")//もし当たったオブジェクトのタグがRainだったら
        {
            if (death) { death.Play(); }
            
            _enemyHealthPoint -= _rainDamage;//既定のダメージ分体力から減らす
            if (_count)
            {
                _count.Count = _enemyHealthPoint;
            }
            collision.gameObject.SetActive(false); //当たった雨を消滅させる
        }
        
    }
    protected virtual void UpdateSet() { }//ヴァーチャルメソッド
    public void Extinguished()//消化(体力が０)されたときの処理
    {
        if (_cubeMove)
        {
            _cubeMove.StopMove();
        }
        _fireParticle.Stop();//パーティクルを停止する
        Destroy(gameObject,_deathDelay);//余韻を残して消滅
    }
}
