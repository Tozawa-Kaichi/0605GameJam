using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerFlower : MonoBehaviour
{
    public CloudController raincount;
    public static GameManagerFlower Instance { get; private set; }//�C���X�^���X
    [SerializeField] bool _hideMousecCursor = false;
    [SerializeField] Text _rainFallText;
    [SerializeField] Text _scoreText;
    [SerializeField] float _restartWaitTime = 1f;
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;//�Q�[���J�n���ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _onGameover = null;//�Q�[���I�[�o�[���ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _onGameClear = null;//�Q�[���I�[�o�[���ɌĂяo������
    /// <summary>�����L���O�V�X�e���̃v���n�u</summary>
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
        _rainFallText.text = "�~�J��:"+(raincount.RainCount * 100).ToString();

    }

    void CursorCheck()// �}�E�X������
    {
        if (_hideMousecCursor)
        { Cursor.visible = false; }
    }
    public void GameStart()//�Q�[���J�n�E���X�^�[�g���ɌĂ΂��֐�
    {
        //Trigger.trigger = false;
        _onGameStart.Invoke();
        
    }
    public  void GameOver()//���s���Ă΂�� ���� �ԉ���
    {
        StartCoroutine(WaitAnimation(0));
        
    }
    public void GameClear()// �������Ă΂�� ���� �ԐڐG
    {
        
        _score = hpbar.currentHp;//�ǂꂾ���Ԃ��̂΂�����
        Debug.Log(_score);
        StartCoroutine(WaitAnimation(_score));//���X�R�A�ɂ���
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
            _scoreText.text = _score.ToString() + "�_�I�I���f�g�I";
        }
        yield return new WaitForSeconds(3f);
        // �����L���O�V�X�e���𔭓�������
        var ranking =  Instantiate(m_rankingPrefab);
        ranking.GetComponent<RankingManager>().SetScoreOfCurrentPlay(_score);
        //yield return new WaitUntil(() =>  );
        ////�����ɃA�j���[�V�������������Ă��炵�Ăق������Ƃ�����
        //Invoke(nameof(LoadScene), _restartWaitTime); //�������X�^�[�g
    }
    public static string LoadScene()
    {
        SceneManager.LoadScene(0);
        return "";
    }
}
