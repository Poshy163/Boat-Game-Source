using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RescueBoat:MonoBehaviour
{
    public GameObject m_passenger = null, m_passenger2 = null, m_passenger3 = null;
    private float m_timer = 0;
    public Image m_countdownTimer;
    public float m_rescueTime = 3;
    public float m_dropoffTime = 3;
    private short peopleInBoat = 0, localPeopleInBoat = 0;
    private bool inrange;
    public GameObject m_Dock1 = null, m_Dock2 = null, m_Dock3 = null;

    void Start ()
    {
        m_countdownTimer.gameObject.SetActive(false);
        m_passenger.SetActive(false);
        m_passenger2.SetActive(false);
        m_passenger3.SetActive(false);
        m_Dock1.SetActive(false);
        m_Dock2.SetActive(false);
        m_Dock3.SetActive(false);
    }

    void OnTriggerEnter ( Collider collider )
    {
        if(collider.gameObject.tag == "Swimmer")
        {
            m_timer = 0;
        }
        else if(collider.gameObject.tag == "DropZone")
        {
            m_timer = 0;
        }
    }
 
    void OnTriggerStay ( Collider collider )
    {
        if(collider.gameObject.tag == "Swimmer")
        {
            m_countdownTimer.gameObject.SetActive(true);          
            m_timer += Time.deltaTime;
            m_countdownTimer.fillAmount = m_timer / m_rescueTime;
            if(m_timer >= m_rescueTime)
            {
                m_countdownTimer.gameObject.SetActive(false);
                Destroy(collider.gameObject);
                PickupSwimmer();
            }
        }
        else if(collider.gameObject.tag == "DropZone" )
        {
            if(localPeopleInBoat != 0)
            {
                m_countdownTimer.gameObject.SetActive(true);
                m_timer += Time.deltaTime;
                m_countdownTimer.fillAmount = m_timer / m_rescueTime;
            }             
           
            if(m_timer >= m_dropoffTime)
            {
                m_countdownTimer.gameObject.SetActive(false);
                DropoffSwimmer();
            }
        }
    }
    private void OnTriggerExit ( Collider other )
    {
        m_countdownTimer.gameObject.SetActive(false);
        m_timer = 0;
    }

    public void PickupSwimmer (  )
    {
        peopleInBoat++;
        localPeopleInBoat++;
        switch(localPeopleInBoat)
        {
            case 1:
                m_passenger.SetActive(true);
                break;
            case 2:
                m_passenger2.SetActive(true);
                break;
            case 3:
                m_passenger3.SetActive(true);
                break;

        };
    }
    public void DropoffSwimmer ()
    {
        switch(peopleInBoat)
        {
            case 1:
                m_Dock1.SetActive(true);
                m_passenger.SetActive(false);
                GameObject.Find("Canvas").GetComponent<Score>().UpdateScore(localPeopleInBoat);
                break;
            case 2:
                m_Dock1.SetActive(true);
                m_Dock2.SetActive(true);
                m_passenger.SetActive(false);
                m_passenger2.SetActive(false);
                GameObject.Find("Canvas").GetComponent<Score>().UpdateScore(localPeopleInBoat);
                break;
            case 3:
                m_Dock1.SetActive(true);
                m_Dock2.SetActive(true);
                m_Dock3.SetActive(true);
                m_passenger.SetActive(false);
                m_passenger2.SetActive(false); 
                m_passenger3.SetActive(false);
                GameObject.Find("Canvas").GetComponent<Score>().UpdateScore(localPeopleInBoat);
                localPeopleInBoat = 0;
                break;

        };
       
        localPeopleInBoat = 0;

    }
}