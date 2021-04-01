using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject boatCam, personCam;
    bool CamActive = false;
    private void Awake ()
    {
        boatCam = GameObject.Find("BoatCam");
        personCam = GameObject.Find("PersonCam");
        personCam.SetActive(false);
        boatCam.SetActive(true);
    }



    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!CamActive)
            {
                boatCam.SetActive(false);
                personCam.SetActive(true);
                CamActive = true;
            }
            else
            {
                personCam.SetActive(false);
                boatCam.SetActive(true);
                CamActive = false;
            }
        }
    }
}
