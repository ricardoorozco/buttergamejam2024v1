using UnityEngine;

public class ChangeSceneGameObjectExit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerExit(Collider other)
    {
        SceneFunctions.ChangeScene(sceneName);
    }
}
