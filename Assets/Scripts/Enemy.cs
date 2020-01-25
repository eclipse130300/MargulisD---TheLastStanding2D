using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody2D enemyRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        enemyRb.MovePosition(enemyRb.position + Vector2.down * enemySpeed * Time.fixedDeltaTime);
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            gameManager.LosingSecuence();
        }
        else
        {
            Destroy(gameObject);
            gameManager.UpdateScore(20);
        }
    }
}
