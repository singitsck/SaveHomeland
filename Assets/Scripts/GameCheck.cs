using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCheck : MonoBehaviour
{
    public GameObject Win;
    public Text Enemy;
    private GameObject[] EnemyNo;
    public float restartDelay;
    private float restartTime;


    // Update is called once per frame
    void Update()
    {
        EnemyNo = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy.text = "Zombie NO= " + EnemyNo.Length;

        if (EnemyNo.Length <= 0)
        {
            restartTime += Time.deltaTime;
            if (restartTime >= restartDelay)
            {
                Time.timeScale = 0;
                Win.SetActive(true);
            }
        }
    }
}
