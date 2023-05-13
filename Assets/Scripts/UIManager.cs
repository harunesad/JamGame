using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uý;
    [SerializeField] TextMeshProUGUI heroesName, heroesHealth, heroesAttack, 
        heroesAttackSpeed, heroesLevelCount, heroesLevelCoin, levelText, scoreText;
    [SerializeField] Button playButton;
    public Button restartButton;
    string levelKey = "Level", scoreKey;
    int index;
    [SerializeField] GameObject heroesPanel, upgradePanel;
    private void Awake()
    {
        uý = this;
    }
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetFloat(scoreKey);
        if (PlayerPrefs.HasKey(levelKey))
        {
            levelText.text = "Level " + PlayerPrefs.GetInt(levelKey);
        }
        else
        {
            levelText.text = "Level 1";
            PlayerPrefs.SetInt(levelKey, 1);
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
        Time.timeScale = 1;
        EnemiesControl.enemiesControl.InvokeStart();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ScoreAdd()
    {
        float score = PlayerPrefs.GetFloat(scoreKey);
        score++;
        PlayerPrefs.SetFloat(scoreKey, score);
        scoreText.text = "Score: " + PlayerPrefs.GetFloat(scoreKey);
    }
    public void UpgradeOpen(GameObject parent)
    {
        for (int i = 0; i < GameManager.manager.heroes.Count; i++)
        {
            if (GameManager.manager.heroes[i].name == parent.name)
            {
                index = i;
                heroesName.text = JsonSave.jsonSave.sv.heroes[i].heroName.ToString();
                heroesHealth.text = "Health: " + JsonSave.jsonSave.sv.heroes[i].heroHealth;
                heroesAttack.text = "Attack: " + JsonSave.jsonSave.sv.heroes[i].heroAttack;
                heroesAttackSpeed.text = "Attack Speed: " + JsonSave.jsonSave.sv.heroes[i].heroAttackSpeed;
                heroesLevelCount.text = "Level " + JsonSave.jsonSave.sv.heroes[i].level;
                heroesLevelCoin.text = JsonSave.jsonSave.sv.heroes[i].levelCoin.ToString();
            }
        }
        upgradePanel.SetActive(true);
    }
    public void UpgradeClose()
    {
        upgradePanel.SetActive(false);
    }
    public void Upgrade()
    {
        if (PlayerPrefs.GetFloat(scoreKey) >= JsonSave.jsonSave.sv.heroes[index].levelCoin)
        {
            float score = PlayerPrefs.GetFloat(scoreKey);
            score -= JsonSave.jsonSave.sv.heroes[index].levelCoin;
            PlayerPrefs.SetFloat(scoreKey, score);
            scoreText.text = "Score: " + PlayerPrefs.GetFloat(scoreKey);

            JsonSave.jsonSave.sv.heroes[index].levelCoin += 10;
            JsonSave.jsonSave.sv.heroes[index].heroAttack ++;
            JsonSave.jsonSave.sv.heroes[index].level++;
            JsonSave.jsonSave.sv.heroes[index].heroAttackSpeed -= .05f;
            SaveManager.Save(JsonSave.jsonSave.sv);

            JsonSave.jsonSave.sv = SaveManager.Load();
            heroesAttack.text = "Attack: " + JsonSave.jsonSave.sv.heroes[index].heroAttack;
            heroesAttackSpeed.text = "Attack Speed: " + JsonSave.jsonSave.sv.heroes[index].heroAttackSpeed;
            heroesLevelCount.text = "Level " + JsonSave.jsonSave.sv.heroes[index].level;
            heroesLevelCoin.text = JsonSave.jsonSave.sv.heroes[index].levelCoin.ToString();
        }
    }
}
