using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20f;
    public float Speed = 1000f;
    [SerializeField]
    private Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.AddForce(transform.forward * Speed);
        //rbody.AddRelativeForce(Vector3.forward * Speed);
    }



}
