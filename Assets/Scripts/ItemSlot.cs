using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    public Image itemIcon;
    public GameObject equipIcon; // 장착 표시 이미지

    private InventoryManager inventoryManager;
    
    public void SetupSlot(Item newItem, InventoryManager manager)
    {
        item = newItem;
        inventoryManager = manager;

        if (item != null)
        {
            itemIcon.sprite = item.itemIcon;
            itemIcon.enabled = true;
        }
        else
        {
            // 아이템이 없으면 아이콘을 숨김
            itemIcon.enabled = false;
            // 빈 슬롯은 장착 아이콘도 숨김
            SetEquipStatus(false);
        }

    }
    
    public void OnClickSlot()
    {
        if (item != null)
        {
            inventoryManager.ToggleEquipItem(item);
        }
    }

    // 장착 표시 활성화,비활성화
    public void SetEquipStatus(bool isEquipped)
    {
        equipIcon.SetActive(isEquipped);
    }
}
