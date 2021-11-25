using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizHost : MonoBehaviour
{
    [SerializeField] private CardsDeck _Deck;
    [SerializeField] private QuestionBoard _Board;

    public UnityEvent OnCorrectAnswer;
    public UnityEvent OnWrondAnswer;
  
    private CardDate _CorrectAnswer;

    public void GetCorrectCard()
    {  
        _CorrectAnswer = _Deck.CorrectCard;
        _Board.Visualisation(_CorrectAnswer.Identifier);
    }
    public void CheckAnswer(Card answer)
    {
        if (_CorrectAnswer != answer.CardDate)
        {
            Wrong();
            return;
        }
        Correct();
    }
    private void Correct()
    {
        OnCorrectAnswer.Invoke();
    }
    private void Wrong()
    {
        OnWrondAnswer.Invoke();
    }
}
