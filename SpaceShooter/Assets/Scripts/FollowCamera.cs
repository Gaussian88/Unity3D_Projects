using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float height=5f;
    [SerializeField]
    private float distance = 7f;
    [SerializeField]
    private float moveDamping = 10f;
    [SerializeField]
    private float rotDamping = 15f;
    [SerializeField]
    public float targetOffset = 1f;
    Transform tr;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
        
    }
    void LateUpdate()
    {
        targetFollow();
    }

    private void targetFollow()
    {
        var CamPos = target.position - (target.forward * distance) + (target.up * height);

        tr.position = Vector3.Slerp(tr.position, CamPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotDamping);
        tr.LookAt(target.position + (target.up * targetOffset));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(target.position + (target.up * targetOffset), 0.1f);
        Gizmos.DrawLine(target.position + (target.up * targetOffset), tr.position);

    }
}
