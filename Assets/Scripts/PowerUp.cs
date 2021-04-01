using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUp : MonoBehaviour
{
    private readonly float SpeedIncrese = 15f;
    private readonly float Time = 3f;
    private readonly float SpeedDecrease = 10f;
    private void OnCollisionEnter (Collision collision)
    {
        switch(gameObject.name)
        {
            case "Speed":
            collision.gameObject.GetComponent<BoatMovement>().SpeedUp(SpeedIncrese,Time);
                break;
            case "Slow":
                collision.gameObject.GetComponent<BoatMovement>().Slow(SpeedDecrease, Time);
                break;
            case "HitBox":
                collision.gameObject.GetComponent<BoatMovement>().HitBox(Time);
                break;
        }                 
        Destroy(gameObject);       
    }

}