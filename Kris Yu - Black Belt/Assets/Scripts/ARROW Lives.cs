using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARROWLives : MonoBehaviour
{
    public List<GameObject> Heart;
    private int lives = 3;
    public GameObject HealthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava") && lives > 0)
        {
            lives--;

            if (lives < Heart.Count && Heart[lives] != null)
            {
                Heart[lives].SetActive(false);
            }
        }
    }
}
