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
            DontDestroyOnLoad(this.gameObject); // ?¸?Š¤?„´?Š¤ê°? ì¡´ì¬?•˜ì§? ?•Š?œ¼ë©? ?ŒŒê´´ë˜ì§? ?•Š?Œ
        }
        else
        {
            Destroy(this.gameObject); // ?´ë¯? ?¸?Š¤?„´?Š¤ê°? ì¡´ì¬?•˜ë©? ?ŒŒê´?
        }
    }

    public void FlappyBird()
    {
        SceneManager.LoadScene(Constant.MiniGames.FlappyBird.SCENE_NAME);
    }
}
