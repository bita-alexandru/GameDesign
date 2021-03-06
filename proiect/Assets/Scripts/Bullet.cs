using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 4)
        {
            Destroy(this.gameObject);
        }

        Vector3 movement = new Vector3(0, speed * Time.deltaTime);

        transform.Translate(movement);
    }
}
