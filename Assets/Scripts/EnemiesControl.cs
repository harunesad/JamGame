using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        int index = Random.Range(0, enemies.Count);
        int pointIndex = Random.Range(0, GameManager.manager.points.Count);
        enemies[index].transform.position = GameManager.manager.points[pointIndex].position + Vector3.right * 16;
        enemies[index].gameObject.SetActive(true);
        enemies.RemoveAt(index);
        CannonFondler.cannon.EnemyAttack();
        BigGuns.bigGuns.EnemyAttack();
    }
}
