using UnityEngine.UI;
using UnityEngine;
using System;

public class DaggerItemComponent : MonoBehaviour
{
    private DaggerShopStatus status;

    public WeaponObject weapon;

    public GameObject boughtView;
    public GameObject buyView;

    public Image daggerImage;
    public Text daggerName;
    public Text rangeValue;
    public Text killBonusValue;
    public Text boughtText;
    public Text buyText;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        if(weapon == null) {
            throw new Exception("Wapon object not set");
        }

        SetStatus();
        SetUI();
    }

    private void SetStatus()
    { 
        if(!weapon.bought)
        {
            status = DaggerShopStatus.BUY;
            return;
        }

        status = weapon.selected ? DaggerShopStatus.SELECTED : DaggerShopStatus.SELECT;
    }

    private void SetUI()
    {
        daggerImage.sprite = weapon.previewSprite;
        daggerName.text = weapon.name;
        rangeValue.text = weapon.range.ToString();
        killBonusValue.text = weapon.killBonus.ToString();
        SetUIByStatus();
    }

    private void SetUIByStatus()
    {
        switch(status)
        {
            case DaggerShopStatus.BUY:
                buyText.text = weapon.price.ToString();
                SetBuyViewVisibility(true);
                break;
            case DaggerShopStatus.SELECT:
                boughtText.text = "SELECT";
                SetBuyViewVisibility(false);
                break;
            case DaggerShopStatus.SELECTED:
                boughtText.text = "USING";
                SetBuyViewVisibility(false);
                break;
        }
    }

    private void SetBuyViewVisibility(bool showBuy)
    {
        buyView.SetActive(showBuy);
        boughtView.SetActive(!showBuy);
    }

    public void BuyAction()
    { 
    
    }
}
