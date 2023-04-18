using System;

public class ScoreControllerSubject : Singleton<ScoreControllerSubject>
{
    public event Action<int> ScoreUpdatedEvent;

    private int _score = 0;

    public void AddScore(int score)
    {
        _score += score;
        ScoreUpdatedEvent?.Invoke(_score);
    }
}
