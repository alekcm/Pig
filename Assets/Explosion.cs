using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.ChangeHealth(-20);
        }

        if (other.CompareTag("Dog"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
