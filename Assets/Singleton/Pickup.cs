using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private bool _useSingleton = false;

    [SerializeField]
    private ScoreController _scoreUI;

    [SerializeField]
    private int _scoreValue = 2;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(_useSingleton)
            {
                ScoreController.Instance.AddScore(_scoreValue);
            }
            else
            {
                _scoreUI.AddScore(_scoreValue);
            }
            Destroy(gameObject);
        }
    }
}
