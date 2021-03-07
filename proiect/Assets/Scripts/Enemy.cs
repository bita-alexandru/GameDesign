using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 1;
    public float speed = 3;
    public int type = 1;
    public GameObject bullet;
    public float cooldown = 1;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }

        Vector3 movement = new Vector3(0, speed * Time.deltaTime);

        transform.Translate(movement);
    }

    void Shoot()
    {
        if (timer >= cooldown)
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            position.y -= 0.7f;

            GameObject _bullet = Instantiate(bullet, position, rotation);
            _bullet.GetComponent<Bullet>().threshold = -5;
            _bullet.GetComponent<SpriteRenderer>().color = Color.magenta;
            _bullet.GetComponent<Bullet>().tag = "EnemyBullet";
            _bullet.GetComponent<Bullet>().speed = 5;

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            hp--;

            if (hp <= 0)
            {
                FindObjectOfType<Player>().GetComponent<Player>().score++;

                FindObjectOfType<Score>().GetComponent<Score>().UpdateText(
                    FindObjectOfType<Player>().GetComponent<Player>().hp,
                    FindObjectOfType<Player>().GetComponent<Player>().score
                );
                Destroy(this.gameObject);
            }
        }    
    }
}
