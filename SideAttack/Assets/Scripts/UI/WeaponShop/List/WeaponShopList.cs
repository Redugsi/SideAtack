using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WeaponShopList : MonoBehaviour
{
    public WeaponShopListObject shopListObject;
    public GameObject itemPrefab;
    public RectTransform rectTransform;
    public ScrollRect scrollRect;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = transform.parent.GetComponent<ScrollRect>();
        Init();
    }

    private void Init()
    {
        LoadData();
    }

    public void Reload()
    {

        UpdateData();

        for(int i = 0; i < transform.childCount; i++)
        {
            var daggerComp = transform.GetChild(i).GetComponent<DaggerItemComponent>();
            daggerComp.Init();
        }
    }

    private void UpdateData()
    {
        if (shopListObject == null)
        {
            throw new System.Exception("ShopListObject not set");
        }

        var selectedWeaponName = PrefsManager.instance.GetSelectedDaggerName();
        var boughtWeapons = PrefsManager.instance.GetBoughtDaggers();

        for (int i = 0; i < shopListObject.weaponList.Length; i++)
        {
            var weapon = shopListObject.weaponList[i];
            weapon.selected = weapon.name == selectedWeaponName;
            weapon.bought = false;

            for (int j = 0; j < boughtWeapons.Length; j++)
            {
                if (weapon.name == boughtWeapons[j])
                {
                    weapon.bought = true;
                }
            }
        }
    }

    private IEnumerator CalculateContentSize(int scrollTo)
    {
        yield return new WaitForEndOfFrame();
        var lastGameObject = transform.GetChild(transform.childCount - 1);
        var lastRect = lastGameObject.GetComponent<RectTransform>();

        var lastGameObjectPosx = lastGameObject.position.x;
        var lastGameObjectWidth = lastRect.rect.size.x;
        var lastPoint = lastGameObjectPosx + (lastGameObjectWidth * 0.5f);

        var mineRect = GetComponent<RectTransform>();
        var minePosX = transform.position.x;
        var mineWidth = mineRect.rect.size.x;
        var sizeDeltaX = lastPoint - mineWidth;


        var scrollToGameObject = transform.GetChild(scrollTo);
        var scrollToPosX = scrollToGameObject.position.x;
        var scrollToWidth = scrollToGameObject.GetComponent<RectTransform>().rect.size.x;

        var offsetX = scrollToPosX - (mineWidth * 0.5f);
        var horizontalScrollPosition = offsetX / sizeDeltaX;



        mineRect.sizeDelta = new Vector2(sizeDeltaX, mineRect.sizeDelta.y);
        scrollRect.horizontalNormalizedPosition = horizontalScrollPosition;
    }

    private void LoadData() 
    {
        if (shopListObject == null)
        {
            throw new System.Exception("ShopListObject not set");
        }

        var selectedWeaponIndex = 0;
        var selectedWeaponName = PrefsManager.instance.GetSelectedDaggerName();
        var boughtWeapons = PrefsManager.instance.GetBoughtDaggers();

        for (int i = 0; i < shopListObject.weaponList.Length; i++)
        {
            var weapon = shopListObject.weaponList[i];
            weapon.selected = weapon.name == selectedWeaponName;
            weapon.bought = false;

            for (int j = 0; j < boughtWeapons.Length; j++)
            {
                if (weapon.name == boughtWeapons[j]) 
                {
                    weapon.bought = true;
                }
            }

            if (weapon.selected)
            {
                selectedWeaponIndex = i;
            }

            var go = Instantiate(itemPrefab) as GameObject;
            go.GetComponent<DaggerItemComponent>().weapon = weapon;
            go.transform.SetParent(transform);
        }

        StartCoroutine(CalculateContentSize(selectedWeaponIndex));
    }
}
