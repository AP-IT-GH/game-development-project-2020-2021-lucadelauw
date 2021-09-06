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
        private float MaxSpeed { get; set; }
        public Matrix CameraMatrix { get; private set; }

        private Camera()
        {
            Zoom = 1;
            Position = Vector2.Zero;
            Rotation = 0;
            Bounds = Rectangle.Empty;
            MaxSpeed = 0.05F;
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

        public void MoveTo(float desiredPosition)
        {
            desiredPosition += 960;
            if (desiredPosition > 0)
                desiredPosition = 0;
            float difference = Position.X - desiredPosition;
            float tempMax = MaxSpeed * difference;
            if (difference > tempMax)
                difference = tempMax;
            if (difference < tempMax)
                difference = tempMax;
            Position = new Vector2(Position.X - difference, 0);
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
