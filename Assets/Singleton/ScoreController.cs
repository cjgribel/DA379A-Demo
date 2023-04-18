using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    [SerializeField] private TMPro.TMP_Text _text;

    private int _score = 0;

    public void AddScore(int score)
    {
        _score += score;
        _text.text = $"Score: {_score}";
    }
}
