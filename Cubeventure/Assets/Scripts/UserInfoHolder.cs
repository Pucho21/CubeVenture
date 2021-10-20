using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoHolder : MonoBehaviour
{
    public static UserInfoHolder instance;
    public int coins;
    private bool logged;
    public string userID { get; private set; }
    public string name;
    public string pw;
    public string hatID;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //check loginu
            Destroy(gameObject);
        }
    }

    public bool IsUserLoggedIn()
    {
        return logged;
    }

    public void SetCredentials(string name, string pw)
    {
        this.name = name;
        this.pw = pw;
        logged = true;
    }

    public void SetID(string id)
    {
        userID = id;
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }

    private void GetUserInfoDB()
    {
        //dotaz na DB
    }

    //kupime item, posleme string itemu, odpocitame coins

    public void CoinsUpdateDB(int price)
    {
        coins -= price;
        StartCoroutine(Web.instance.UpdateCoins());
        //ulozit do DB ze item je kupeny
        //prepisat coins hraca v DB
    }

    public void SetHatID(string hatID)
    {
        this.hatID = hatID;
    }

}
