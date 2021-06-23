using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [System.Serializable] public class ShopItem
    {
        public Sprite image;
        public int prace;
        public int index;
        public string name;
        public bool IsPurchased = false;
    }

    public  List<ShopItem> shopItemView;

    GameObject itemTemplate;
    GameObject g;
    

    [SerializeField] Transform shopScrollView;

    Button buyBtn;
    [SerializeField] Animator anim;
    [SerializeField] Text coinsText;

    void Start()
    {
        SetCoinsUI();
        itemTemplate = shopScrollView.GetChild(0).gameObject;

        int len = shopItemView.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(itemTemplate,shopScrollView);

            g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemView[i].image;
            g.transform.GetChild(1).GetComponent<Text>().text = shopItemView[i].name; 
            g.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = shopItemView[i].prace.ToString();

            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            if (shopItemView[i].IsPurchased)
            {
                DisableBuyButton();
            }
            buyBtn.AddEventListener(i,OnShopItemBtnClick);
        }
        Destroy(itemTemplate);
    }
    void OnShopItemBtnClick(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(shopItemView[itemIndex].prace))
        {
            Game.Instance.UseCoins(shopItemView[itemIndex].prace);
            shopItemView[itemIndex].IsPurchased = true;
            buyBtn = shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();
            SetCoinsUI();
            AudioMenager.Instance.PlaySound("BtnClick");
            Profile.Instance.AddWeapon(shopItemView[itemIndex].image,shopItemView[itemIndex].index);
        }
        else
        {
            AudioMenager.Instance.PlaySound("Error");
            anim.SetTrigger("NoCoins");
        }
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";
    }

    public void SetCoinsUI()
    {
       coinsText.text = Game.Instance.coins.ToString()+" $";
    }

}
