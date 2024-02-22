using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerManager player;
    [SerializeField] private GameObject itemSlot;
    [SerializeField] private ChestStorage chest;
    [SerializeField] private ChestStorageUI chestUI;

    private void Start(){
        AddInven();
        
    }

    public void AddInven(){
        foreach(var item in player.playerInventory.GetList()){
            Transform containerTransform = transform.Find("Storage");
            GameObject itemslot = Instantiate(itemSlot,containerTransform);
            itemSlot.name = item.name;
            GameObject icon = itemslot.transform.GetChild(1).gameObject;
            icon.GetComponent<Image>().sprite = item.sprite;
            itemslot.SetActive(true);
            itemslot.GetComponent<Button>().onClick.AddListener(() => ShiftItem(item,itemslot));
            

        }
    }
    public void AddItemSlot(Items items){
        var index= player.playerInventory.GetList().IndexOf(items);
        var item = player.playerInventory.GetList()[index];
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
        chest.store(item);
        player.playerInventory.remove(item);
        chestUI.AddItemSlot(item);
        Destroy(itemslot);
       
        
    }
}
