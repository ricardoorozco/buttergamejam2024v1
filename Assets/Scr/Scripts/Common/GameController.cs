using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int selectedLvl;

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
