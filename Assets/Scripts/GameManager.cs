using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    public Dictionary<ItemType, ItemObject> itemObjects;

    private void Awake()
    {
        Instance ??= this;
        Debug.Assert(Instance != null);

        if(Instance != this)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    
}