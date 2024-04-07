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
    private float lvl;
    [SerializeField]
    private bool unlock;
    [SerializeField]
    private bool complete;
    [SerializeField]
    private LvlPathInfo[] unlockLvls;
    [SerializeField]
    private int stars = 0;

    private void Awake()
    {
        if (unlock)
        {
            lvlUI.text = lvl.ToString();
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
            } else
            {
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

            for (int i = 0; i < starsUI.Length; i++)
            {
                starsUI[i].sprite = greyStarSprite;
            }

            for (int i = 0; i < unlockLvls.Length; i++)
            {
                unlockLvls[i].unlock = false;
            }
        }
    }

    public void SetUnlock(bool unlock)
    {
        this.unlock = unlock;
        lockUI.sprite = unlockSprite;
        lvlUI.text = lvl.ToString();
    }
}
