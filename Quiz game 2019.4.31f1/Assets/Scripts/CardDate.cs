using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardDate 
{
    [SerializeField] private string _Identifier;
    [SerializeField] private Sprite _Sprite;
    public string Identifier => _Identifier;
    public Sprite Sprite => _Sprite;
}
