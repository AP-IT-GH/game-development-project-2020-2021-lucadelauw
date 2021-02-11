using BlockHunt.interfaces;
using Microsoft.Xna.Framework;

namespace BlockHunt.Physics
{
    public class FrictionManager : IPhysicComponent
    {
        public static Vector2 Friction { get; set; } = new Vector2(50f, 5.45f);

        public void ApplyPhysic(ITransform transform)
        {
            float accX = transform.Velocity.X;
            float accY = transform.Velocity.Y;

            if (accX > Friction.X)
                accX -= Friction.X;
            else if (accX < -Friction.X)
                accX += Friction.X;
            else
                accX = 0;

            if (accY > Friction.Y)
                accY -= Friction.Y;
            else if (accY < -Friction.Y)
                accY += Friction.Y;
            else
                accY = 0;
            transform.Velocity = new Vector2(accX, accY);
        }
    }
}
