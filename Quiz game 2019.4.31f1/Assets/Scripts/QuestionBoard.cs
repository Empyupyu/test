using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBoard : MonoBehaviour
{
    [SerializeField] private Text _Text;
    private DotEffector _DotEffector;
    public void Visualisation(string text)
    {
        if(_DotEffector == null) _DotEffector = FindObjectOfType<DotEffector>();
        _Text.text = $"Find {text}";
        _DotEffector.FadeInText(_Text);
    }
    public void ResetText()
    {
        Color color = _Text.color;
        color.a = 0;
        _Text.color = color;
    }
}
