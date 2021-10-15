using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public static ShopHandler instance;
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
        UpdateCoinsText();
    }

    // Update is called once per frame
    public void UpdateCoinsText()
    {
        coinsCountText.text = UserInfoHolder.instance.coins.ToString();
    }

    public void SetSelectedItem(ShopItem selected)
    {
        if (selectedItem != null) selectedItem.SetPurchasedItem();
        selectedItem = selected;

    }

}
