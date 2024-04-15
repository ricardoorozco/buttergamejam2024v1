using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void RemoveAndReorder(List<GameObject> gameObjectList,GameObject gameObject)
    {
        if (gameObject)
        {
            int index = gameObjectList.IndexOf(gameObject);
            gameObjectList.Remove(gameObject);
            for (int i = index; i < gameObjectList.Count; i++)
            {
                gameObjectList[i] = gameObjectList[i - 1];
            }
        }
        else
        {
            Debug.LogWarning("Índice fuera de rango.");
        }
    }
}
