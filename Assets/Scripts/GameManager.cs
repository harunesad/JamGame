using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject hero;
    public GameObject heroPoint;
    public List<GameObject> myHeroes;
    public List<GameObject> heroes;
    public List<bool> isEmpty;
    public List<Transform> points;
    public int pointCount;
    public LayerMask enemyLayer;
    private void Awake()
    {
        manager = this;
    }
    public void SpawnObject()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (hero.name == heroes[i].name)
            {
                for (int j = 0; j < myHeroes.Count; j++)
                {
                    if (myHeroes[j] != null && myHeroes[j].name == heroes[i].name)
                    {
                        return;
                    }
                }
                if (isEmpty[pointCount] == true)
                {
                    myHeroes[pointCount].SetActive(false);
                }
                heroes[i].transform.position = heroPoint.transform.position;
                heroes[i].SetActive(true);
                myHeroes[pointCount] = heroes[i];
            }
        }
        isEmpty[pointCount] = true;
    }
}
