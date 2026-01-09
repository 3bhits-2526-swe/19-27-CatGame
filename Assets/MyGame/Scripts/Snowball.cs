using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (speed == 0)
            speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        speed = 0f;
        Debug.Log("Schneeball hat Trigger betreten");
    }
}
