using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt
{
    // Singleton
    class Camera
    {
        private static Camera instance = null;


        private float Zoom { get; set; }
        public Vector2 Position { get; set; }
        private float Rotation { get; set; }
        private Rectangle Bounds { get; set; }
        public Matrix CameraMatrix { get; private set; }

        private Camera()
        {
            Zoom = 1;
            Position = Vector2.Zero;
            Rotation = 0;
            Bounds = Rectangle.Empty;
        }

        public static Camera Instance
        {
            get
            {
                if (instance == null)
                    instance = new Camera();

                return instance;
            }
        }

        public void MoveTo(Vector2 position)
        {
            if (position.X <= -960)
                Position = new Vector2(position.X + 960, 0);
            else
                Position = new Vector2(0, 0);
        }

        public Matrix GetTransform()
        {
            return
                    Matrix.CreateTranslation(new Vector3(Position.X, -Position.Y, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Zoom) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
        }

        public Vector2 Inverse(Vector2 location)
        {
            return Vector2.Transform(location, Matrix.Invert(CameraMatrix));
        }
    }
}
