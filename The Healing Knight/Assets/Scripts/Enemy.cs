using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rbEnemy;
    int speed = -1;
    //[SerializeField] private Sprite sag, sol;

    private void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyYon")
        {
            if (speed == 1)
            {
                speed = -1;
                //GetComponent<SpriteRenderer>().sprite = sol;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            else
            {
                speed = 1;
                //GetComponent<SpriteRenderer>().sprite = sag;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        if (other.gameObject.tag == "Player")
        {
            //atackdusman
            speed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (transform.localScale.x == -1)
            {
                speed = 1;
            }
            else
            {
                speed = -1;
            }
        }
    }
}

