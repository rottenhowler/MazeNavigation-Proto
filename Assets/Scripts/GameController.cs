using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public static GameController Instance { get { return instance; } }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [SerializeField] private GameObject finishUi;

    public void ExitReached()
    {
        finishUi.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Maze");
    }
}
