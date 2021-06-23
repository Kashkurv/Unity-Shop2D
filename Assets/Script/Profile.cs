using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public static Profile Instance;
    void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public class Weapoin
    {
        public Sprite image;
        public int index;
    }

    public List<Weapoin> weapoinList;

    [SerializeField] GameObject weaponUITamplate;
    [SerializeField] Transform weapoinScrolView;

    GameObject go;
    int newSelectedIndex, previousSelectedIndex;

    [SerializeField] Color activeWeapoinColor;
    [SerializeField] Color defaulWeapoinColor;

    [SerializeField] Image currentWeapoinImg;

    private void Start()
    {
        GetAvailableWeapoins();
        newSelectedIndex = previousSelectedIndex = 0;
    }
    void GetAvailableWeapoins()
    {
        for (int i = 0; i < Shop.Instance.shopItemView.Count; i++)
        {
            if (Shop.Instance.shopItemView[i].IsPurchased)
            {
                AddWeapon(Shop.Instance.shopItemView[i].image,Shop.Instance.shopItemView[i].index);                
            }
        }
        SelectWeapoin(newSelectedIndex);
    }
    public void AddWeapon(Sprite image,int index)
    {
        if (weapoinList == null)
            weapoinList = new List<Weapoin>();

        Weapoin wp = new Weapoin() { image = image, index = index};
        weapoinList.Add(wp);

        go = Instantiate(weaponUITamplate,weapoinScrolView);
        go.transform.GetChild(0).GetComponent<Image>().sprite = wp.image;
        go.transform.GetComponent<Button>().AddEventListener(weapoinList.Count-1, SelectWeapoin);
    }
    void OnClickWeapon()
    {

    }
    void SelectWeapoin(int weapoinIndex)
    {
        previousSelectedIndex = newSelectedIndex;
        newSelectedIndex = weapoinIndex;

        weapoinScrolView.GetChild(previousSelectedIndex).GetComponent<Image>().color = defaulWeapoinColor;
        weapoinScrolView.GetChild(newSelectedIndex).GetComponent<Image>().color = activeWeapoinColor;
             
        AudioMenager.Instance.PlaySound("BtnClick2");

        WeaponSwitch.Instance.indexWeapon = weapoinList[newSelectedIndex].index;
    }

}
