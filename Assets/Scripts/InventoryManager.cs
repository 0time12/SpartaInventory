using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public Transform itemSlotParent;
    public GameObject itemSlotPrefab;
    public int inventorySize = 9; 
    
    public TextMeshProUGUI itemCountText; 
    
    private PlayerStats playerStats;
    private UIManager uiManager;

    // 아이템 슬롯 목록
    private List<ItemSlot> itemSlots = new List<ItemSlot>();
    
    // 장착된 아이템 목록 (부위별로 하나씩만)
    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        uiManager = FindObjectOfType<UIManager>();
        
        InitializeInventoryUI();

        // 아이템 데이터 불러오기
        Item[] allItems = Resources.LoadAll<Item>("Items");

        // 불러온 아이템을 미리 만들어둔 슬롯에 할당
        for (int i = 0; i < allItems.Length && i < inventorySize; i++)
        {
            itemSlots[i].SetupSlot(allItems[i], this);
        }
        
        UpdateItemCountText();
    }
    
    // 빈 슬롯을 생성
    private void InitializeInventoryUI()
    {
        // 기존 슬롯이 있다면 모두 제거 (오류 방지)
        foreach (Transform child in itemSlotParent)
        {
            Destroy(child.gameObject);
        }
        itemSlots.Clear();

        // 설정된 인벤토리 크기만큼 빈 슬롯을 생성
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject newSlotObject = Instantiate(itemSlotPrefab, itemSlotParent);
            ItemSlot newSlot = newSlotObject.GetComponent<ItemSlot>();
            itemSlots.Add(newSlot);
            newSlot.SetupSlot(null, this);
        }
    }
    
    // 아이템 카운트 텍스트 업데이트
    public void UpdateItemCountText()
    {
        int currentItems = 0;
        foreach (var slot in itemSlots)
        {
            if (slot.item != null)
            {
                currentItems++;
            }
        }
        itemCountText.text = $"{currentItems} / {inventorySize}";
    }

    // 아이템 장착,해제
    public void ToggleEquipItem(Item item)
    {
        if (equippedItems.ContainsKey(item.itemType) && equippedItems[item.itemType] == item)
        {
            // 이미 장착된 아이템 해제
            UnequipItem(item);
        }
        else
        {
            // 새로운 아이템 장착
            EquipItem(item);
        }
    }

    private void EquipItem(Item item)
    {
        // 같은 부위 아이템이 있다면 해제
        if (equippedItems.ContainsKey(item.itemType))
        {
            Item oldItem = equippedItems[item.itemType];
            UnequipItem(oldItem);
        }

        equippedItems[item.itemType] = item;
        playerStats.AddItemStats(item);
        uiManager.UpdateStatUI();
        
        // 장착 표시 활성화
        foreach (var slot in itemSlots)
        {
            if (slot.item == item)
            {
                slot.SetEquipStatus(true);
                break;
            }
        }
    }

    private void UnequipItem(Item item)
    {
        equippedItems.Remove(item.itemType);
        playerStats.RemoveItemStats(item);
        uiManager.UpdateStatUI();

        // 장착 표시 비활성화
        foreach (var slot in itemSlots)
        {
            if (slot.item == item)
            {
                slot.SetEquipStatus(false);
                break;
            }
        }
    }
}