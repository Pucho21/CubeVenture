using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Web : MonoBehaviour
{
    public static Web instance;
    public Text resultTextLogin;
    EventSystem system;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }
    }

//***********************************************************************************************************************************************
    public IEnumerator GetUserCoins(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/getusers.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                UserInfoHolder.instance.SetCoins(int.Parse(www.downloadHandler.text));
                ShopHandler.instance.UpdateCoinsText();

                //callback function  to pass result
            }
        }
    }
//***********************************************************************************************************************************************
    public IEnumerator Login(string username, string password)// -1 = user neexistuje, 0 = zle udaje, 1 = success
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                resultTextLogin.text = "chyba";
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                if(www.downloadHandler.text.Equals("-1"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {
                    resultTextLogin.text = "Username does not exist";
                    //neexistuje pouzivatel
                    

                } else if (www.downloadHandler.text.Equals("0"))// -1 = user neexistuje, 0 = zle udaje, inak success
                {
                    resultTextLogin.text = "Wrong creditals";
                    //ficurka keby nieco, prehodit alebo tak

                }
                else // logged in correctly 
                {
                    resultTextLogin.text = "Login successful";
                    UserInfoHolder.instance.SetID(www.downloadHandler.text);
                    //UserInfoHolder.instance.SetCoins(int.Parse(www.downloadHandler.text));
                    //ShowUserItems();
                    yield return new WaitForSeconds(2);
                    UIManager.instance.introScreen();
                }

            }
        }
    }
//***********************************************************************************************************************************************
    public IEnumerator Register(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);
        form.AddField("loginEmail", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

            }
        }
    }
//***********************************************************************************************************************************************
    public IEnumerator BuyItem(string itemID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("itemID", itemID);

        //Debug.Log("posielam udaje: " + UserInfoHolder.instance.userID + " a " + itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/buyitem.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

//***********************************************************************************************************************************************
    public IEnumerator UpdateCoins()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        form.AddField("updatedCoins", UserInfoHolder.instance.coins);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/coinsupdate.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

    //***********************************************************************************************************************************************
    public IEnumerator GetItemsIDs(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", UserInfoHolder.instance.userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cubeventure/getitemsids.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text; 

                string pomID = "";
                List<int> itemIDs = new List<int>();             
                for(int i = 0; i < jsonArray.Length; i++)
                {
                    char c = Convert.ToChar(jsonArray.Substring(i, 1));
                    if (Char.IsDigit(c))
                    {
                        pomID = pomID + c;
                    } else if(!pomID.Equals(""))
                    {
                        //Debug.Log("purchased itemID: " + pomID);
                        itemIDs.Add(int.Parse(pomID));
                        pomID = "";                
                    }
                }
                ShopHandler.instance.SetUnlockedItemsDB(itemIDs);

                //callback function  to pass result
            }
        }
    }


}
