using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Target : MonoBehaviour
{
    Animator anim;
    [SerializeField] int damage;
    [SerializeField] int money;
    int currentDamage;
    [SerializeField] Image uiFillImage;

    [SerializeField] DoTweenMoney tweenMoney;
    void Start()
    {
        anim = GetComponent<Animator>();
        DefaultState();
    }
    void DefaultState()
    {
        currentDamage = damage;
        uiFillImage.DOFillAmount(currentDamage / 10f, .4f);
    }
    public void Animation()
    {
        currentDamage--;
        anim.SetTrigger("Damage");
        uiFillImage.DOFillAmount(currentDamage / 10f, .4f);
        if (currentDamage <= 0)
        {
            tweenMoney.AddCoins(transform.position,5);
            Shop.Instance.SetCoinsUI();
            Game.Instance.AddCoins(money);
            DefaultState();
        }
    }
}
