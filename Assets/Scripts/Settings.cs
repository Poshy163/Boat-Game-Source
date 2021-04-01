using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Settings")]
    public string PlayerName;
    public int FPS_cap;
    public static Settings instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            Destroy(this);
        }
      
    }

    private void FixedUpdate()
    {
        Application.targetFrameRate = FPS_cap;
        QualitySettings.vSyncCount = 0;
    }





}
