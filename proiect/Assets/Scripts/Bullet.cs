using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(threshold > 0)
        {
            if(transform.position.y > threshold)
            {
                Destroy(this.gameObject);
            }
        }
        else if(threshold < 0)
        {
            if (transform.position.y < threshold)
            {
                Destroy(this.gameObject);
            }
        }

        Vector3 movement = new Vector3(0, speed * Time.deltaTime);

        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.tag.Contains("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
