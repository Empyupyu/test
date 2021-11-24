using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private SceneTransition _Transition;
    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(_Transition.FadeInDuration);
               
        _Transition.FadeOut();

        FindObjectOfType<LevelLoader>().NewLevel();

        transform.gameObject.SetActive(false);
    }
    public void Restart()
    {
        StartCoroutine(RestartGame());
    }
}
