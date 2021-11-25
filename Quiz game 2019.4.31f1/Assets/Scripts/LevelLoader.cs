using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool _StartGame;
    [SerializeField] private int _StartLevel;
    [SerializeField] private LevelDate[] _Level;
    [SerializeField] private Grid _Grid;
    [SerializeField] private CardsDeck _CardsDeck;
    [SerializeField] private QuizHost _QuizHost;

    [SerializeField] private DotEffector _DotEffector;
    [SerializeField] private SceneTransition _Transition;//

    private int _CurrentLevel;

    public UnityEvent OnFinish;

    private void Start() // Initialization
    {
        if (_StartGame) 
        { 
            _CurrentLevel = _StartLevel;
            NewLevel();
        }
    }
    public void NewLevel()
    {
        if (_CurrentLevel >= _Level.Length)
        {
            Finised();
            return;
        }
     
        _Grid.Generetor(_Level[_CurrentLevel]);

        if (_CurrentLevel == _StartLevel)
        {
            _DotEffector.Bounce(_Grid.transform);
            _CardsDeck.Create(_Grid.ActiveCells, true);
        }
        else 
        { 
            _CardsDeck.Create(_Grid.ActiveCells);
        }
           
        _QuizHost.GetCorrectCard();
        _CurrentLevel++;
    }
    public void Restart()
    {
        StartCoroutine(RestartGame());
    }
    private IEnumerator RestartGame()
    {
        _DotEffector.FadeIn(_Transition.Image, _Transition.FadeOutDuration);
        yield return new WaitForSeconds(_Transition.FadeInDuration);
        _DotEffector.FadeOut(_Transition.Image,_Transition.FadeOutDuration);

        NewLevel();
    }
    private void Finised()
    {
        OnFinish.Invoke();
        _CurrentLevel = _StartLevel;
    }  
}
