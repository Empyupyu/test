using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] private CardsDeck _Cards;
    [SerializeField] private Text _Text;

    public UnityEvent OnCorrectAnswer;
    public UnityEvent OnWrondAnswer;
  
    private CardDate _CorrectAnswer;

    public void GetCorrectCard()
    {  
        _CorrectAnswer = _Cards.CorrectCard;
        AskQuestion();
    }
    public void TryToAnswer(Card answer)
    {
        if (_CorrectAnswer != answer.CardDate)
        {
            Wrong();
            return;
        }
        Correct();
    }
    private void AskQuestion()
    {
        _Text.text = $"Find {_CorrectAnswer.Identifier}";
        FindObjectOfType<DotEffector>().FadeInText(_Text);     
    }
    public void ResetText()
    {
        Color color = _Text.color;
        color.a = 0;
        _Text.color = color;
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
