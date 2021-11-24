using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool _StartGame;
    [SerializeField] private LevelDate[] _Level;
    [SerializeField] private int _StartLevel;
    [SerializeField] private Grid _Grid;
    [SerializeField] private CardsDeck _CardsDeck;
    [SerializeField] private Answer _Answer;
    private int _CurrentLevel;

    public UnityEvent OnFinish;

    public void Start() // Initialization
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

        if (_CurrentLevel == _StartLevel) _CardsDeck.BundleSelect();

        _Grid.Generetor(_Level[_CurrentLevel]);
        _CardsDeck.NewDeck(_Grid.ActiveCells);
        _Answer.GetCorrectCard();
        _CurrentLevel++;
    }
    private void Finised()
    {
        OnFinish.Invoke();
        _CurrentLevel = _StartLevel;
    }
}
