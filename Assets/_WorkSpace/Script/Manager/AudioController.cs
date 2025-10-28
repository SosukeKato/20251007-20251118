using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _bGMSource;

    #region BGMClip
    [SerializeField]
    AudioClip _titleBGM;
    [SerializeField]
    AudioClip _inGameBGM;
    [SerializeField]
    AudioClip _gOBGM;
    [SerializeField]
    AudioClip _gCBGM;
    #endregion

    #region SEClip
    [SerializeField]
    AudioClip _jumpSE;
    [SerializeField]
    AudioClip _isGroundSE;
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _bGMSource.Stop();
        if (SceneManager.GetActiveScene().name == "00_TitleScene")
        {
            _bGMSource.clip = _titleBGM;
            _bGMSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "01_PlayScene")
        {
            _bGMSource.clip = _inGameBGM;
            _bGMSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "02_GameOverScene")
        {
            _bGMSource.clip = _gOBGM;
            _bGMSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "03_GameCearScene")
        {
            _bGMSource.clip = _gCBGM;
            _bGMSource.Play();
        }
    }
}
