using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerFlower : MonoBehaviour
{
    public CloudController raincount;
    public static GameManagerFlower Instance { get; private set; }//インスタンス
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] Text _rainFallText;
    [SerializeField] Text _scoreText;
    [SerializeField] float _restartWaitTime = 1f;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//ゲーム開始時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//ゲームオーバー時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear = null;//ゲームオーバー時に呼び出す処理
    /// <summary>ランキングシステムのプレハブ</summary>
    [SerializeField] GameObject m_rankingPrefab;
    //[SerializeField] GameObject player;
    public HPBar hpbar;
    int _score = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CursorCheck();
        GameStart();
    }
    void Update()
    {
        if(FireCheck.dead)
        {
            FireCheck.dead = false;
            GameOver();
        }
        _rainFallText.text = "降雨量:"+(raincount.RainCount * 100).ToString();

    }

    void CursorCheck()// マウスを消す
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }
    }
    public void GameStart()//ゲーム開始・リスタート時に呼ばれる関数
    {
        //Trigger.trigger = false;
        _onGameStart.Invoke();
        
    }
    public  void GameOver()//失敗時呼ばれる 条件 花炎上
    {
        StartCoroutine(WaitAnimation(0));
        
    }
    public void GameClear()// 成功時呼ばれる 条件 花接触
    {
        
        _score = hpbar.currentHp;//どれだけ花をのばしたか
        Debug.Log(_score);
        StartCoroutine(WaitAnimation(_score));//をスコアにする
    }
    
    public  IEnumerator WaitAnimation(int score)
    {
        Debug.Log("Waiting");
        if (score == 0)
        {
            _onGameover.Invoke();
        }
        else if(score > 0)
        {
            _onGameClear.Invoke();
            _scoreText.text = _score.ToString() + "点！オメデト！";
        }
        yield return new WaitForSeconds(3f);
        // ランキングシステムを発動させる
        var ranking =  Instantiate(m_rankingPrefab);
        ranking.GetComponent<RankingManager>().SetScoreOfCurrentPlay(_score);
        //yield return new WaitUntil(() =>  );
        ////ここにアニメーションが完了してからしてほしいことを書く
        //Invoke(nameof(LoadScene), _restartWaitTime); //自動リスタート
    }
    public static string LoadScene()
    {
        SceneManager.LoadScene(0);
        return "";
    }
}
