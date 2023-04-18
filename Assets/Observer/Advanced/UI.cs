using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    public void UpdateScoreUI(int newScore) => _text.text = $"Score: {newScore}";
}
