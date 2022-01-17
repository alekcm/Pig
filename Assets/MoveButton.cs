using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Player Player;
    public Sprite MoveSprite;
    public Vector2 vector;
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
        Player.GetComponent<SpriteRenderer>().sprite = MoveSprite;
        Player.MoveVector = vector;
        Player.BombMoveVector = vector*4;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Player.MoveVector = new Vector2(0,0);
    }
}
