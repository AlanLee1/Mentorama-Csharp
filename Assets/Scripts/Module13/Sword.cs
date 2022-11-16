using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module13
{
    public class Sword : Weapon, ISharpen
    {
        public Sword() : base("Sword", 8) { }

        //recebe no construtor como parametro damage e sobreescreve o valor de damage da classe pai
        public Sword(int damage) : base("Sword", damage) { }

        public override int Swing()
        {
            Debug.Log("Corta! Corta!");
            return Damage;
        }

        void ISharpen.Sharpen()
        {
            var newRank = Weapon.GetRank(Damage);

            Damage++;

            if (Damage == 10)
            {
                Debug.Log($"Sua {Name} ja esta no maior dano.");
            }
            else
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
    }
}

