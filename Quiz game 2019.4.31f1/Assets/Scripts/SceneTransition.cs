using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float _FadeInDuration;
    [SerializeField] private float _FadeOutDuration;
    [SerializeField] private Image _Image;
    public Image Image => _Image;
    public float FadeInDuration => _FadeInDuration;
    public float FadeOutDuration => _FadeOutDuration;
}
