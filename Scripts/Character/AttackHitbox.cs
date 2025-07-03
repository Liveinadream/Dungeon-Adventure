using Godot;
using System;

//通过攻击使敌人被打击的状态
public partial class AttackHitbox : Area3D,IHitbox
{
    public bool CanStun()
    {
        return false;
    }
    public float GetDamage()
    {
        return GetOwner<Character>().GetStatResource(Stat.Strgenth).StatValue;;
    }
}
