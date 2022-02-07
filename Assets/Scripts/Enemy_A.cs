using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject bullet;

    private SpriteRenderer sr;
    public Sprite[] sprites;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    public TargetSystem targetSystemScript;
    public Transform targetSystem;
    public Transform target; //

    private bool seekMode = true;

    private const float fireRate = .15f;
    private float timeSinceLastBullet = 0f;

    private const float attackRate = 2f;
    private float timeSinceLastAttack = 0f;

    private int bulletCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[Random.Range(0, 3)];
        if (World.targetSystem)
        {
            targetSystem = World.targetSystem;
            targetSystemScript = World.targetSystem.GetComponent<TargetSystem>();
        }
        
        target = targetSystemScript.targets[Random.Range(0, targetSystemScript.targets.Length)];
        
    }

    private void FixedUpdate()
    {
        timeSinceLastBullet += Time.fixedDeltaTime;
        timeSinceLastAttack += Time.fixedDeltaTime;
        if (seekMode == true && target)
        {
            Vector2 targetDirection = (target.transform.position - transform.position);
            Vector2 targetNormalized = targetDirection.normalized;
            float angle = Vector3.Cross(targetNormalized, transform.up).z;

            rb.angularVelocity = -angle * rotationSpeed * Time.fixedDeltaTime;
            rb.AddForce(transform.up * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Vector2 targetDirection = (targetSystem.transform.position - transform.position);
            Vector2 targetNormalized = targetDirection.normalized;
            float angle = Vector3.Cross(targetNormalized, transform.up).z;

            rb.angularVelocity = -angle * rotationSpeed * Time.fixedDeltaTime;

            if (timeSinceLastBullet >= fireRate) //  && timeSinceLastAttack >= attackRate
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        timeSinceLastBullet = 0;
        timeSinceLastAttack = 0;
        Instantiate(bullet, transform.position, transform.rotation);
        bulletCount += 1;
        if (bulletCount >= 3)
        {
            target = targetSystemScript.targets[Random.Range(0, targetSystemScript.targets.Length)];
            seekMode = true;
            bulletCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            seekMode = false;
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
