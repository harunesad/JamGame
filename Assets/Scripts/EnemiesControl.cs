using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesControl : MonoBehaviour
{
    public static EnemiesControl enemiesControl;
    public List<GameObject> enemies;
    private void Awake()
    {
        enemiesControl = this;
    }
    public void InvokeStart()
    {
        InvokeRepeating("EnemiesActive", 2, 2);
    }
    public void EnemiesActive()
    {
        int enemyCount = FindObjectsOfType<Rigidbody2D>().Length;
        if (enemies.Count > 0)
        {
            int index = Random.Range(0, enemies.Count);
            int pointIndex = Random.Range(0, GameManager.manager.points.Count);
            enemies[index].transform.position = GameManager.manager.points[pointIndex].position + Vector3.right * 16;
            enemies[index].gameObject.SetActive(true);
            enemies.RemoveAt(index);
        }
        if (enemyCount == 0)
        {
            int levelCount = PlayerPrefs.GetInt("Level");
            levelCount++;
            PlayerPrefs.SetInt("Level", levelCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        for (int i = 0; i < GameManager.manager.myHeroes.Count; i++)
        {
            GameManager.manager.myHeroes[i].GetComponent<BulletSpawn>().EnemyAttack();
        }
    }
}
