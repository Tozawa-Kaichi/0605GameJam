using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }//インスタンス
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//ゲーム開始時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//ゲームクリア時に呼び出す処理
    int _score = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CursorCheck();
        _onGameStart.Invoke();
        Trigger.trigger = false;
    }

    void CursorCheck()
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }// マウスを消す
    }
    public  void GameOver()
    {
        //_score =HPBar;
        _onGameover.Invoke();

    }
    public void Some(int score)
    {
        StartCoroutine(WaitAnimation(score));
    }
    public  IEnumerator WaitAnimation(int score)
    {
        Debug.Log("Waiting");
        yield return new WaitUntil(() => Trigger.trigger);
        //ここにアニメーションが完了してからしてほしいことを書く
    }
}
