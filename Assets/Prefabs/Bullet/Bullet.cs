using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rigidbullet;
    [SerializeField]
    float lftime = 15f;
    void Start()
    {
        Invoke("DeleteBul", lftime);
    }

    void Update()
    {

    }

    void DeleteBul()
    {
        Destroy(gameObject);
    }
}
