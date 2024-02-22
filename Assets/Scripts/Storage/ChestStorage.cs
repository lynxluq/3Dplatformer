using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStorage : Storage
{
    [SerializeField] private int size;
    [SerializeField] public List<Items> chestItems = new List<Items>();
    [SerializeField] private GameObject storageUI;
    [SerializeField] private PlayerManager playerManager;


    private void OnEnable(){
        playerManager.playerInteraction.OnInteract += StoreItems;
    }
    private void StoreItems(object sender, System.EventArgs e){
        Show();
    }
    public void Show(){
        storageUI.SetActive(true);
        Time.timeScale =0f;

    }
    public void Hide(){
        storageUI.SetActive(false);
        Time.timeScale =1f;
    }
    public override void store(Items item){
        chestItems.Add(item);
    }
    public override void remove(Items item){
        chestItems.Remove(item);
    }
    public List<Items> GetList(){
        return chestItems;
    }



    

}
