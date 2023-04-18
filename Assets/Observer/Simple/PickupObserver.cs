using UnityEngine;

public class PickupObserver : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 2;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            ScoreControllerSubject.Instance.AddScore(_scoreValue);
            Destroy(gameObject);
        }
    }
}
