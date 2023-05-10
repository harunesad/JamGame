using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    Animator anim;
    public int attackCount = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.SetBool("Run", true);
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
        if (attackCount == 5)
        {
            anim.SetFloat("Attack", 0);
            yield return new WaitForSecondsRealtime(.45f);
            anim.SetFloat("Attack", 2);
            attackCount = 0;
            StartCoroutine(SuperAttack());
        }
        else
        {
            yield return new WaitForSecondsRealtime(.45f);
            attackCount++;
            StartCoroutine(SuperAttack());
        }
    }
    #endregion
}
