using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public GameObject hero;
    public GameObject heroPoint;
    public HeroesInfo heroesInfo;
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
    void Start()
    {
        
    }
    public void SpawnObject()
    {
        string name;
        for (int i = 0; i < heroes.Count; i++)
        {
            if (hero.name == heroes[i].name)
            {
                //if (heroes.Contains(heroesInfo.heroes[i].hero))
                //{
                //    Debug.Log("sadsad");
                //    return;
                //}
                //name = heroesInfo.heroes[i].hero.name + "(Clone)";
                for (int j = 0; j < myHeroes.Count; j++)
                {
                    if (myHeroes[j] != null && myHeroes[j].name == heroes[i].name)
                    {
                        Debug.Log("sadsad");
                        return;
                    }
                }
                if (isEmpty[pointCount] == true)
                {
                    myHeroes[pointCount].SetActive(false);
                    //Destroy(myHeroes[pointCount]);
                }
                heroes[i].transform.position = heroPoint.transform.position;
                heroes[i].SetActive(true);
                myHeroes[pointCount] = heroes[i];
                //myHeroes[pointCount] = (Instantiate(heroes[i], spawnPoint.transform.position, Quaternion.identity));
            }
        }
        isEmpty[pointCount] = true;
    }
}
