using UnityEngine;
using UnityEngine.UI;

public class StationManager : MonoBehaviour
{
    //UI
    [SerializeField]
    private Slider lifeBar;

    //State
    [SerializeField]
    private float life;
    [SerializeField]
    private float maxLife;

    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject DestroyedSpaceStation;

    public void Awake()
    {
        life = maxLife;
    }

    void Update()
    {
        lifeBar.value = life / maxLife;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage: " + damage);

        life -= damage;

        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameController.instance.isGameOver = true;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Instantiate(DestroyedSpaceStation, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
