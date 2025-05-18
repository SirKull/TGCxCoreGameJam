using UnityEngine;

[CreateAssetMenu]
public class TransformSO : ScriptableObject
{
    [SerializeField]
    private Transform exitTransform;

    public Transform Value
    {
        get { return exitTransform; }
        set { exitTransform = value; }
    }
}
