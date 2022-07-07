public class Module8_Elf : Module8_Character
{

    public int Life;
    public int Healing;

    public Module8_Elf(string name, int life, Module8_Weapon weapon, Module7_Armor armor, int healing) : base(name, life, weapon, armor)
    {
        Life = life + 20;
        Healing = healing;
    }

    public void Healling()
    {
        Life += (Healing / 100);
    }

}
