using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] string nameAudioShoot;
    private AudioMenager audioMenager;

    [SerializeField] GameObject popupTextPrefab;
    [SerializeField] GameObject sleevePrefab;
    [SerializeField] Transform sleeveDir;

    [SerializeField] int money;
    [SerializeField] private float startTimeShot;
    private float timeShot;

    private Animator anim;
    bool isShot = false;
    void Start()
    {
        audioMenager = AudioMenager.Instance;
        anim = GetComponent<Animator>();        
    }
    void Update()
    {
        if (isShot)
        {
            if (timeShot <= 0)
            {
                timeShot = startTimeShot;
                Shot();
            }
            else
            {
                timeShot -= Time.deltaTime;
            }
        }
    }
    void Shot()
    {
        audioMenager.PlaySound(nameAudioShoot);
        ShowMoney(money.ToString());
        Shop.Instance.SetCoinsUI();
        Game.Instance.AddCoins(money);
        anim.SetTrigger("Shot");
        Instantiate(sleevePrefab, sleeveDir.position, sleeveDir.rotation);
    }

    void ShowMoney(string text)
    {
        if (popupTextPrefab)
        {
            GameObject prefab = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = "+ "+text+" $";
        }
    }

    public void isDownShot()
    {
        isShot = true;
    }
    public void isUpShot()
    {
        isShot = false;
    }
}
