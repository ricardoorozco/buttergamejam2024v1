using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private int lvl;

    private void Awake()
    {
        lvl = GameController.instance ? GameController.instance.GetSelectedLvl() : 0;
    }
}
