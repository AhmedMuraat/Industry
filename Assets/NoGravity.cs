using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : MonoBehaviour
{
    Rigidbody[] LimbsRigidBodies;

    void GetRigidBodies()
    {
        LimbsRigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    void GravityOff()
    {
        foreach( Rigidbody rigid in LimbsRigidBodies )
        {
            rigid.isKinematic = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetRigidBodies();
        GravityOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
