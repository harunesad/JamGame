using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObject/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public List<LevelProperties> level = new List<LevelProperties>();
}
[System.Serializable]
public class LevelProperties
{
    public List<Monster> monster;
    public float spawnRate;
    public float levelTime;
}
[System.Serializable]
public class Monster
{
    public GameObject monster;
    public float monsterHealth;
    public float monsterSpeed;
    public float monsterAttack;
}
