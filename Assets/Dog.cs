using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dog : MonoBehaviour
{
    public Sprite LeftSprite, RightSprite, UpSprite, DownSprite;
    public SpriteRenderer SpriteRenderer;
    Vector2 CurrentDirection = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        transform.Translate(CurrentDirection * Time.deltaTime);
    }
    
    IEnumerator ChangeDirection()
    {
        int i = Random.Range(1, 4);
        switch (i)
        {
            case 1:
                CurrentDirection = new Vector2(1, 0);
                SpriteRenderer.sprite = RightSprite;
                break;
            case 2:
                CurrentDirection = new Vector2(-1, 0);
                SpriteRenderer.sprite = LeftSprite;
                break;
            case 3:
                CurrentDirection = new Vector2(0, 1);
                SpriteRenderer.sprite = UpSprite;
                break;
            case 4:
                CurrentDirection = new Vector2(0, -1);
                SpriteRenderer.sprite = DownSprite;
                break;
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(ChangeDirection());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            CurrentDirection *= -1;
            switch (SpriteRenderer.sprite.name)
            {
                case "dog_0":
                    SpriteRenderer.sprite = LeftSprite;
                    break;
                case "dog_1":
                    SpriteRenderer.sprite = RightSprite;
                    break;
                case "dog_3":
                    SpriteRenderer.sprite = DownSprite;
                    break;
                case "dog_4":
                    SpriteRenderer.sprite = UpSprite;
                    break;
                
            }
        }

    }
}
