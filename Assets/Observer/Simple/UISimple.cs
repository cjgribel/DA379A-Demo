using UnityEngine;

public class UISimple : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    private void Start() => ScoreControllerSubject.Instance.ScoreUpdatedEvent += UpdateScore;

    private void UpdateScore(int newScore) => _text.text = $"Score: {newScore}";
}
