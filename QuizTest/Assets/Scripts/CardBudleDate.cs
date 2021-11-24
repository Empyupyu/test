using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AnswerBudleDate", menuName = "AnswerBudleDate")]
public class CardBudleDate : ScriptableObject
{
    [SerializeField] private List<CardDate> _AnswerDates;
    public List <CardDate> AnswerDates => _AnswerDates;
}
