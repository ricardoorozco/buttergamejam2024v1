using UnityEngine;

public class EnemyFollowPathController : MonoBehaviour
{
    [SerializeField]
    private float timeDelay;
    [SerializeField]
    private Transform nextPoint;

    public void SetNextPoint(Transform point)
    {
        this.nextPoint = point;
    }

    public void SetTimeDelay(float timeDelay)
    {
        this.timeDelay = timeDelay;
    }

    public void goToNextPoint()
    {
        LeanTween.move(gameObject, this.nextPoint.position, timeDelay).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
            this.nextPoint = this.nextPoint.GetComponent<PathInfo>().GetNextPoint();
            if (this.nextPoint)
            {
                goToNextPoint();
            }
        });
    }
}
