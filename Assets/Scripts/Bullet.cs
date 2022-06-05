using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToBulletDestroy, damage, speed;

    void Start()
    {
        Destroy(gameObject, timeToBulletDestroy);    
    }


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
