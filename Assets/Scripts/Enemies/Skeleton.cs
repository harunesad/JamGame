using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    Animator anim;
    int attackCount = 0;
    float attack;
    float heroHealth;
    GameObject hero;
    int levelId;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        levelId = PlayerPrefs.GetInt("Level");
        attack = EnemiesControl.enemiesControl.enemiesInfo[levelId].enemyInfo[0].attack;
        for (int i = 0; i < GameManager.manager.myHeroes.Count; i++)
        {
            if (transform.position.y == GameManager.manager.myHeroes[i].transform.position.y)
            {
                heroHealth = JsonSave.jsonSave.sv.heroes[i].heroHealth;
                hero = GameManager.manager.myHeroes[i];
            }
        }
        anim.SetBool("Walk", true);
        gameObject.transform.DOMoveX(-6.75f, 5).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                anim.SetBool("AttackState", true);
                anim.SetFloat("Attack", 2);
                StartCoroutine(SuperAttack());
            });
    }
    #region SuperAttack
    IEnumerator SuperAttack()
    {
        Image healthBar = hero.GetComponentInChildren<Image>();
        if (attackCount == 5)
        {
            anim.SetFloat("Attack", 0);
            yield return new WaitForSecondsRealtime(.45f);
            anim.SetFloat("Attack", 2);
            attackCount = 0;
            healthBar.fillAmount -= 1 - (heroHealth - attack) / 100;
            StartCoroutine(SuperAttack());
        }
        else
        {
            yield return new WaitForSecondsRealtime(.45f);
            attackCount++;
            healthBar.fillAmount -= 1 - (heroHealth - attack) / 100;
            StartCoroutine(SuperAttack());
        }
    }
    #endregion
}
