using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSingleton : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            ScoreController.Instance.AddScore(_scoreValue);
            Destroy(gameObject);
        }
    }
}
