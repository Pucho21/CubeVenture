using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    public InputField usernameRegisterInput;
    public InputField passwordRegisterInput;
    public InputField repeatPasswordInput;
    public InputField emailInput;
    public Button registerButton;
    public Text resultTextregister;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            if (passwordRegisterInput.text == repeatPasswordInput.text)
            {
                StartCoroutine(Main.Instance.Web.Register(usernameRegisterInput.text, passwordRegisterInput.text, emailInput.text));
                resultTextregister.text = ("Registration successful");
            } else
            {
                resultTextregister.text = ("Hesla sa nezhoduju");
            }
            
        });
    }
}
