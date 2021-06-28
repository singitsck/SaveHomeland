using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    float time;
    public float maxHp;
    public float hp;
    public Slider slider;
    public AudioClip explosion;
    public GameObject Lose;
    public GameObject explosionEffect;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        slider.maxValue = maxHp;
        slider.value = hp;
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(explosion, transform.position, 1f);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        if (hp <= 0 && time >= 10)
        {
            Time.timeScale = 0;
            Lose.SetActive(true);
            time = 0;
        }
        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hp -= 10;
        }
    }
}
