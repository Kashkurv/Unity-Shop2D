using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] string nameAudioShot;
    [SerializeField] private Target target;
    

    [SerializeField] GameObject sleevePrefab;
    [SerializeField] Transform sleeveDir;

    [SerializeField] private float startTimeShot;
    private float timeShot;

    private Animator anim;
    bool isShot = false;
    void Start()
    {        
        anim = GetComponent<Animator>();
        timeShot = startTimeShot;
    }
    private void LateUpdate()
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

    public void Shot()
    {
        AudioManager.Instance.PlaySound(nameAudioShot);
        anim.SetTrigger("Shot");
        Instantiate(sleevePrefab, sleeveDir.position, sleeveDir.rotation);
        target.Animation();
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
