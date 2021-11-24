using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Vector2 _Size;
    public Vector2 Size => _Size;

    private Card _Card;
    public Card Card => _Card;

    public void SetDate(Card card)
    {
        _Card = card;
    }
}
