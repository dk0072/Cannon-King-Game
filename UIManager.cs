using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using LocalStorage;

public class UIManager : MonoBehaviour
{
    //public static Singleton
    public static UIManager instance;

    [Tooltip("UI panel Controll")]
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject GameWonUI;
    [SerializeField] GameObject ChapterClearUI;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject Panel1, Panel2, PlayButton;
    [SerializeField] GameObject SettingUI;
    [SerializeField] GameObject SpinUI;
    [SerializeField] GameObject StartGameUI;
    [SerializeField] GameObject ShootButton;
    [SerializeField] GameObject InGameUI;
    [SerializeField] GameObject mainGameComponent;
    [SerializeField] GameObject settingUI;

    [Tooltip("Music And Audio Controll")]
    [SerializeField] GameObject _MusicOn, _MusicOff, _AudioOn, _AudioOff;

    [Tooltip("Animation Controll")]
    [SerializeField] Animator _arrowAnim;
    [SerializeField] Animator _vanish;


    [Tooltip("Game Progress Controll")]
    [SerializeField] Slider ProgressBar;

    [Tooltip("Spin Controll")]
    [SerializeField] GameObject _Spin;
    [SerializeField] GameObject _SpinButton;

    [SerializeField] Text reward;
   
    [SerializeField] Button _playSpin;

    [HideInInspector] public bool IsGameOver = false;
    [HideInInspector] public bool isGameWon = false;


    bool canSpin = false;
    float spinSpeed;

    [HideInInspector] public bool canStart = false;

    private void Start()
    {
        spinSpeed = Random.Range(2, 8);
        instance = this;
    }


    private void Update()
    {
        if(ProgressBar.value == 100 && InGameUI.activeSelf)
        {
            ChapterClear();
            CannonMovement.instance.canMove = false;
        }

        if (canSpin)
        {
            _Spin.transform.Rotate(0, 0, spinSpeed);

        }
    }

    public void GameOver()
    {
        StoneSpawner.instance.canSpawn = false;
        CannonMovement.instance.canMove = false;
        IsGameOver = true;
        InGameUI.SetActive(false);
        mainGameComponent.SetActive(true);
        ShootButton.SetActive(false);
        GameOverUI.SetActive(true);
        StartCoroutine(GameOverAnim(0));
    }


    public void Restart()
    {    
        StartCoroutine(GameOverAnim(1));    
    }

    public void GameWon()
    {
        CannonMovement.instance.canMove = false;
       // CannonMovement.instance.gameObject.SetActive(false);
        isGameWon = true;
        ShootButton.SetActive(false);
        GameOverUI.SetActive(false);
        GameWonUI.SetActive(true);

        if(SaveUserData.instance.getChapterName()==1 && SaveUserData.instance.getLevelName() <= 3)
        {
            SaveUserData.instance.setLevelName(SaveUserData.instance.getLevelName()+1);
        }

    }


    public void ChapterClear()
    {
        ShootButton.SetActive(false);
        GameOverUI.SetActive(false);
        ChapterClearUI.SetActive(true);
    }

    public void PauseGame()
    {
        ShootButton.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }


    public void ResumeGame()
    {
        ShootButton.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }


    public void AddProgress(float value)
    {
        ProgressBar.value += value;

    }


    public void Setting()
    {
        if (SettingUI.activeSelf)
        {
            _SpinButton.SetActive(true);
            SettingUI.SetActive(false);
        }
        else
        {
            _SpinButton.SetActive(false);
            SettingUI.SetActive(true);
        }
    }


    public void MusicControl(int id)
    {
        if (id == 0)
        {
            _MusicOff.SetActive(true);
            _MusicOn.SetActive(false);
        }
        if (id == 1)
        {
            _MusicOn.SetActive(true);
            _MusicOff.SetActive(false);
        }
    }


    public void AudioControl(int id)
    {
        if (id == 0)
        {
            _AudioOff.SetActive(true);
            _AudioOn.SetActive(false);
        }
        if (id == 1)
        {
            _AudioOn.SetActive(true);
            _AudioOff.SetActive(false);
        }
    }


    public void PlaySpin()
    {
        _arrowAnim.SetBool("spinArrow", true);
        StartCoroutine(_PlaySpin());
        canSpin = true;
        _playSpin.interactable = false;
    }


    public void OpenSpin()
    {
        SpinUI.SetActive(true);
        canStart = false;
        ShootButton.SetActive(false);
    }


    public void CloseSpin()
    {
        SpinUI.SetActive(false);
       ShootButton.SetActive(true);

    }


    public void StartGame()
    {
        settingUI.SetActive(false);
        ShootButton.SetActive(true);
        mainGameComponent.SetActive(true);
        InGameUI.SetActive(true);
        _vanish.SetBool("vanish", true);
        canStart = true;
        StartGameUI.SetActive(false);
    }








    //Coroutines

    IEnumerator GameOverAnim(int type)
    {
        if(type == 0)
        {
            yield return new WaitForSeconds(0.2f);
            Panel1.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            Panel2.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            PlayButton.SetActive(true);
        }

        if (type == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }
    
  

    IEnumerator _PlaySpin()
    {
        if (spinSpeed > 0)
        {
            yield return new WaitForSeconds(0.7f);
            spinSpeed -= 0.2f;
        }

        if (spinSpeed > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.9f));
            spinSpeed -= 0.3f;
            _arrowAnim.speed = 0.7f;
        }
            
            yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
            spinSpeed -= 0.4f;
            yield return new WaitForSeconds(0.5f);
            spinSpeed -= 0.5f;
            yield return new WaitForSeconds(0.5f);
            spinSpeed -= 0.6f;

        if (spinSpeed > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
            spinSpeed -= 0.7f;
            
        }
             _arrowAnim.speed = 0.4f;
             yield return new WaitForSeconds(0.4f);
            spinSpeed -= 0.8f;
            yield return new WaitForSeconds(Random.Range(0.2f, 0.8f));
            spinSpeed -= 0.9f;
            _arrowAnim.speed = 0.2f;

        if (spinSpeed > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));
            spinSpeed -= 1f;
            _arrowAnim.speed = 0.1f;
            yield return new WaitForSeconds(0.3f);
            _arrowAnim.speed = 0;
        }
          
        _arrowAnim.SetBool("spinArrow", false);
        canSpin = false;
        reward.text = SpinArrow.instance.getReward().name;

    }

}
