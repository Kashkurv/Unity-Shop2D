using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DoTweenMoney : MonoBehaviour
{
    [SerializeField] GameObject animCoinsPrefab;
    [SerializeField] Transform target;
    [Space]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    [Space]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;
    [SerializeField] float spread;
    [SerializeField] Ease easeType;
    Vector3 targetPosition;

    private int c;

    public int Coins
    {
        get{return c;}
        set{c = value;}    
    }

    void Start()
    {
        targetPosition = target.position;
        DefaultState();
    }
     void DefaultState()
    {
        GameObject coin;
        for (int i = 0; i < maxCoins; i++)
        {
            coin = Instantiate(animCoinsPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }
    void Animate(Vector3 coinsPosition, int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                coin.transform.position = coinsPosition + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() => {
                    coin.SetActive(false);
                    coinsQueue.Enqueue(coin);
                    AudioManager.Instance.PlaySound("Money");
                    Coins++;
                });
            }
        }
    }

    public void AddCoins(Vector3 coinsPosition, int value)
    {
        Animate(coinsPosition, value);
    }
}
