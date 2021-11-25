using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDeck : MonoBehaviour
{
    [SerializeField] private CardBudleDate[] _CardsBudles;
    [SerializeField] private Card _Card;

    private List <CardDate> _ActiveCards;
    private List<CardDate> _ActivetedCards;
    private CardBudleDate _SelectBudle;
    private CardDate _CorrectCard;
    private CardDate _ValidityCard;
    private Cell[,] _Cells = new Cell[,] { };
    public CardDate CorrectCard => _CorrectCard;

    private void BundleSelect()
    {
        _SelectBudle = _CardsBudles[Random.Range(0, _CardsBudles.Length)];
        _ActivetedCards = new List<CardDate>();
        _ActiveCards = new List<CardDate>();
    }
    public void Create(Cell[,] cells, bool initialisation = false)
    {
        if (initialisation) BundleSelect();
        _Cells = cells;
        _CorrectCard = GetRandomCard();
    }
    private CardDate GetRandomCard()
    {  
        _ActiveCards = new List<CardDate>();

        FindCard();
        ShowCard();

        return _CorrectCard;
    }
    private void ShowCard()
    {
        int index = 0;
        foreach (var cell in _Cells)
        {
            var card = Instantiate(_Card, cell.transform);
            cell.SetDate(card);
            card.SetDate(_ActiveCards[index]);
            index++;
        }
    }
    private void FindCard()
    {
        int random = Random.Range(0, _SelectBudle.AnswerDates.Count);

        _CorrectCard = _SelectBudle.AnswerDates[random];

        foreach (var locked in _ActivetedCards)
        {
            if (_CorrectCard == locked)
            {
                FindCard();
                return;
            }
        }
        _ActiveCards.Add(_CorrectCard);
        _ActivetedCards.Add(_CorrectCard);

        for (int i = 1; i < _Cells.Length; i++)
        {   
            var answer = OtherCards();

            _ActiveCards.Add(answer);
        }
        Shuffle();
    }
    private CardDate OtherCards()
    {
        int random = Random.Range(0, _SelectBudle.AnswerDates.Count);
        if (_CorrectCard == _SelectBudle.AnswerDates[random]) return OtherCards();

        return  _ValidityCard = _SelectBudle.AnswerDates[random];
    }
    private void Shuffle()
    {
        for (int i = _ActiveCards.Count - 1; i >= 1; i--)
        {
            int random = Random.Range(0, _ActiveCards.Count);
            var temp = _ActiveCards[random];
            _ActiveCards[random] = _ActiveCards[i];
            _ActiveCards[i] = temp;
        }
    }
}
