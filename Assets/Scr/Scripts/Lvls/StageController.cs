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
    private TMP_Text totalScoreText;
    [SerializeField]
    private TMP_Text currentSupplyText;
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
    [SerializeField]
    private float delayForNextWave = 20;
    private float currentDelayForNextWave = 0;
    private int currentScore = 0;
    [SerializeField]
    private int currentSupply = 0;
    private float currentTime = 0;
    [SerializeField]
    private int portalEnableEachWave = 1;

    [SerializeField]
    private List<EnemySpawnController> portals;

    private void Awake()
    {
        EndGameUI.SetActive(false);

        currentDelayForNextWave = delayForNextWave;
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        currentTimeText.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        currentScoreText.text = currentScore.ToString();
        currentWaveText.text = currentWave.ToString();
        nextWaveTimeText.text = currentDelayForNextWave.ToString("F0");
        currentSupplyText.text = currentSupply.ToString();
    }

    private void Update()
    {
        if (GameController.instance.isGameOver)
        {
            return;
        }

        currentTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        currentTimeText.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        currentDelayForNextWave -= Time.deltaTime;
        nextWaveTimeBar.value = currentDelayForNextWave / delayForNextWave;
        nextWaveTimeText.text = currentDelayForNextWave.ToString("F0");

        currentScoreText.text = currentScore.ToString();
        currentSupplyText.text = currentSupply.ToString();

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
        delayForNextWave = delayForNextWave - 1 > 5 ? delayForNextWave - 1 : 5;

        for (int i = 0; i < portals.Count; i++)
        {
            float newTimeDelay = portals[i].timeDelaySpawn * currentWave / 100;
            portals[i].timeDelaySpawn = portals[i].timeDelaySpawn - newTimeDelay < 0 ? 0 : portals[i].timeDelaySpawn - newTimeDelay;
        }

        int portalsEnables = currentWave % portalEnableEachWave;

        if (portalsEnables == 0)
        {
            portalsEnables = (currentWave / portalEnableEachWave) + 1;

            if (portalsEnables <= portals.Count)
            {
                for (int i = 0; i < portalsEnables; i++)
                {
                    portals[i].enabled = true;
                }
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
        stage.score = currentScore + currentSupply;

        DB.Instance.SetStage(stage);
        DB.Instance.Save();
    }


    public void endGame()
    {
        EndGameUI.SetActive(true);

        LeanTween.delayedCall(2, () =>
        {
            LeanTween.value(0, currentScore, 2).setOnUpdate((float val) =>
            {
                currentScoreText.text = (currentScore-(int)val).ToString();
                totalScoreText.text = ((int)val).ToString();
            });
            LeanTween.delayedCall(3, () =>
            {
                LeanTween.value(0, currentSupply, 2).setOnUpdate((float val) =>
                {
                    currentSupplyText.text = (currentSupply - (int)val).ToString();
                    totalScoreText.text = (currentScore+(int)val).ToString();
                });
            });
        });
    }

    public void addScore(int score)
    {
        currentScore += score;
    }

    public void addSupply(int score)
    {
        currentSupply += score;
    }

    public int getSupply()
    {
        return currentSupply;
    }

    public int getWave()
    {
        return currentWave;
    }
}
