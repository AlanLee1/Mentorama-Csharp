using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module13
{
    public class Dagger : Weapon, ISharpen
    {
        public float CritChance { get; private set; }

        //construtor com os parametros da classe pai preenchidas direto (padr�o)
        public Dagger(float critChance) : base("Dagger", 6)
        {
            CritChance = critChance;
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

        //construtor sendo possivel receber parametros na sua instancia��o (personalizavel)
        //base se referencia a classe que esta herdando, utilizando da base para implementar mais coisas
        public Dagger(string name, int damage, float critChance) : base(name, damage)
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
}

