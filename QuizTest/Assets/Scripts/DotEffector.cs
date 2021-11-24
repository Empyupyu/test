using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class DotEffector : MonoBehaviour
{
    [SerializeField] private float _TextFadeInDuration;
    [SerializeField] private float _BounceTime;
    [Header("Shake Options")]
    [SerializeField] private float _Duration;
    [SerializeField] private float _Strange;
    [SerializeField] private float _Randomness;
    [SerializeField] private int _Vibrato;
    public void Bounce(Transform _transform)
    {
        _transform.localScale = new Vector3(0, 0, 1);
        _transform.DOScale(1, _BounceTime);
    }
    public void Shake(Transform _transform)
    {
        _transform.DOShakePosition(_Duration, _Strange, _Vibrato, _Randomness).SetEase(Ease.InBounce);
    }
    public void FadeIn(Image image, float fadeInDuration)
    {
        Fade(image, 1, fadeInDuration);
    }
    public void FadeOut(Image image, float fadeInDuration)
    {
        Fade(image, 0, fadeInDuration);
    }
    public void FadeInText(Text text)
    {
        text.DOFade(1, _TextFadeInDuration);
    }
    private void Fade(Image image, float value, float duration)
    {
        image.DOFade(value, duration);
    }
}
