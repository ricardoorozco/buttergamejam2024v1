using UnityEngine;
using UnityEngine.UI;

public class StationManager : MonoBehaviour
{
    //UI
    [SerializeField]
    private Image lifeBar;

    //State
    [SerializeField]
    private float life;
    [SerializeField]
    private float maxLife;

    [SerializeField]
    private GameObject explosionPrefab;

    public void Awake()
    {
        life = maxLife;
    }

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
