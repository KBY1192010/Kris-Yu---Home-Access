using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARROWLives : MonoBehaviour
{
    public List<GameObject> Heart;
    public int lives = 3;
    public GameObject HealthBar;
    public float jumpForce = 12f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;

            if (lives < Heart.Count && Heart[lives] != null)
            {
                Heart[lives].SetActive(false);
            }
        }

        if (lives <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
