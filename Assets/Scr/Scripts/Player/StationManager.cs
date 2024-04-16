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

    [SerializeField]
    private StageController stageController;

    public void Awake()
    {
        life = maxLife;
        if (CompareTag("Player"))
        {
            stageController = GameObject.Find("StageController").GetComponent<StageController>();
        }
    }

    void Update()
    {
        if (lifeBar)
        {
            lifeBar.value = life / maxLife;
        }
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
        if (CompareTag("Player"))
        {
            GameController.instance.isGameOver = true;
            stageController.saveGame();
            stageController.endGame();
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (DestroyedSpaceStation)
        {
            Instantiate(DestroyedSpaceStation, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
