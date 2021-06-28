using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent nav;
    float time;
    private bool Run;
    private bool Look;
    private bool Attack;
    private Animator anim;
    public Slider slider;
    public float maxHp;
    public float hp;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        anim = GetComponent<Animator>();
        this.GetComponent<NavMeshAgent>().enabled = true;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = maxHp;
        slider.value = hp;
        if(Look==true)
        {
            this.transform.LookAt(target);
        }
        
        if (Run == true)
        {
            nav.SetDestination(target.position);
            anim.SetBool("Run", true);
            Debug.Log("Run_T");
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Attack == true && time >= 2)
        {
            anim.SetBool("Attack", true);
            Debug.Log("Attack_T");
            time = 0;
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        time += Time.deltaTime;

        if (hp <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 10;
        }
    }

    public void ZBrun()
    {
        Run = true;
        Attack = false;
        Debug.Log("Run");
    }

    public void Attact()
    {
        Run = false;
        Attack = true;
        Debug.Log("Attack");
    }
    public void See()
    {
        Look = true;
        Debug.Log("Look");
    }

}
