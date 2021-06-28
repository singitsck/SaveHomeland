using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public GameObject Fire;

    void Start()
    {
        hp = maxHp;
    }

    void Update()
    {
        if (hp < 4)
        {
            Fire.SetActive(true);
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 1;
        }
    }
}
