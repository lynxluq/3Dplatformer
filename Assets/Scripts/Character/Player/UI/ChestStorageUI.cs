using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestStorageUI : MonoBehaviour
{
     [SerializeField] private PlayerManager player;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private ChestStorage chest;

    
    public void AddItemSlot(Items items){
            var index= chest.GetList().IndexOf(items);
            var item = chest.GetList()[index];
            Transform containerTransform = transform.Find("Storage");
            GameObject itemslot = Instantiate(itemSlot,containerTransform);
            itemSlot.name = item.name;
            GameObject icon = itemslot.transform.GetChild(1).gameObject;
            icon.GetComponent<Image>().sprite = item.sprite;
            itemslot.SetActive(true);
            itemslot.GetComponent<Button>().onClick.AddListener(() => ShiftItem(item,itemslot));
            

        
    }

    public void ShiftItem(Items item,GameObject itemslot){
        Debug.Log("item shifted");
        Debug.Log(item.name);
        player.playerInventory.store(item);
        chest.remove(item);
        player.playerInventory.playerInventoryUI.AddItemSlot(item);
        Destroy(itemslot);        
    }
}
