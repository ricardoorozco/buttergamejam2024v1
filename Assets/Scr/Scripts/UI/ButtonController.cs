using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void mouseOverFx()
    {
        LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
    }

    public void mouseExitFx()
    {
        LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), 0.2f);
    }
}
