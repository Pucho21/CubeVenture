using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Web : MonoBehaviour
{
    public Text resultTextLogin;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(getUsers());
        //StartCoroutine(Login("NvN", "morecko"));
        //StartCoroutine(Register("tester", "tester", "tester@gmail.com"));

    }

    public IEnumerator getUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/cubeventure/getusers.php"))
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

                //or retrieve results as binary data
                Debug.Log(www.downloadHandler.data);
            }
        }
    }

    public IEnumerator Login(string username, string password)
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
                resultTextLogin.text = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

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


}
