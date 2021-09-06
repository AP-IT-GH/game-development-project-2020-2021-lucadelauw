using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.interfaces
{
    interface IDamageable
    {
        public int Health { get; set; }
        public int DamageToDeal { get; set; }

        public void Damage(int damage);
    }
}
