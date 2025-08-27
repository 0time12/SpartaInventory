using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // 기본 스탯
    [Header("Base Stats")]
    public int baseAttack;
    public int baseDefense;
    public int baseHp;
    public int baseCrit;

    // 아이템으로 인한 추가 스탯
    [Header("Bonus Stats from Items")]
    public int bonusAttack;
    public int bonusDefense;
    public int bonusHp;
    public int bonusCrit;

    // 최종 스탯 (기본 + 추가)
    public int FinalAttack => baseAttack + bonusAttack;
    public int FinalDefense => baseDefense + bonusDefense;
    public int FinalHp => baseHp + bonusHp;
    public int FinalCrit => baseCrit + bonusCrit;

    // 아이템 스탯 추가
    public void AddItemStats(Item item)
    {
        bonusAttack += item.attackBonus;
        bonusDefense += item.defenseBonus;
        bonusHp += item.hpBonus;
        bonusCrit += item.critBonus;
    }

    // 아이템 스탯 제거
    public void RemoveItemStats(Item item)
    {
        bonusAttack -= item.attackBonus;
        bonusDefense -= item.defenseBonus;
        bonusHp -= item.hpBonus;
        bonusCrit -= item.critBonus;
    }
}
