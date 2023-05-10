using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> heroesName;
    [SerializeField] Button playButton;
    public GameObject heroesPanel;
    void Start()
    {
        for (int i = 0; i < heroesName.Count; i++)
        {
            HeroesInfo hero = GameManager.manager.heroesInfo;
            heroesName[i].text = $"{JsonSave.jsonSave.sv.heroes[i].heroName} \n H:{JsonSave.jsonSave.sv.heroes[i].heroHealth}  A:{JsonSave.jsonSave.sv.heroes[i].heroAttack}  AS:{hero.heroes[i].heroAttackSpeed}";
        }
        playButton.onClick.AddListener(Play);
    }
    public void Play()
    {
        for (int i = 0; i < GameManager.manager.myHeroes.Count; i++)
        {
            if (GameManager.manager.myHeroes[i] == null)
            {
                Debug.Log("sadsad");
                return;
            }
        }
        heroesPanel.SetActive(false);
        EnemiesControl.enemiesControl.InvokeStart();
    }
}
