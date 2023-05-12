using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager u�;
    [SerializeField] List<TextMeshProUGUI> heroesName;
    [SerializeField] Button playButton;
    public Button restartButton;
    [SerializeField] Text levelText;
    string levelKey = "Level";
    public GameObject heroesPanel;
    private void Awake()
    {
        u� = this;
    }
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
        restartButton.onClick.AddListener(Restart);
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
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
