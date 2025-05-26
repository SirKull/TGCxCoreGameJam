using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Data : MonoBehaviour
{
    public List<List<int>> addresses = new List<List<int>>();

    public List<int> address1Letters = new List<int>();
    public List<int> address2Letters = new List<int>();
    public List<int> address3Letters = new List<int>();
    public List<int> address4Letters = new List<int>();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

        addresses.Add(address1Letters);
        addresses.Add(address2Letters);
        addresses.Add(address3Letters);
        addresses.Add(address4Letters);
    }
}
