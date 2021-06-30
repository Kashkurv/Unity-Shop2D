using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static Game Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public int coins;
    public void UseCoins(int amount)
    {
        coins -= amount;
    }
    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public bool HasEnoughCoins(int amount)
    {
        return (coins >= amount);
    }
}
