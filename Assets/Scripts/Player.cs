using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float hInput;
    private float vInput;
    public SpriteRenderer sr;
    public Sprite[] sprites;
    public Transform targetSystem;

    public Transform leftGun;
    public Transform rightGun;

    public GameObject bullet;
    private const float fireRate = .06f;
    private float timeSinceLastBullet = 0f;

    private bool leftFire = true;

    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float rotForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        World.targetSystem = targetSystem;
        sr.sprite = sprites[World.playerSelection];
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        timeSinceLastBullet += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") >= 1 && timeSinceLastBullet >= fireRate)
        {
            timeSinceLastBullet = 0;
            Fire();
        }
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerRot = transform.up;
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        Vector2 moveDirection = new Vector2(hInput, vInput).normalized;
        Vector2 moveVector = moveDirection * moveForce * Time.fixedDeltaTime;
        rb.AddForce(moveVector);

        transform.up = direction;

    }

    void Fire()
    {
        if (leftFire)
        {
            leftFire = false;
            Instantiate(bullet, leftGun.position, transform.rotation);
        }
        else
        {
            leftFire = true;
            Instantiate(bullet, rightGun.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);

        }
    }
}
