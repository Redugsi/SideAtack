using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Armoires/Weapon")]
public class WeaponObject : ArmoireObject
{
    public float speed;
    public float range;
    public float killBonus;
    public int price;
    public bool bought;
    public bool selected;
}
