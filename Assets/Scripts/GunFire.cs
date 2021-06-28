using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject shell;
    public Transform FireStart;
    public float shellSpeed = 50;
    public GameObject OpenFire;
    public AudioClip Fire;

    Vector3 moveAmount;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(OpenFire, FireStart.position, FireStart.rotation);
            AudioSource.PlayClipAtPoint(Fire, transform.position, 1f);
            GameObject fireInstance = GameObject.Instantiate(shell, FireStart.position, FireStart.rotation);
            fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * shellSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount);
    }
}
