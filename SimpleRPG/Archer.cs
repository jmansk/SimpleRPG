using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    public class Archer : Character
    {
        public int Range { get; set; }

        public Archer(string name, int health, int range) : base(name, health)
        {
            Range = range;
        }

        public override void Attack(Character character)
        {
            character.TakeDamage(Range);
        }

        public void RangedAttack(Character character)
        {
            character.TakeDamage(Range * 2);
            this.Health -= (int)(Range * 0.3);
        }
    }
}
