using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawn;
    public GameObject spawnPrefab;
    public GameObject spawnPoint;
    public HeroesInfo heroesInfo;
    public List<GameObject> heroes;
    public List<bool> isSpawned;
    public List<GameObject> heroesSpawnPoints;
    public int pointCount;
    private void Awake()
    {
        spawn = this;
    }
    void Start()
    {
        
    }
    public void SpawnObject()
    {
        string name;
        for (int i = 0; i < heroesInfo.heroes.Count; i++)
        {
            if (spawnPrefab.name == heroesInfo.heroes[i].hero.name)
            {
                //if (heroes.Contains(heroesInfo.heroes[i].hero))
                //{
                //    Debug.Log("sadsad");
                //    return;
                //}
                name = heroesInfo.heroes[i].hero.name + "(Clone)";
                for (int j = 0; j < heroes.Count; j++)
                {
                    if (heroes[j] != null && heroes[j].name == name)
                    {
                        Debug.Log("sadsad");
                        return;
                    }
                }
                if (isSpawned[pointCount] == true)
                {
                    Destroy(heroes[pointCount]);
                }
                heroes [pointCount] = (Instantiate(heroesInfo.heroes[i].hero, spawnPoint.transform.position, Quaternion.identity));
            }
        }
        isSpawned[pointCount] = true;
    }
}
