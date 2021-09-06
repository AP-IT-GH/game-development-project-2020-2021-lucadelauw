using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.interfaces
{
    public interface IPhysicsObject : ITransform, ICollision
    {
        public ICollision[] Contact { get; set; }
    }
}
