using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookRange : MonoBehaviour
{
    Enemy move;

    private void Start()
    {
        move = transform.parent.gameObject.GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.See();
        }
    }
}
