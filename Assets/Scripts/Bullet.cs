using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;
    public float velocity = 5.0f;
    public float lifetime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

        Vector2 force = -player.transform.up * velocity;
        rb.AddForce(-force);
        Destroy(gameObject, lifetime);
    }
}
