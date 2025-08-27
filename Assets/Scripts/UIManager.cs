using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject statusPanel;
    public GameObject inventoryPanel;

    public GameObject[] menuButtons; // 스테이터스,인벤토리 버튼
    public GameObject[] backButtons; // 뒤로가기 버튼

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI critText;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        foreach (var button in backButtons)
        {
            button.SetActive(false);
        }
    }

    // 스테이터스 열기
    public void OpenStatusPanel()
    {
        statusPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        UpdateStatUI(); // 스탯 UI 업데이트
        SetMenuButtonsActive(false);
        backButtons[0].SetActive(true);
    }

    // 인벤토리 열기
    public void OpenInventoryPanel()
    {
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        SetMenuButtonsActive(false);
        backButtons[1].SetActive(true);
    }

    // 창 닫고 메뉴 버튼 활성화
    public void ClosePanels()
    {
        statusPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        SetMenuButtonsActive(true);
        foreach (var button in backButtons)
        {
            button.SetActive(false);
        }
    }

    // 메뉴 버튼 활성화,비활성화
    private void SetMenuButtonsActive(bool isActive)
    {
        foreach (var button in menuButtons)
        {
            button.SetActive(isActive);
        }
    }

    // 스탯 UI 업데이트
    public void UpdateStatUI()
    {
        attackText.text = $"{playerStats.FinalAttack} (+<color=green>{playerStats.bonusAttack}</color>)";
        defenseText.text = $"{playerStats.FinalDefense} (+<color=green>{playerStats.bonusDefense}</color>)";
        hpText.text = $"{playerStats.FinalHp} (+<color=green>{playerStats.bonusHp}</color>)";
        critText.text = $"{playerStats.FinalCrit} (+<color=green>{playerStats.bonusCrit}</color>)";
    }
}
