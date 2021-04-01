using UnityEngine;
using System.Collections;
public class BoatMovement:MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private GameObject canva;
    public Rigidbody Boat;
    private void Awake ()
    {
        Boat = gameObject.GetComponent<Rigidbody>();
        m_Rigidbody = GetComponent<Rigidbody>();
        canva = GameObject.Find("Canvas");
    }
    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }
    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }
    private void Update ()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");     

    }
    private void FixedUpdate ()
    {
        if(canva.GetComponent<Score>().countdown == false)
        {
            Move();
            Turn();
        }
        
    }
    private void Move ()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.AddForce(movement * 10, ForceMode.Impulse);
    }
    private void Turn ()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(0, turn * 50 * Time.deltaTime ,0));
    }



    public void SpeedUp(float speed, float time)
    {

        StartCoroutine(SpeedIncrease(speed,time));
    }


    public void Slow(float speed,float time)
    {
        StartCoroutine(SlowDown(speed,time));
    }

    public void HitBox(float time)
    {
        StartCoroutine(HitBoxNil(time,gameObject.GetComponent<BoxCollider>()));
    }

    public IEnumerator HitBoxNil ( float time, BoxCollider col )
    {
        col.isTrigger = true;
        yield return new WaitForSeconds(time);
        col.isTrigger = false;

    }

    public IEnumerator SlowDown (float speed,float time)
    {
        m_Speed -= speed;
        yield return new WaitForSeconds(time);
        m_Speed += speed;
    }


    public IEnumerator SpeedIncrease(float speed, float time)
    {
        m_Speed += speed;
        yield return new WaitForSeconds(time);
        m_Speed -= speed;
    }
    
}