using UnityEngine;

public class SconeManagerAdvanced : MonoBehaviour
{
    [SerializeField] private IntEventSO _scoreAddedEvent;
    [SerializeField] private IntEventSO _scoreUpdatedEvent;
    private int _currentScore = 0;

    private void Start() => _scoreAddedEvent.Event += UpdateScore;

    private void OnDestroy() => _scoreAddedEvent.Event -= UpdateScore;

    private void UpdateScore(int addedScore)
    {
        _currentScore += addedScore;
        _scoreUpdatedEvent.Invoke(_currentScore);
    }
}
