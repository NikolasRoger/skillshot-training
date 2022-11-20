using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using AuthDTO;

public class LoginPanelController : MonoBehaviour
{
    public TMPro.TMP_InputField emailInput;
    public TMPro.TMP_InputField passwordInput;
    public GameObject registerPanel;

    private AuthRepository authRepository;

    public ToolsController tools;

    private void Start() {
        authRepository = GetComponent<AuthRepository>();
        /* if(PlayerPrefs.HasKey("token")) {
            SceneLoader.Instance.LoadSceneAsync("MenuScene");
        } */
    }

    public void GoToRegisterPanel() 
    {
        gameObject.SetActive(false);
        registerPanel.SetActive(true);
    }

    public void OnSubmit()
    {
        tools.ShowLoader();
        LoginRequest submitData = new LoginRequest
        {
            email = emailInput.text,
            password = passwordInput.text
        };
        authRepository.Login(submitData)
        .Then(res =>
        {
            tools.Close();
            PlayerPrefs.SetString("token", res.token);
            SceneLoader.Instance.LoadSceneAsync("MenuScene");
        })
        .Catch(err =>
        {
            var error = err as RequestException;
            string errorMessage = JsonUtility.FromJson<LoginError>(error.Response).message;
            tools.ShowAlert(errorMessage);
        });
    }
}
