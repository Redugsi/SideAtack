using UnityEngine.UI;
using UnityEngine;
using System;

public class DaggerItemComponent : MonoBehaviour, IDialogDelegate
{
    private DaggerShopStatus status;

    public GameObject dialogPrefab;

    public WeaponObject weapon;
    public GameObject boughtView;
    public GameObject buyView;

    public Image daggerImage;
    public Text daggerName;
    public Text rangeValue;
    public Text killBonusValue;
    public Text boughtText;
    public Text buyText;

    public Button buyButton;

    public GameEvent OnBoughtDagger;

    void Start()
    {
        Init();
    }

    public void Init()
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
        if(status == DaggerShopStatus.BUY) 
        {
            ShowBuyDialog();
        } else if (status == DaggerShopStatus.SELECT)
        {
            ShowSelectDialog();
        }
    }

    private void ShowBuyDialog()
    {
        var canvas = GameObject.Find("Canvas") as GameObject;
        var dialog = Instantiate(dialogPrefab, canvas.transform) as GameObject;
        var dialogComponent = dialog.GetComponent<DialogComponent>();
        dialogComponent.dialogDelegate = this;

        if (CanBuy()) 
        {
            dialogComponent.titleLabel.text = "Are you sure?";
        } else 
        {
            dialogComponent.titleLabel.text = "Not enough coin";
            dialogComponent.noButton.GetComponentInChildren<Text>().text = "OK";
            dialogComponent.yesButton.gameObject.SetActive(false);
        }
    }

    private void ShowSelectDialog()
    {
        var canvas = GameObject.Find("Canvas") as GameObject;
        var dialog = Instantiate(dialogPrefab, canvas.transform) as GameObject;
        var dialogComponent = dialog.GetComponent<DialogComponent>();
        dialogComponent.dialogDelegate = this;

        dialogComponent.titleLabel.text = "Are you sure?";
        dialogComponent.yesButton.GetComponentInChildren<Text>().text = "Select";
        dialogComponent.noButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    private bool CanBuy()
    {
        return PrefsManager.instance.GetCoin() >= weapon.price;
    }

    public void Accepted()
    {
        if (status == DaggerShopStatus.BUY) {
            if (CanBuy())
            {
                if (OnBoughtDagger != null)
                {
                    PrefsManager.instance.AddCoin(weapon.price * -1);
                    PrefsManager.instance.AddBoughtDagger(weapon.name);
                    PrefsManager.instance.SetSelectedDaggerName(weapon.name);
                    OnBoughtDagger.Raise();
                }
            }
        }else if(status == DaggerShopStatus.SELECT)
        {
            PrefsManager.instance.SetSelectedDaggerName(weapon.name);
            OnBoughtDagger.Raise();
        }

    }

    public void Declined()
    {
       // throw new NotImplementedException();
    }
}
