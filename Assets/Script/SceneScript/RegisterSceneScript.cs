using Script;
using Script.Messages.CsMessages;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterSceneScript : MonoBehaviour
{
    public GameObject userName;

    public GameObject password;
    public GameObject retypePassword;

    public GameObject error;
    
    // Start is called before the first frame update
    void Start()
    {
        error.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UserProperties.MainPlayer.userID == null)
        {
            if (UserProperties.RegisterFailed)
            {
                error.SetActive(true);
            }
            else
            {
                error.SetActive(false);
            }
        }
        else
        {
            SceneManager.LoadScene("RoomAvatarSelectScene");
        }
    }
    
    public void OnTryRegister()
    {
        string usernameString = userName.GetComponent<TMP_Text>().text;
        string passwordString = password.GetComponent<TMP_Text>().text;
        string retypeString = retypePassword.GetComponent<TMP_Text>().text;
        
        AppProperties.ServerSession.SendMessage(new CsRegister(usernameString,passwordString,retypeString));
    }

    public void OnSwitchLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
