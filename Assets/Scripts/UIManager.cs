using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> heroesName;
    [SerializeField] Button playButton;
    [SerializeField] Text levelText;
    string levelKey = "Level";
    public GameObject heroesPanel;
    void Start()
    {
        if (PlayerPrefs.HasKey(levelKey))
        {
            levelText.text = "Level " + PlayerPrefs.GetInt(levelKey);
        }
        else
        {
            levelText.text = "Level 1";
            PlayerPrefs.SetInt(levelKey, 1);
        }
        for (int i = 0; i < heroesName.Count; i++)
        {
            heroesName[i].text = $"{JsonSave.jsonSave.sv.heroes[i].heroName} " +
                $"\n H:{JsonSave.jsonSave.sv.heroes[i].heroHealth}  " +
                $"A:{JsonSave.jsonSave.sv.heroes[i].heroAttack}  " +
                $"AS:{JsonSave.jsonSave.sv.heroes[i].heroAttackSpeed}";
        }
        playButton.onClick.AddListener(Play);
    }
    public void Play()
    {
        for (int i = 0; i < GameManager.manager.myHeroes.Count; i++)
        {
            if (GameManager.manager.myHeroes[i] == null)
            {
                return;
            }
        }
        heroesPanel.SetActive(false);
        EnemiesControl.enemiesControl.InvokeStart();
    }
}
