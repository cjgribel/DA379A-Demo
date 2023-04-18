using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAdvanced : MonoBehaviour
{
    [SerializeField] private IntEventSO _scoreEvent;
    [SerializeField] private int _scoreValue = 2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _scoreEvent.Invoke(_scoreValue);
            Destroy(gameObject);
        }
    }
}
