using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int selectedLvl;

    public bool isPaused = false;

    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetSelectedLvl(int lvl)
    {
        selectedLvl = lvl;
    }

    public int GetSelectedLvl()
    {
        return selectedLvl;
    }
}
