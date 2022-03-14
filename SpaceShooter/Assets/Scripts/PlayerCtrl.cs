using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip RunF;
    public AnimationClip RunB;
    public AnimationClip RunR;
    public AnimationClip RunL;
    public AnimationClip SprintF;
}
public class PlayerCtrl : MonoBehaviour
{
    public Anim anim;
    [SerializeField] Animation playerAni;
    private float h = 0f, v = 0f,r=0f;
    private Transform tr;
    public float moveSpeed = 9.0f;
    public float rotSpeed = 80f;
    void Start()
    {
        playerAni = GetComponent<Animation>();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        PlayerMoveAndRotate();
        UpdateAnimation();
        Sprint();
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 15f;
            playerAni.CrossFade(anim.SprintF.name, 0.3f);
        }
        else
        {
            moveSpeed = 9f;
        }
    }

    private void UpdateAnimation()
    {
        if (h > 0.1f)
        {
            playerAni.CrossFade(anim.RunR.name, 0.3f);
        }
        else if (h < -0.1f)
        {
            playerAni.CrossFade(anim.RunL.name, 0.3f);
        }
        else if (v > 0.1f)
        {
            playerAni.CrossFade(anim.RunF.name, 0.3f);
        }
        else if (v < -0.1f)
        {
            playerAni.CrossFade(anim.RunB.name, 0.3f);
        }
        else
        {
            playerAni.CrossFade(anim.idle.name, 0.3f);
        }
       
    }
    private void PlayerMoveAndRotate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        Debug.Log("h " + h.ToString());
        Debug.Log("v " + v.ToString());
        Vector3 moveDir = (h * Vector3.right) + (v * Vector3.forward);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
        tr.Rotate(Vector3.up * r * Time.deltaTime * rotSpeed, Space.Self);
    }
}
