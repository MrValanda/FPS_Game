using UnityEngine;
using UnityEngine.Events;

public class ItemRecognizer : MonoBehaviour
{
    [SerializeField] private Transform _spaceOrientation;
    [SerializeField,Range(0,100f)] private float _recognitionDistance;
    [SerializeField, Range(0, 100f)] private float _recognitionCooldown = 2f;
    public UnityEvent<Item> ItemRecognition;


    private float _timeAfterRecognition;
    private void Update()
    {
        _timeAfterRecognition += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_timeAfterRecognition < _recognitionCooldown) return;
        _timeAfterRecognition = 0;

        RecognitionItem();
    }

    public Item RecognitionItem()
    {
        Ray ray = new Ray(_spaceOrientation.position, _spaceOrientation.forward);
        if (Physics.Raycast(ray,out RaycastHit hit,_recognitionDistance))
        {
            if (hit.collider.TryGetComponent(out Item item))
            {
                ItemRecognition?.Invoke(item);
                return item;
            }
        }

        return null;
    }
}
