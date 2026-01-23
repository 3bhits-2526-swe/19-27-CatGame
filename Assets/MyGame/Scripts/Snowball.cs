using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * speed;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Schneeball hat Trigger betreten");
    }
}
