using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;
    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag =="BULLET")
        {
            Destroy(coll.gameObject);
            ShowEffect(coll);
        }
    }
    void ShowEffect(Collision coll)
    {
        //ContactPoint contact = coll.contacts[0];
        ContactPoint contact = coll.contacts[0];
        //법선벡터가 이루는 회전 각도를 추출 
        //어떠한 직선이나 평면의 기울기나 경사각을 표현할 때, 
        //해당 직선이나 평면에 수직인 벡터를 사용
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward,contact.normal);
        Instantiate(sparkEffect, contact.point, rot);
    }
}
