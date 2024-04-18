using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void mouseOverFx()
    {
        LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }
    public void mouseOverFx2(float interval)
    {
        LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), interval).setLoopPingPong();
    }

    public void mouseExitFx()
    {
        LeanTween.cancel(this.gameObject);

        LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }
}
