using UnityEngine;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int selectedLvl;

    public bool isPaused = false;

    public bool isGameOver = false;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup turretMixer;
    public AudioMixerGroup enemyMixer;

    public int maxEnemyWeaponsSounds = 5;
    public int maxTurretWeaponsSounds = 5;
    public int totalEnemyWeaponsSounds = 0;
    public int totalTurretWeaponsSounds = 0;

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

    public void PauseGame(int timeScale)
    {
        isPaused = timeScale > 0 ? false : true;
        Time.timeScale = timeScale;
    }
}
