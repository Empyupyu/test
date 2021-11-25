using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LevelDate")]
[Serializable]
public class LevelDate: ScriptableObject
{
    [SerializeField] private int _Column;
    [SerializeField] private int _Row;

    public int Column => _Column;
    public int Row => _Row;
}
