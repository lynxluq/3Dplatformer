using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Storage
{
    public PlayerInventoryUI playerInventoryUI;
    [SerializeField] private int size;
    public List<Items> items = new List<Items>();
    public Dictionary<string , Items> itemsDict = new Dictionary<string,Items>();

    private void Start(){
        for(int i=0;i<items.Count;i++){
            itemsDict.Add(items[i].name,items[i]);
        }
    }

    public List<Items> GetList(){
        return items;
    }
    public override void store(Items item){
        items.Add(item);
    }
    public override void remove(Items item){
        items.Remove(item);
    }


}
