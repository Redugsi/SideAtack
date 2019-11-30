using System;
using UnityEngine;

public class ArmoireComponent : MonoBehaviour
{
    public PlayerArmoire armoire;

    public SpriteRenderer face;
    public SpriteRenderer hood;
    public SpriteRenderer wristLeft;
    public SpriteRenderer wristRight;
    public SpriteRenderer elbowLeft;
    public SpriteRenderer elbowRight;
    public SpriteRenderer shoulderLeft;
    public SpriteRenderer shoulderRight;
    public SpriteRenderer torso;
    public SpriteRenderer legLeft;
    public SpriteRenderer legRight;
    public SpriteRenderer bootLeft;
    public SpriteRenderer bootRight;
    public SpriteRenderer weaponLeft;
    public SpriteRenderer weaponRight;

    private void Awake()
    {
        Wear();
    }

    private void Wear()
    { 
        if (armoire == null)
        {
            throw new Exception("(ArmoireComponent::Wear) Player Armoire should not be empty");
        }

        face.sprite = armoire.face.sprite;
        hood.sprite = armoire.hood.sprite;
        wristLeft.sprite = armoire.wristLeft.sprite;
        wristRight.sprite = armoire.wristRight.sprite;
        elbowLeft.sprite = armoire.elbowLeft.sprite;
        elbowRight.sprite = armoire.elbowRight.sprite;
        shoulderLeft.sprite = armoire.shoulderLeft.sprite;
        shoulderRight.sprite = armoire.shoulderRight.sprite;
        torso.sprite = armoire.torso.sprite;
        legLeft.sprite = armoire.legLeft.sprite;
        legRight.sprite = armoire.legRight.sprite;
        bootLeft.sprite = armoire.bootLeft.sprite;
        bootRight.sprite = armoire.bootRight.sprite;
        weaponLeft.sprite = armoire.weapon.sprite;
        weaponRight.sprite = armoire.weapon.sprite;
    }
}
