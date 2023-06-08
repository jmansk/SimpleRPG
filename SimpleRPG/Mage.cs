using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class Mage : Character
    {
        public int Damage { get; set; }

        public Mage(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        public override void Attack(Character character)
        {
            character.TakeDamage(Damage);
        }

        public void Fireball(Character character)
        {
            character.TakeDamage(Damage * 2);
            this.Health -= (int)(Damage * 0.2);
        }
    }
}
