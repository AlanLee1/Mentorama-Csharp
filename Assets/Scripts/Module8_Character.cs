using UnityEngine;

public class Module8_Character
{

    public string Name { get; private set; }
    public int Life { get; private set; }
    public Module8_Weapon Weapon { get; private set; }
    public Module7_Armor Armor { get; private set; }
    public bool IsAlive { get => Life > 0; }

    public Module8_Character(string name, int life, Module8_Weapon weapon, Module7_Armor armor)
    {
        Name = name;
        Life = life;
        Weapon = weapon;
        Armor = armor;
    }

    //ataca o inimigo
    public void Attack(Module8_Character enemy)
    {
        if (!CheckAlive()) return;

        if (!enemy.IsAlive)
        {
            Debug.Log($"{enemy.Name} já está morto.");
            return;
        }

        if (!HasWeapon()) return;
        Debug.Log($"{Name} atacou {enemy.Name} com sua {Weapon.Name}.");
        enemy.DealDamage(Weapon.Swing());
    }

    //afia arma
    public void SharpenWeapon()
    {
        if (!CheckAlive()) return;
        if (!HasWeapon()) return;

        Debug.Log($"{Name} afiou sua {Weapon.Name}.");
        Weapon.Sharpen();
    }

    //desequipa arma
    public void UnequipWeapon()
    {
        if (!CheckAlive()) return;
        if (!HasWeapon()) return;

        Debug.Log($"{Name} desequipou sua {Weapon.Name}.");
        Weapon = null;
    }

    //equipa arma
    public void EquipWeapon(Module8_Weapon weapon)
    {
        if (!CheckAlive()) return;
        if (Weapon != null)
        {
            Debug.Log($"{Name} já tem uma {Weapon.Name} equipada.");
        } else
        {
            Weapon = weapon;
            Debug.Log($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
        }
    }

    //desequipa armadura
    public void UnequipArmor()
    {
        if (!CheckAlive()) return;
        if (!HasArmor()) return;

        Debug.Log($"{Name} desequipou sua {Armor.Name}.");
        Armor = null;
    }

    //equipa armadura
    public void EquipArmor(Module7_Armor armor)
    {
        if (!CheckAlive()) return;
        if (Armor != null)
        {
            Debug.Log($"{Name} já tem uma {Armor.Name} equipada.");
        } else
        {
            Armor = armor;
            Debug.Log($"{Name} equipou uma {Armor.Name} (Proteção: {Armor.Protection} - Rank: {Armor.Rank}).");
        }
    }

    //tira dano do inimigo
    private void DealDamage(int damage)
    {
        if (Armor != null)
        {
            Armor.TakeDamage(damage);
            //Caso quebre a armadura e sobre dano a ser tirado da vida
            if (Armor.Protection <= 0)
            {
                Life += Armor.Protection;
                Debug.Log($"Foi quebrada sua {Armor.Name}.");
                Armor = null;
            }

            int armorProtect = Armor == null ? 0 : Armor.Protection;

            Debug.Log($"{Name} levou {damage} de dano. \n" +
            $"Vida atual de {Name}: {Life} - " +
            $"Proteção atual de: {armorProtect}");

        } else
        {
            Life -= damage;
            Debug.Log($"{Name} levou {damage} de dano. \n" +
            $"Vida atual de {Name}: {Life}");
        }
        CheckAlive();
    }

    //verifica se o player esta vivo
    private bool CheckAlive()
    {
        if (!IsAlive)
        {
            Debug.Log($"{Name} está morto.");
        }
        return IsAlive;
    }

    //Verifica se possui alguma arma equipada
    private bool HasWeapon()
    {
        if (Weapon == null)
        {
            Debug.Log($"{Name} não tem nenhuma arma.");
        }
        return Weapon != null;
    }

    //Verifica se possui alguma armadura equipada
    private bool HasArmor()
    {
        if (Armor == null)
        {
            Debug.Log($"{Name} não tem nenhuma armadura.");
        }
        return Armor != null;
    }
}
