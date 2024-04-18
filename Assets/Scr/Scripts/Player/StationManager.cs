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
    private bool isLiving = true;
    [SerializeField]
    private float maxLife;

    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject DestroyedSpaceStation;
    [SerializeField]
    private GameObject SupplyPrefab;

    [SerializeField]
    private StageController stageController;

    public int score = 0;

    public void Awake()
    {
        life = maxLife;
        stageController = GameObject.Find("StageController").GetComponent<StageController>();
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

        if (isLiving && life <= 0)
        {
            isLiving = false;
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        if (CompareTag("Player"))
        {
            GameController.instance.isGameOver = true;
            stageController.saveGame();
            stageController.endGame();
            Instantiate(DestroyedSpaceStation, transform.position, Quaternion.identity);
        }
        else
        {
            stageController.addScore(score);
            Instantiate(SupplyPrefab, transform.position, Quaternion.identity);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
