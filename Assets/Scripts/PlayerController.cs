using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;
    public float speed = 9f;
    public float boundaryRange = 8f;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (gm.gameIsActive)
        {
            MoveAndRotatePlayer();
        }  
    }
    void MoveAndRotatePlayer()
    {
        // clump and move player
        float movementX = Input.GetAxis("Horizontal");
        float xClumped = Mathf.Clamp(rb.position.x, -boundaryRange, boundaryRange);

        rb.MovePosition(new Vector2(xClumped, rb.position.y) + Vector2.right * movementX * speed * Time.fixedDeltaTime);
        // rotate top-down
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }
}
