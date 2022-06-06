using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//ゲーム開始時に呼び出す処理
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//ゲームクリア時に呼び出す処理
    int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        CursorCheck();
        _onGameStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CursorCheck()
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }// マウスを消す
    }
    public void TitleLoad(int score)
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
