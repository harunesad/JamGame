using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFondler : MonoBehaviour
{
    public static CannonFondler cannon;
    public GameObject bullet;
    Animator anim;
    private void Awake()
    {
        cannon = this;
        anim = GetComponent<Animator>();
    }
    public void EnemyAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, GameManager.manager.enemyLayer);
        if (hit.collider != null && !IsInvoking())
        {
            anim.SetBool("Attack", true);
            BulletsInvoke();
        }
    }
    void BulletsInvoke()
    {
        InvokeRepeating("Bullets", 1, 1);
    }
    void Bullets()
    {
        Instantiate(bullet, transform.position + Vector3.right * .25f, Quaternion.identity, transform);
    }
}
