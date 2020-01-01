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
    public SpriteRenderer pelvis;
    public SpriteRenderer legLeft;
    public SpriteRenderer legRight;
    public SpriteRenderer bootLeft;
    public SpriteRenderer bootRight;
    public SpriteRenderer weaponLeft;
    public SpriteRenderer weaponRight;

    public Quaternion faceTransform;
    public Quaternion hoodTransform;
    public Quaternion wristLeftTransform;
    public Quaternion wristRightTransform;
    public Quaternion elbowLeftTransform;
    public Quaternion elbowRightTransform;
    public Quaternion shoulderLeftTransform;
    public Quaternion shoulderRighTransform;
    public Quaternion torsoTransform;
    public Quaternion pelvisTransform;
    public Quaternion legLeftTransform;
    public Quaternion legRightTransform;
    public Quaternion bootLeftTransform;
    public Quaternion bootRightTransform;
    public Quaternion weaponLeftTransform;
    public Quaternion weaponRightTransform;


    private void Start()
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
        pelvis.sprite = armoire.pelvis.sprite;
        legLeft.sprite = armoire.legLeft.sprite;
        legRight.sprite = armoire.legRight.sprite;
        bootLeft.sprite = armoire.bootLeft.sprite;
        bootRight.sprite = armoire.bootRight.sprite;
        weaponLeft.sprite = armoire.weapon.sprite;
        weaponRight.sprite = armoire.weapon.sprite;
        //SetOriginalTransforms();
    }

    private void SetOriginalTransforms()
    {
        faceTransform = face.transform.rotation;
        hoodTransform = hood.transform.rotation;
        wristLeftTransform = wristLeft.transform.rotation;
        wristRightTransform = wristRight.transform.rotation;
        elbowLeftTransform = elbowLeft.transform.rotation;
        elbowRightTransform = elbowRight.transform.rotation;
        shoulderLeftTransform = shoulderLeft.transform.rotation;
        shoulderRighTransform = shoulderRight.transform.rotation;
        torsoTransform = torso.transform.rotation;
        pelvisTransform = pelvis.transform.rotation;
        legLeftTransform = legLeft.transform.rotation;
        legRightTransform = legRight.transform.rotation;
        bootLeftTransform = bootLeft.transform.rotation;
        bootRightTransform = bootRight.transform.rotation;
        weaponLeftTransform = weaponLeft.transform.rotation;
        weaponRightTransform = weaponRight.transform.rotation;
        Debug.Log(torso.gameObject.transform.rotation);
    }

    public void ResetTransformations()
    {
        if (faceTransform == null)
        {
            return;
        }

        face.transform.rotation = faceTransform;
        hood.transform.rotation = hoodTransform;
        wristLeft.transform.rotation = wristLeftTransform;
        wristRight.transform.rotation = wristRightTransform;
        elbowLeft.transform.rotation = elbowLeftTransform;
        elbowRight.transform.rotation = elbowRightTransform;
        shoulderLeft.transform.rotation = shoulderLeftTransform;
        shoulderRight.transform.rotation = shoulderRighTransform;
        torso.transform.rotation = torsoTransform;
        pelvis.transform.rotation = pelvisTransform;
        legLeft.transform.rotation = legLeftTransform;
        legRight.transform.rotation = legRightTransform;
        bootLeft.transform.rotation = bootLeftTransform;
        bootRight.transform.rotation = bootRightTransform;
        weaponLeft.transform.rotation = weaponLeftTransform;
        weaponRight.transform.rotation = weaponRightTransform;
    }
}
