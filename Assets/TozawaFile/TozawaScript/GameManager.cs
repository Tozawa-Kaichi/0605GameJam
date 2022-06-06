using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }//インスタンス
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] Text _scoreText;
    [SerializeField] float _restartWaitTime = 1f;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//ゲーム開始時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//ゲームオーバー時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear = null;//ゲームオーバー時に呼び出す処理
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
    }

    void CursorCheck()// マウスを消す
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }
    }
    public void GameStart()//ゲーム開始・リスタート時に呼ばれる関数
    {
        Trigger.trigger = false;
        _onGameStart.Invoke();
        
    }
    public  void GameOver()//失敗時呼ばれる 条件 花炎上
    {
        StartCoroutine(WaitAnimation(0));
        
    }
    public void GameClear()// 成功時呼ばれる 条件 花接触
    {
        _score = hpbar.currentHp;//どれだけ花をのばしたか
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
            _scoreText.text = _score.ToString("D8");
        }
        yield return new WaitUntil(() => Trigger.trigger);
        //ここにアニメーションが完了してからしてほしいことを書く
        Invoke(nameof(LoadScene), _restartWaitTime); //自動リスタート
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
