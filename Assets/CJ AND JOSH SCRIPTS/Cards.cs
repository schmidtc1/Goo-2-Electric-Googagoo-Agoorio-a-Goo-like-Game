using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cards : MonoBehaviour
{
    public GameControllerCJ game;
    public Cards thisCard;
    public int position;

    private void OnMouseDown()
    {
        game.PlayCard(thisCard);
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
