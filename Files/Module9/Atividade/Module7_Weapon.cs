using UnityEngine;
public class Module7_Weapon
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public char Rank { get; private set; }

    public Module7_Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
        Rank = GetRank(damage);
    }

    public void Sharpen()
    {
        var newRank = Module7_Weapon.GetRank(Damage);

        if (Damage == 10)
        {
            Debug.Log($"Sua {Name} já esta no maior dano.");
        } else
        {
            Damage++;
            Damage = Mathf.Clamp(Damage, 0, 10);
            Debug.Log($"{Name} foi afiada! Dano aumentou para {Damage}.");
        }

        if (newRank != Rank)
        {
            Rank = newRank;
            Debug.Log($"Rank da {Name} aumentou para {Rank}!");
        }
    }

    public static char GetRank(int damage)
    {
        if (damage >= 10)
        {
            return 'S';

        } else if (damage >= 7)
        {
            return 'A';

        } else if (damage >= 4)
        {
            return 'B';
        }

        return 'C';
    }
}