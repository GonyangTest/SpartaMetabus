using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // ?��?��?��?���? 존재?���? ?��?���? ?��괴되�? ?��?��
        }
        else
        {
            Destroy(this.gameObject); // ?���? ?��?��?��?���? 존재?���? ?���?
        }
    }

    public void FlappyBird()
    {
        SceneManager.LoadScene(Constant.MiniGames.FlappyBird.SCENE_NAME);
    }
}
