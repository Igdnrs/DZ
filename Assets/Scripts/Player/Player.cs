using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float jumpForce = 10f;

    [SerializeField]
    Bullet prefBullet;
    [SerializeField]
    Transform spawnBullet;
    [SerializeField]
    float impulse = 80f;


    Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Jump();
        Fire();
    }
    void Mover()
    {
        if (rb == null) rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) return;

        Vector3 vecVel = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            vecVel += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vecVel -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vecVel -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vecVel += transform.right;
        }
        vecVel.Normalize();
        rb.AddForce(vecVel * Time.deltaTime * moveSpeed, ForceMode.VelocityChange);
    }

    void Jump()
    {
        if (rb == null) rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) return;

        if (!Input.GetKeyDown(KeyCode.Space))
            return;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefBullet.gameObject);
            bullet.transform.position = spawnBullet.position;
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = gameObject.transform.forward * impulse;
        }
    }
}
