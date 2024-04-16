using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvlPathInfo : MonoBehaviour
{
    //UI
    [SerializeField]
    private TMP_Text lvlUI;
    [SerializeField]
    private Image[] starsUI;
    [SerializeField]
    private TMP_Text scoreUI;
    [SerializeField]
    private Image lockUI;

    [SerializeField]
    private Sprite unlockSprite;
    [SerializeField]
    private Sprite lockSprite;
    [SerializeField]
    private Sprite yellowStarSprite;
    [SerializeField]
    private Sprite greyStarSprite;

    //state
    [SerializeField]
    private int lvl;
    [SerializeField]
    private bool unlock;
    [SerializeField]
    private bool complete;
    [SerializeField]
    private LvlPathInfo[] unlockLvls;
    [SerializeField]
    private int stars = 0;
    [SerializeField]
    private int score = 0;

    private void Awake()
    {
        updateStatus();
    }

    void Start()
    {
        GameController.instance.isGameOver = false;
    }

    public void SetUnlock(bool unlock)
    {
        this.unlock = unlock;
        lockUI.sprite = unlockSprite;
        lvlUI.text = lvl.ToString();
        updateStatus();
    }

    private void updateStatus()
    {

        Stage stage = DB.Instance.GetStage(lvl);
        Stage preStage = null;

        if (lvl - 1 > 0)
        {
            preStage = DB.Instance.GetStage(lvl - 1);
        }

        if (stage != null)
        {
            unlock = stage.unlock;
            if (preStage != null)
            {
                unlock = preStage.complete;
            }
            complete = stage.complete;
            stars = stage.stars;
            score = stage.score;
        }

        if (unlock || preStage == null)
        {
            lvlUI.text = lvl.ToString();
            scoreUI.text = score.ToString();
            lockUI.sprite = unlockSprite;

            if (complete)
            {
                for (int i = 0; i < stars; i++)
                {
                    starsUI[i].sprite = yellowStarSprite;
                }

                for (int i = 0; i < unlockLvls.Length; i++)
                {
                    unlockLvls[i].SetUnlock(true);
                }
            }
            else
            {
                scoreUI.text = "0";

                for (int i = 0; i < starsUI.Length; i++)
                {
                    starsUI[i].sprite = greyStarSprite;
                }

                for (int i = 0; i < unlockLvls.Length; i++)
                {
                    unlockLvls[i].SetUnlock(false);
                }
            }
        }
        else
        {
            lvlUI.text = "";
            lockUI.sprite = lockSprite;
            scoreUI.text = "0";

            for (int i = 0; i < starsUI.Length; i++)
            {
                starsUI[i].sprite = greyStarSprite;
            }

            for (int i = 0; i < unlockLvls.Length; i++)
            {
                if (unlockLvls[i])
                {
                    unlockLvls[i].unlock = false;
                }
            }
        }
    }

    public void SetLvlGameController()
    {
        GameController.instance.SetSelectedLvl(lvl);
    }
}
