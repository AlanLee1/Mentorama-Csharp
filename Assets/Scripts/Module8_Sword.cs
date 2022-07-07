using UnityEngine;

public class Module8_Sword : Module8_Weapon
{
    public Module8_Sword() : base("Sword", 8) { }

    //recebe no construtor como parametro damage e sobreescreve o valor de damage da classe pai
    public Module8_Sword(int damage) : base("Sword", damage) { }

    public override int Swing()
    {
        Debug.Log("Corta! Corta!");
        return Damage;
    }

    public override void Sharpen()
    {
        Damage++;
        base.Sharpen();
    }

}
