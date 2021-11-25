using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _Icon;
    private CardDate _CardDate;
    public CardDate CardDate => _CardDate;

    private DotEffector _DotEffector;
    private QuizHost _QuizHost;
    private bool _IsDisable;
    public void Disable() => _IsDisable = true;
    private void OnMouseDown()
    {
        if (!_IsDisable)
        {
            _DotEffector.Shake(transform);
            _QuizHost.CheckAnswer(this);
        }
    }
    public void SetDate(CardDate card)
    {
        if (_QuizHost == null && _DotEffector == null)
        {
            _QuizHost = FindObjectOfType<QuizHost>();
            _DotEffector = FindObjectOfType<DotEffector>();
        }

        _CardDate = card;
        _Icon.sprite = _CardDate.Sprite;
    }
}
