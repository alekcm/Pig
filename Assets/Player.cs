using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GameManager;
    public float Health = 100;
    public Vector2 MoveVector;

    public Vector2 BombMoveVector;

    public GameObject BombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(MoveVector * Time.deltaTime);
    }

    public void SpawnBomb()
    {
        if (Convert.ToInt32(GameManager.CoinText.text) >= 10)
        {
            GameManager.ChangeCoin(-10);
            GameObject bomb = Instantiate(BombPrefab, transform.position, Quaternion.identity);
            bomb.GetComponent<Bomb>().MoveVector = BombMoveVector;
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.ChangeCoin(5);
        }
        if (other.gameObject.tag == "Dog")
            GameManager.ChangeHealth(-50);
    }
}
