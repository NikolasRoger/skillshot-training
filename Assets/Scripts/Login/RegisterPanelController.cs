using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UsersDTO;
using Proyecto26;

public class RegisterPanelController : MonoBehaviour
{
    public TMPro.TMP_InputField emailInput;
    public TMPro.TMP_InputField nicknameInput;
    public TMPro.TMP_InputField passwordInput;
    public TMPro.TMP_InputField confirmPasswordInput;
    public GameObject loginPanel;
    private UsersRepository usersRepository;

    public ToolsController tools;

    private void Start() {
        usersRepository = GetComponent<UsersRepository>();
    }

    public void GoToLoginPanel()
    {
        gameObject.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void OnSubmit()
    {
        if(passwordInput.text != confirmPasswordInput.text) {
            tools.ShowAlert("Senha e confirmação de senha não conferem.");
        } else if (
            emailInput.text.Length <= 0 ||
            nicknameInput.text.Length <= 0 ||
            passwordInput.text.Length <= 0
        ) {
            tools.ShowAlert("Todos os campos são obrigatórios");
        } else {
            tools.ShowLoader();
            CreateUserRequest submitData = new CreateUserRequest {
                email = emailInput.text,
                name = nicknameInput.text,
                password = passwordInput.text
            };
            usersRepository.CreateUser(submitData)
            .Then(res => {
                GoToLoginPanel();
                tools.ShowAlert("Conta criada com sucesso! Realize o login.");
            })
            .Catch(err => {
                var error = err as RequestException;
                string errorMessage = JsonUtility.FromJson<CreateUserError>(error.Response).message;
                tools.ShowAlert(errorMessage);
            });
        }
    }
}
