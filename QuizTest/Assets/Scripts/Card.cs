using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Icon;
    private DotEffector _DotEffector;
    private CardDate _CardDate;
    public CardDate CardDate => _CardDate;
    private Answer _Answer;
    private bool _IsDisable;

    private void OnMouseDown()
    {
        if (!_IsDisable)
        {
            _DotEffector.Shake(transform);
            _Answer.TryToAnswer(this);
        }
    }
    public void SetDate(CardDate card)
    {
        if (_DotEffector == null) _DotEffector = FindObjectOfType<DotEffector>();

        _Answer = FindObjectOfType<Answer>();

        _CardDate = card;
        _Icon.sprite = _CardDate.Sprite;
    }
    public void DeActivate()
    {
        _IsDisable = true;
    }
}
