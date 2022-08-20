using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastPosition;
    private AudioSource gunshotSFX;
    private bool shootInput;
    public Transform bulletPrefab;
    public Animator muzzleFlash;
    public int capacity = 7000;
    public int rounds = 7000;
    public float muzzleVelocity = 5.0f;
    public float oxygenTime = 10.00f;
    public float currentDistanceTraveled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunshotSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pointSelfToMouse();
        shootInput = Input.GetMouseButtonDown(0);

        if (shootInput && rounds > 0)
            shoot();

        updateDistanceTraveled();
        updateOxygen();
    }

    void shoot() {
        rounds--;
        thrustForward(muzzleVelocity);
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        muzzleFlash.Play("muzzleFlash");
        gunshotSFX.Play();
    }

    void updateDistanceTraveled() {
        if (lastPosition != null) {
            currentDistanceTraveled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
        } else {
            lastPosition = transform.position;
        }
    }

    void updateOxygen() {
        if (oxygenTime <= 0f) {
            Debug.Log("You ran out of air!");
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        } else {
            oxygenTime -= 0.01f;
        }
    }

    void thrustForward(float amount) {
        Vector2 force = transform.up * amount;
        rb.AddForce(-force);
    }

    void pointSelfToMouse() {
        // Rotation
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
    }
}
