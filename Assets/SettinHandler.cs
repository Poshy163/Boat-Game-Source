using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SettinHandler : MonoBehaviour
{
    public string PlayerName;
    public int FPS_cap;
    public TMP_InputField inputFieldFPS;
    public TMP_InputField inputFieldName;
    public TMP_Text errorBox;
    public void SetFPS ()
    {
        if(!string.IsNullOrEmpty(inputFieldFPS.text))
        {
            try
            {
                FPS_cap = int.Parse(inputFieldFPS.text);
                errorBox.text = "Valid FPS!";
            }
            catch
            {
                errorBox.text = "invalid FPS count. Default will be 60";
                FPS_cap = 60;
            }
        }
        else
        {
            errorBox.text = "Null or empty FPS count. Default will be 60";
            FPS_cap = 60;
        }
        Application.targetFrameRate = FPS_cap;
    }
    public void SetName ()
    {
        if(!string.IsNullOrEmpty(inputFieldName.text) || inputFieldName.text.Contains(":"))
        {
            try
            {
                PlayerName = inputFieldName.text;
                errorBox.text = "Valid Name!";
            }
            catch
            {
                PlayerName = "NULL";
                errorBox.text = "Invalid Name: Your score will not be recorded";
            }
        }
        else
        {
            PlayerName = "NULL";
            errorBox.text = "Null or empty Name. Your score will not be recorded";
        }
    }
    public void ReturnToGame ()
    {
        if(string.IsNullOrEmpty(PlayerName))
            PlayerName = "NULL";
        if(string.IsNullOrEmpty(inputFieldFPS.text))
            FPS_cap = 60;

        Settings settingsobj = GameObject.Find("Settings").GetComponent<Settings>();
        settingsobj.PlayerName = PlayerName;
        settingsobj.FPS_cap = FPS_cap;
        SceneManager.LoadScene("GameScene");
    }
}
