using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private float randomTime = 21f;
    private float timer = 0f;
    private Vector2 randomDirection;

    [SerializeField]
    private float moveForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomTime = Random.Range(16f, 24f);
        NewDirection();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > randomTime)
        {
            NewDirection();
            timer = 0;
        }
        Vector2 moveVector = randomDirection * moveForce * Time.fixedDeltaTime;
        rb.AddForce(moveVector);
    }

    private void NewDirection()
    {
        Vector2 randomPoint = new Vector2(Random.Range(-36f, 36f), Random.Range(-36f, 36f));
        Vector2 transformPos = transform.position;
        randomDirection = (randomPoint - transformPos).normalized;


    }
}
