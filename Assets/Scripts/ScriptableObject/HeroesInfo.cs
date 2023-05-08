using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroesInfo", menuName = "ScriptableObject/HeroesInfo")]
public class HeroesInfo : ScriptableObject
{
    public List<HeroesProperties> heroes = new List<HeroesProperties>();
}
[System.Serializable]
public class HeroesProperties
{
    public GameObject hero;
    public float heroHealth;
    public float heroAttack;
    public float heroAttackSpeed;
}
