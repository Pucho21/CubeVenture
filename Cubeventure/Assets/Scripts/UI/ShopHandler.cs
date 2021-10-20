using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public static ShopHandler instance;
    public Transform shopContent;
    public Sprite selectedBCG;
    public Sprite defaultBCG;
    private ShopItem selectedItem;
    public Text coinsCountText;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Web.instance.GetUserCoins(UserInfoHolder.instance.userID));
        StartCoroutine(Web.instance.GetItemsIDs(UserInfoHolder.instance.userID));
    }

    public void OnEnable()
    {
        if (selectedItem != null) selectedItem.SetSelected();

    }
    public void OnDisable()
    {
        //selectedItem.SetPurchasedItem();
        //selectedItem = null;
    }

    // Update is called once per frame
    public void UpdateCoinsText()
    {
        coinsCountText.text = UserInfoHolder.instance.coins.ToString();
    }

    public void SetSelectedItem(ShopItem selected)
    {
        if (selectedItem != null)
        {
            selectedItem.SetPurchasedItem();
        }
        selectedItem = selected;
    }

    public void SetUnlockedItemsDB(List<int> itemIDs)
    {
        for(int i = 0; i < itemIDs.Count; i++)
        {
            shopContent.GetChild(itemIDs[i]).GetComponent<ShopItem>().SetPurchasedItem();
        }
        shopContent.GetChild(0).GetComponent<ShopItem>().SetSelected();
    }



}
