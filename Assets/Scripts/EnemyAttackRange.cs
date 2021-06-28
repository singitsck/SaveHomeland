using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    private bool Run;
    Enemy move;

    private void Start()
    {
        Run = true;
        move = transform.parent.gameObject.GetComponent<Enemy>();
    }

    private void Update()
    {
        if(Run==true)
        {
            move.ZBrun();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            move.Attact();
            Run = false;
        }
    }
}
