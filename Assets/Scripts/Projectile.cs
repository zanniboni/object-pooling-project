using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 velocity = new Vector2(1.0f, 0.0f);
    public SpriteRenderer renderer = null;
    public float lifeTime = 3.0f;
    private float deltaTime = 0.0f;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReturnToPooling();
    }

    private void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
        deltaTime += Time.deltaTime;
        if (deltaTime >= lifeTime)
            ReturnToPooling();
    }

    public void Shoot(bool isRight)
    {
        renderer.flipX = !isRight;
        if (!isRight)
            velocity *= -1;
    }

    private void ReturnToPooling()
    {
        deltaTime = 0.0f;
        velocity = new Vector2(6.0f, 0.0f);
        renderer.flipX = false;
        ObjectPooling.ReturnProjectile(this);
    }





}