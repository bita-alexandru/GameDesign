﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 4;
    public float speed = 5;
    public GameObject bullet;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        Vector3 movement = new Vector3(0, 0);

        /* Miscarea orizontala */
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            movement += new Vector3(-speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += new Vector3(speed * Time.deltaTime, 0);
        }


        /* Miscarea verticala */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += new Vector3(0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += new Vector3(0, -speed * Time.deltaTime);
        }

        // Normalizam vectorul obtinut ca sa nu ne miscam mai rapid pe diagonala
        movement = movement.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            position.y += 0.7f;

            GameObject _bullet = Instantiate(bullet, position, rotation);
            _bullet.GetComponent<Bullet>().threshold = 5;
            _bullet.GetComponent<Bullet>().tag = "PlayerBullet";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            hp--;

            FindObjectOfType<Score>().GetComponent<Score>().UpdateText(hp, score);

            if (hp <= 0)
            {
                FindObjectOfType<Score>().GetComponent<Score>().GameOver(score);
                Destroy(FindObjectOfType<Spawner>().gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
