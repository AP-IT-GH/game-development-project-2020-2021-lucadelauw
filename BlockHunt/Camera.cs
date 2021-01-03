using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt
{
    class Camera
    {
        public float Zoom { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Camera()
        {
            Zoom = 1;
            Position = Vector2.Zero;
            Rotation = 0;
            Origin = Vector2.Zero;
        }

        public void MoveTo(Vector2 position)
        {
            Position = new Vector2(position.X + 960,0);
        }

        public Matrix GetTransform()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(Rotation);
            var scaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 0));

            return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
        }
    }
}
