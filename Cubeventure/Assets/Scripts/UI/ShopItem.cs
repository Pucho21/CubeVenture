using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public string itemID;
    public int price;
    private bool isPurchased;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelected()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Image>().sprite = ShopHandler.instance.selectedBCG;
        ShopHandler.instance.SetSelectedItem(this);
        isPurchased = true;
        UserInfoHolder.instance.SetHatID(itemID);

    }

    public void SetPurchasedItem()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Image>().sprite = ShopHandler.instance.defaultBCG;
        isPurchased = true;

    }

    public void ShopItemClicked()
    {
        if(isPurchased)
        {
            SetSelected();
        } else
        {
            //podmienka na penaze (dotaz na DB) a potom setselected
            if(UserInfoHolder.instance.coins >= price) //nemame love
            {
                SetSelected();
                UserInfoHolder.instance.SavePurchasedToDB(itemID, price);
                ShopHandler.instance.UpdateCoinsText();
            } else
            {
                Debug.Log("Not enough coins warning!!!!!!!!");
            }
        }
    }

}
