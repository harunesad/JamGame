using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> heroesName; 
    void Start()
    {
        for (int i = 0; i < heroesName.Count; i++)
        {
            HeroesInfo hero = SpawnManager.spawn.heroesInfo;
            heroesName[i].text = $"{hero.heroes[i].hero.name} \n H:{hero.heroes[i].heroHealth}  A:{hero.heroes[i].heroAttack}  AS:{hero.heroes[i].heroAttackSpeed}";
        }
    }
}
