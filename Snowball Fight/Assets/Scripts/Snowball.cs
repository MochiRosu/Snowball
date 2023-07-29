using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D theRB;
    public GameObject snowballEffect;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(snowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
