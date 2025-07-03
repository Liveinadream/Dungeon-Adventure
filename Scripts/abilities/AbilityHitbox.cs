using Godot;
using System;

//通过能力使敌人被打击的状态
public partial class AbilityHitbox : Area3D, IHitbox
{
    public bool CanStun()
    {
        return true;
    }

    public float GetDamage() => GetOwner<Ability>().Damage;
}
