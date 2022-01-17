using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Text HealthText,CoinText;
    public Player Player;

    public GameObject Dog, Coin;
    public int TimeForDog, TimeForCoin;

    public GameObject[] SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = Player.Health.ToString();
        CoinText.text = "0";
        StartCoroutine(SpawnObjectEveryTime(Dog, TimeForDog));
        StartCoroutine(SpawnObjectEveryTime(Coin, TimeForCoin));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float health)
    {
        Player.Health += health;
        HealthText.text = Convert.ToString(Convert.ToInt32(HealthText.text) + health);
        if (Player.Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void ChangeCoin(float coin)
    {
        CoinText.text = Convert.ToString(Convert.ToInt32(CoinText.text) + coin);
    }

    public void Spawn(GameObject obj)
    {
        int i = Random.Range(0,SpawnPoint.Length);
        Instantiate(obj, SpawnPoint[i].transform.position, Quaternion.identity);
    }

    IEnumerator SpawnObjectEveryTime(GameObject obj, float i)
    {
        yield return new WaitForSeconds(i);
        Spawn(obj);
        StartCoroutine(SpawnObjectEveryTime(obj, i));
    }
}
