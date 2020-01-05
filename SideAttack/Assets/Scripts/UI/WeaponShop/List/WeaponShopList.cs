using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WeaponShopList : MonoBehaviour
{
    public WeaponShopListObject shopListObject;
    public GameObject itemPrefab;
    public RectTransform rectTransform;
    public ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = transform.parent.GetComponent<ScrollRect>();
        Init();
    }

    private void Init()
    {
        if (shopListObject == null)
        {
            throw new System.Exception("ShopListObject not set");
        }

        var selectedWeaponIndex = 0;

        for (int i = 0; i < shopListObject.weaponList.Length; i++)
        {
            var weapon = shopListObject.weaponList[i];

            if(weapon.selected)
            {
                selectedWeaponIndex = i;
            }

            var go = Instantiate(itemPrefab) as GameObject;
            go.GetComponent<DaggerItemComponent>().weapon = weapon;
            go.transform.SetParent(transform);
        }

        StartCoroutine(CalculateContentSize(selectedWeaponIndex));
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
}
