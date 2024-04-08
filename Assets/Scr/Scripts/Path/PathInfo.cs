using UnityEngine;

public class PathInfo : MonoBehaviour
{
    [SerializeField]
    private Transform nextPoint;

    public Transform GetNextPoint()
    {
            return this.nextPoint;
    }
}
