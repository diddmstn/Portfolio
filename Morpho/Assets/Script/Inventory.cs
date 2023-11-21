using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Transform slotParent;
    public Slot[] slots;

    static public Inventory Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    public void SetSlot()
    {
        int i = 0;
        for (i = 0; i < items.Count; i++)
        {
            slots[i].item = items[i];
            
        }
       
    }
   
}
