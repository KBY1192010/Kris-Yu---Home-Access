using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public float riseSpeed = 2;

    void Start()
    {
        StartCoroutine("LavaRise");
    }

    public IEnumerator LavaRise()
    {
        yield return new WaitForSeconds(0.1f);
        transform.localScale += new Vector3(0, 0.2f, 0);

        StartCoroutine("LavaRise");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

}

