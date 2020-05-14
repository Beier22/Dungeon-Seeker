using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    float despawnTime = 0.4f;
    public float speed = 20f;
    public Rigidbody2D FireballBody;

    // Start is called before the first frame update
    void Start()
    {
        
        FireballBody.velocity = transform.right * speed;

    }

    // Update is called once per frame  
    void Update()
    {

        Destroy(gameObject, despawnTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Destroy(gameObject);
    }
}
