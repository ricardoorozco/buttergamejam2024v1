using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Start()
    {
        if (!target && !GameController.instance.isGameOver)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        this.transform.LookAt(target);
    }
}
