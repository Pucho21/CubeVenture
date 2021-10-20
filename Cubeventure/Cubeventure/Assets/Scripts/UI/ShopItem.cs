using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private string itemID;
    public int price;
    private bool isPurchased;

    private void Awake()
    {
        itemID = "hat" + transform.GetSiblingIndex();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = price.ToString();
    }

    private void OnEnable()
    {
        //if (itemID.Equals(UserInfoHolder.instance.hatID)) SetSelected();
    }


    public void SetSelected()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Image>().sprite = ShopHandler.instance.selectedBCG;
        ShopHandler.instance.SetSelectedItem(this);
        isPurchased = true;
        UserInfoHolder.instance.SetHatID(itemID);
        Debug.Log("selected " + itemID);

    }

    public void SetPurchasedItem()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Image>().sprite = ShopHandler.instance.defaultBCG;
        isPurchased = true;
        Debug.Log("kupeny itemID " + itemID);

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
                UserInfoHolder.instance.CoinsUpdateDB(price);
                StartCoroutine(Web.instance.BuyItem(transform.GetSiblingIndex().ToString()));
                ShopHandler.instance.UpdateCoinsText();
            } else
            {
                Debug.Log("Not enough coins warning!!!!!!!!");
            }
        }
    }

}
