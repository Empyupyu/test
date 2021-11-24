using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float _FadeInDuration;
    [SerializeField] private float _FadeOutDuration;
    [SerializeField] private Image _TransitionImage;
    public float FadeInDuration => _FadeInDuration;
    public float FadeDuration => _FadeOutDuration;
    private DotEffector _DotWeen;
    private void Start()
    {
        _DotWeen = FindObjectOfType<DotEffector>();
    }
    public void FadeIn()
    {
        _DotWeen.FadeIn(_TransitionImage, _FadeInDuration);
    }
    public void FadeOut()
    {
        _DotWeen.FadeOut(_TransitionImage, _FadeOutDuration);
    }
}
