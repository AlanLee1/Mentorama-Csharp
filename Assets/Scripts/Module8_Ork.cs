
public class Module8_Ork : Module8_Character
{

    public int Force { get; private set; }

    public Module8_Ork(string name, int life, Module8_Weapon weapon, Module7_Armor armor, int force) : base(name, life, weapon, armor)
    {
        Force = force;
    }

    public void BoostDamage()
    {
        Weapon.Damage += (Force / 100);
    }

}
