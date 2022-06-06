using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//�Q�[���J�n���ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//�Q�[���N���A���ɌĂяo������
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
        { Cursor.visible = false; }// �}�E�X������
    }
    public  void GameOver()
    {
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
        //�����ɃA�j���[�V�������������Ă��炵�Ăق������Ƃ�����
    }
}
