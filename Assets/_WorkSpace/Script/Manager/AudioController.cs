using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    static AudioController instance { get; set; }

    [SerializeField]
    AudioSource _bGMSource;

    //#region BGMClip
    //[SerializeField]
    //AudioClip _titleBGM;
    //[SerializeField]
    //AudioClip _inGameBGM;
    //[SerializeField]
    //AudioClip _gOBGM;
    //[SerializeField]
    //AudioClip _gCBGM;
    //#endregion

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
    }
}
