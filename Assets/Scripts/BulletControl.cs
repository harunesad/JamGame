using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    GameObject parent;
    float attack;
    float attackSpeed;
    public float enemyHealth;
    void Start()
    {
        parent = transform.parent.gameObject;
        for (int i = 0; i < JsonSave.jsonSave.sv.heroes.Count; i++)
        {
            if (parent.name == JsonSave.jsonSave.sv.heroes[i].heroName)
            {
                attack = JsonSave.jsonSave.sv.heroes[i].heroAttack;
                attackSpeed = JsonSave.jsonSave.sv.heroes[i].heroAttackSpeed;
            }
        }
        transform.DOMoveX(8, attackSpeed).SetEase(Ease.Linear).OnComplete(
            () => 
            {
                Destroy(gameObject);
            });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            for (int i = 0; i < EnemiesControl.enemiesControl.enemiesInfo[1].enemyInfo.Count; i++)
            {
                if (collision.gameObject.name == EnemiesControl.enemiesControl.enemiesInfo[1].enemyInfo[i].enemyName)
                {
                    enemyHealth = EnemiesControl.enemiesControl.enemiesInfo[PlayerPrefs.GetInt("Level")].enemyInfo[i].monsterHealth;
                }
            }

            Image healthBar = collision.gameObject.GetComponentInChildren<Image>();
            healthBar.fillAmount -= (1 - (enemyHealth - attack) / 100);
            collision.gameObject.GetComponent<Animator>().SetTrigger("Hit");
            if (healthBar.fillAmount == 0)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Death");
                Destroy(collision.gameObject, .35f);
            }
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, .4f);
        }
    }
}
