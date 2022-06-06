using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }//�C���X�^���X
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] Text _scoreText;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//�Q�[���J�n���ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//�Q�[���N���A���ɌĂяo������
    public HPBar hpbar;
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
        { Cursor.visible = false; }// �}�E�X������
    }
    public  void GameOver()
    {
        _score = hpbar.currentHp;
        StartCoroutine(WaitAnimation(_score));

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
        _onGameover.Invoke();
        _scoreText.text = _score.ToString("D8");
        
    }
}
