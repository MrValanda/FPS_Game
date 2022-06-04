using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AnglesCollisions",order = 51)]
public class AnglesCollisions : ScriptableObject
{
    [SerializeField] private float _maxGroundAngle;
    public float MinGroundDotProduct { get; private set; }

    private void OnValidate()
    {
        MinGroundDotProduct = Mathf.Cos(_maxGroundAngle * Mathf.Deg2Rad);
    }
}
