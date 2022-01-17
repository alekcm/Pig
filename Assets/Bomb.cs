using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector2 MoveVector;

    public GameObject Explosion;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(MoveVector * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Explode();
    }

    public void Explode()
    {
        GameObject _explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
