using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerDownHandler
{
    public Player Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Player.SpawnBomb();
    }
}
