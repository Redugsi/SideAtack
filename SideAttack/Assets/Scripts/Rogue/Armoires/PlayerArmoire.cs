using UnityEngine;

[CreateAssetMenu(fileName = "New Player Armoire", menuName = "Armoires/Player Armoire", order = 0)]
public class PlayerArmoire : ScriptableObject
{
    public FaceObject face;
    public HoodObject hood;
    public ShoulderObject shoulderLeft;
    public ShoulderObject shoulderRight;
    public ElbowObject elbowLeft;
    public ElbowObject elbowRight;
    public WristObject wristLeft;
    public WristObject wristRight;
    public TorsoObject torso;
    public LegObject legLeft;
    public LegObject legRight;
    public BootObject bootLeft;
    public BootObject bootRight;
    public WeaponObject weapon;
}
