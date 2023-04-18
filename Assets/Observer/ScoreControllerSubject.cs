using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControllerSubject : ScoreController
{
    public event Action<int> ScoreUpdatedEvent;

    public override void AddScore(int score)
    {
        _score += score;
        ScoreUpdatedEvent?.Invoke(_score);
    }
}
