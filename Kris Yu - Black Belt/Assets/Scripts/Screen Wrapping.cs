using UnityEngine;

public class ScreenWrapRigidbody2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private float screenHalfWidth;
    public float buffer = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenHalfWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x < -screenHalfWidth - buffer)
        {
            pos.x = screenHalfWidth + buffer;
            rb.position = new Vector2(pos.x, pos.y);
        }
        else if (pos.x > screenHalfWidth + buffer)
        {
            pos.x = -screenHalfWidth - buffer;
            rb.position = new Vector2(pos.x, pos.y);
        }
    }
}