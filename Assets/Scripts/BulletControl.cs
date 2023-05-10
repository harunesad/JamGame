using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BulletControl : MonoBehaviour
{
    GameObject parent;
    float attack;
    float attackSpeed;
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
            Image healthBar = collision.gameObject.GetComponentInChildren<Image>();
            healthBar.fillAmount -= (attack / 100);
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
