using UnityEngine;

public class UIAdvanced : MonoBehaviour
{
    [SerializeField] private IntEventSO _scoreEvent;

    [SerializeField] private TMPro.TMP_Text _text;

    private void Start() => _scoreEvent.Event += UpdateScore;

    private void OnDestroy() => _scoreEvent.Event -= UpdateScore;

    private void UpdateScore(int newScore) => _text.text = $"Score: {newScore}";
}
