using System;
using UnityEngine;

public class SchneeballBewegung : MonoBehaviour
{
    public Snowball snowball1;
    public Snowball snowball2;
    public Snowball snowball3;
    public Snowball snowball4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliosion detected");
        snowball1.speed = 0;
        snowball2.speed = 0;
        snowball3.speed = 0;
        snowball4.speed = 0;
    }
}
