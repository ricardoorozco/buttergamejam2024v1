using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        this.transform.LookAt(target);
    }
}
