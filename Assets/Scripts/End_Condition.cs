using UnityEngine;

public class End_Condition : MonoBehaviour
{
    public int grandparentGenerous;
    public int parentGenerous;
    public int harperGenerous;
    public int gariGenerous;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
