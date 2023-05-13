using UnityEngine;
using UnityEngine.UI;

public class BulletSpawn : MonoBehaviour
{
    public static BulletSpawn bulletSpawn;
    [SerializeField] GameObject bullet;
    Animator anim;
    private void Awake()
    {
        bulletSpawn = this;
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
        if (hit.collider == null)
        {
            anim.SetBool("Attack", false);
            InvokeStop();
        }
    }
    void BulletsInvoke()
    {
        InvokeRepeating("Bullets", 1, 1);
    }
    void Bullets()
    {
        Image healthBar = GetComponentInChildren<Image>();
        if (healthBar.fillAmount == 0)
        {
            UIManager.uý.restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        Instantiate(bullet, transform.position + Vector3.right * .25f, Quaternion.identity, transform);
    }
    public void InvokeStop()
    {
        CancelInvoke();
    }
}
