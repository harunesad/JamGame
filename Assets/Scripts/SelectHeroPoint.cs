using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHeroPoint : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (SpawnManager.spawn.spawnPrefab != null)
        {
            for (int i = 0; i < SpawnManager.spawn.heroesSpawnPoints.Count; i++)
            {
                if (gameObject.name == SpawnManager.spawn.heroesSpawnPoints[i].name)
                {
                    SpawnManager.spawn.pointCount = i;
                }
            }
            SpawnManager.spawn.spawnPoint = gameObject;
            Debug.Log(SpawnManager.spawn.spawnPoint);
            SpawnManager.spawn.SpawnObject();
            SpawnManager.spawn.spawnPrefab = null;
        }
    }
}
