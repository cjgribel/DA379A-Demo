using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    [SerializeField]
    private TMPro.TMP_Text _text;

    protected int _score = 0;

    public virtual void AddScore(int score)
    {
        _score += score;
        _text.text = $"Score: {_score}";
    }
}
