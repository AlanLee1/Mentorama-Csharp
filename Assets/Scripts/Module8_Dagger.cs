using UnityEngine;

//class dagger herdando weapon
public class Module8_Dagger : Module8_Weapon
{
    public float CritChance { get; private set; }

    //construtor com os parametros da classe pai preenchidas direto (padrão)
    public Module8_Dagger(float critChance) : base("Dagger", 6)
    {
        CritChance = critChance;
    }

    //construtor sendo possivel receber parametros na sua instanciação (personalizavel)
    //base se referencia a classe que esta herdando, utilizando da base para implementar mais coisas
    public Module8_Dagger(string name, int damage, float critChance) : base(name, damage)
    {
        CritChance = critChance;
    }

    public override int Swing()
    {
        Debug.Log("Fura! Fura!");

        var finalDamage = Damage;

        if (Random.Range(0f, 1f) < CritChance)
        {
            Debug.Log("Critical Hit!");
            finalDamage *= 2;
        }
        return finalDamage;
    }
}
