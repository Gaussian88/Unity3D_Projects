using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject BulletPrefab;
    public ParticleSystem cartridge;
    private ParticleSystem muzzleFlash;
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
    void Fire()
    {
        Instantiate(BulletPrefab, firePos.position, firePos.rotation);
        cartridge.Play();
        muzzleFlash.Play();
    }
}
