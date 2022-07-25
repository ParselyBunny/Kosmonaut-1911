using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool shootInput;
    private AudioSource gunshotSFX;

    public Transform bulletPrefab;
    public Animator muzzleFlash;
    public int capacity = 7000;
    public int rounds = 7000;
    public float muzzleVelocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunshotSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pointToMouse();
        shootInput = Input.GetMouseButtonDown(0);

        if (shootInput && rounds > 0) {
            shoot();
        }
    }

    void shoot() {
        rounds--;
        thrustForward(muzzleVelocity);
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        muzzleFlash.Play("muzzleFlash");
        gunshotSFX.Play();
    }

    void thrustForward(float amount) {
        Vector2 force = transform.up * amount;

        rb.AddForce(-force);
    }

    void pointToMouse() {
        // Rotation
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }
}
