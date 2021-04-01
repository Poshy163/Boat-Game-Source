using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;


    private void Start ()
    {
        try
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        catch { }
    }

    private void FixedUpdate ()
    {
        float waveHeight = Waves.instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01(waveHeight - transform.position.y) * displacementAmount;
            rigidbody.AddForce(new Vector3(0f,Mathf.Abs(Physics.gravity.y) * displacementMultiplier,0f),ForceMode.Acceleration);
        }
    }
}
