using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class Warrior : Character
    {
        public int Power { get; set; }

        public Warrior(string name, int health, int power) : base(name, health)
        {
            Power = power;
        }

        public override void Attack(Character character)
        {
            character.TakeDamage(Power);
        }

        public void ChargeAttack(Character character)
        {
            character.TakeDamage(Power * 2);
            this.Health -= (int)(Power * 0.5);
        }
    }
}
