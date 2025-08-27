using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Shield
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;

    public Sprite itemIcon; // 인벤토리에 표시할 아이콘 이미지

    // 아이템의 스탯 정보
    public int attackBonus;
    public int defenseBonus;
    public int hpBonus;
    public int critBonus;
}
