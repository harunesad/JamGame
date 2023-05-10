using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveVariable
{
    public List<HeroesProperty> heroes = new List<HeroesProperty>();
}
[System.Serializable]
public class HeroesProperty
{
    public string heroName;
    public float heroHealth;
    public float heroAttack;
    public float heroAttackSpeed;
}
