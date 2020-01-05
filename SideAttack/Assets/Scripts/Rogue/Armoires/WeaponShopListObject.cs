using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon List", menuName = "Shop/Weapon List")]
public class WeaponShopListObject : ScriptableObject
{
    public WeaponObject[] weaponList;
}
