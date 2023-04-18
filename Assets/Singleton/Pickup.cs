using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreUI;

    [SerializeField] private int _scoreValue = 2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _scoreUI.AddScore(_scoreValue);
            Destroy(gameObject);
        }
    }
}
