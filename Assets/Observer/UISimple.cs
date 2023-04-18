using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISimple : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text _text;

    void Start()
    {
        // Since the singleton is still of type ScoreController
        (ScoreControllerSubject.Instance as ScoreControllerSubject).ScoreUpdatedEvent += UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        _text.text = $"Score: {newScore}";
    }
}
