using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    //UI
    [SerializeField]
    private TMP_Text currentTimeText;
    [SerializeField]
    private TMP_Text currentScoreText;
    [SerializeField]
    private TMP_Text currentWaveText;
    [SerializeField]
    private TMP_Text nextWaveTimeText;
    [SerializeField]
    private Slider nextWaveTimeBar;
    [SerializeField]
    private GameObject EndGameUI;

    [SerializeField]
    private int currentWave = 1;
    private float delayForNextWave = 20;
    private float currentDelayForNextWave = 0;
    private int currentScore = 0;
    private float currentTime = 0;
    [SerializeField]
    private int portalEnableEachWave = 1;

    [SerializeField]
    private List<EnemySpawnController> portals;

    private void Awake()
    {
        EndGameUI.SetActive(false);

        currentDelayForNextWave = delayForNextWave;
        currentTimeText.text = currentTime.ToString("F0");
        currentScoreText.text = currentScore.ToString();
        currentWaveText.text = currentWave.ToString();
        nextWaveTimeText.text = currentDelayForNextWave.ToString("F0");
    }

    private void Update()
    {
        if (GameController.instance.isGameOver)
        {
            return;
        }

        currentTime += Time.deltaTime;
        currentTimeText.text = currentTime.ToString("F0");
        currentDelayForNextWave -= Time.deltaTime;
        nextWaveTimeBar.value = currentDelayForNextWave / delayForNextWave;
        nextWaveTimeText.text = currentDelayForNextWave.ToString("F0");

        currentScoreText.text = currentScore.ToString();

        if (currentDelayForNextWave < 0)
        {
            currentWave++;
            currentWaveText.text = currentWave.ToString();
            currentDelayForNextWave = delayForNextWave;
            nextWaveTimeText.text = currentDelayForNextWave.ToString("F0");

            enablePortal();
        }
    }

    private void enablePortal()
    {
        if (currentWave <= portals.Count && currentWave % portalEnableEachWave == 0)
        {
            for (int i = 0; i < (currentWave / portalEnableEachWave) + 1; i++)
            {
                portals[i].enabled = true;
            }
        }
    }

    public void saveGame()
    {
        Stage stage = DB.Instance.GetStage(GameController.instance.GetSelectedLvl());

        stage.unlock = true;
        stage.stars = currentWave >= stage.lvl ? 3
                    : currentWave >= stage.lvl / 2 ? 2
                    : currentWave > 1 ? 1
                    : 0;
        stage.complete = stage.stars > 1;
        stage.score = currentScore;

        DB.Instance.SetStage(stage);
        DB.Instance.Save();
    }


    public void endGame()
    {
        EndGameUI.SetActive(true);
    }
}
