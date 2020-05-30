using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer sprite;

    float velocity = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        int coin = Random.Range(0, 100);
        if (coin <= 15)
        {
            sprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/coin");
            rb2d.tag = "Coin";
        }
        int rnd = Random.Range(-18, -1);
        rb2d.transform.position = new Vector2(rnd, 0.22f);
        rb2d.velocity = Vector2.down * velocity;
    }

    void Update()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d.position.y <= -12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
