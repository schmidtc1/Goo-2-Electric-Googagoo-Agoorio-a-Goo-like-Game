using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public GameControllerCJ game;
    public Sprite endTurn1;
    public Sprite endTurn2;
    public SpriteRenderer picture;
    void OnMouseDown()
    {
        picture.sprite = endTurn2;
    }
    void OnMouseUp()
    {
        picture.sprite = endTurn1;
        game.startNewTurn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
