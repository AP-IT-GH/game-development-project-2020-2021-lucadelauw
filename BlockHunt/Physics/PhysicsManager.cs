using System;
using System.Collections.Generic;
using System.Text;
using BlockHunt.interfaces;

namespace BlockHunt.Physics
{
    class PhysicsManager
    {
        private List<IPhysicComponent> PhysicComponents;

        public PhysicsManager(List<IPhysicComponent> physicComponents)
        {
            PhysicComponents = physicComponents;
        }
        public void ApplyPhysics(ITransform transform)
        {
            foreach(IPhysicComponent component in PhysicComponents)
            {
                component.ApplyPhysic(transform);
            }
        }
    }
}
