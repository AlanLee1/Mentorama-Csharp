using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module13
{
    //classe abstrata não pode ser instanciada.
    //ela serve como modelo para ser herdada por outras classes
    public abstract class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public char Rank { get; protected set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
            Rank = GetRank(damage);
        }

        public abstract int Swing();

        public static char GetRank(int damage)
        {
            if (damage >= 10)
            {
                return 'S';

            }
            else if (damage >= 7)
            {
                return 'A';

            }
            else if (damage >= 4)
            {
                return 'B';
            }

            return 'C';
        }
    }
}

