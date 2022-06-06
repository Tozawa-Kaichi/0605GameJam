using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }//インスタンス
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] Text _scoreText;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//ゲーム開始時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//ゲームクリア時に呼び出す処理
    public HPBar hpbar;
    int _score = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CursorCheck();
        
    }

    void CursorCheck()
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }// マウスを消す
    }
    public void GameStart()
    {
        Trigger.trigger = false;
        _onGameStart.Invoke();
    }
    public  void GameOver()
    {
        _score = hpbar.currentHp;
        StartCoroutine(WaitAnimation(_score));
    }
    
    public  IEnumerator WaitAnimation(int score)
    {
        Debug.Log("Waiting");
        yield return new WaitUntil(() => Trigger.trigger);
        //ここにアニメーションが完了してからしてほしいことを書く
        _onGameover.Invoke();
        _scoreText.text = _score.ToString("D8");
        
    }
}
