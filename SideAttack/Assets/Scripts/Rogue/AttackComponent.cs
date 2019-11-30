using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class AttackComponent : MonoBehaviour, IPlayerAttack
{

    public WeaponObject weapon;

    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        var component = GetComponent<InputComponent>();
        component.OnLeftClicked += AttackLeft;
        component.OnRightClicked += AttackRight;
    }

    public void AttackLeft()
    {
        Debug.Log("Left Attack");
    }

    public void AttackRight()
    {
        Debug.Log("Right Attack");
    }
}
