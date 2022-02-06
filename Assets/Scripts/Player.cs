using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float hInput;
    private float vInput;

    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float rotForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
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
}
