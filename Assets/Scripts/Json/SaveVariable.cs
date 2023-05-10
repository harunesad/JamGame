using System.Collections.Generic;

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
