using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public static Waves instance;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    private void Awake()
    {
        amplitude = Random.Range(0.25f,0.65f);
        length = Random.Range(1,7);
        speed = Random.Range(1,2);
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Debug.Log("Instance Already existsm destroying gameobject");
            Destroy(this);
        }
    }

    private void Update ()
    {
        offset += Time.deltaTime * speed;

    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }
}
