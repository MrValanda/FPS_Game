using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemProperty",order = 51)]
public class ItemProperty : ScriptableObject
{
    [field: SerializeField] public Image Icon;
}
