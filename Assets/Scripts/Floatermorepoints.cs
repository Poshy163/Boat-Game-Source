using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatermorepoints:MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    private int FloaterCount = 1;
    private float waterDrag = 0.99f;
    private float waterAngularDrag = 0.5f;
    private void FixedUpdate ()
    {
        rigidbody.AddForceAtPosition(Physics.gravity / FloaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = Waves.instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01(waveHeight - transform.position.y) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f,Mathf.Abs(Physics.gravity.y) * displacementMultiplier,0f),transform.position,ForceMode.Acceleration);
            rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
         
        }
    }
}
