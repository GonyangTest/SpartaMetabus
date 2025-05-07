using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class Weapon : ItemData
{
    public int power;

    public override string GetEffectText()
    {
        return $"+{power} 공격력";
    }

    public void Attack()
    {
        Debug.Log($"{name}을 사용했습니다.");
    }
}