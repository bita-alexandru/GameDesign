using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float cooldown;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (timer >= cooldown)
        {
            int type = Random.Range(0, enemies.Length);
            GameObject enemy = enemies[type];

            float x = Random.Range(-5, 5);
            float y = 7;

            Vector3 position = new Vector3(x, y);
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            GameObject _enemy = Instantiate(enemy);
            _enemy.GetComponent<Transform>().position = position;
            _enemy.GetComponent<SpriteRenderer>().color = color;

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
