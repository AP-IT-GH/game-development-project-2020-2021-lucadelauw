using BlockHunt.Abilities;
using BlockHunt.Commands;
using BlockHunt.GameState;
using BlockHunt.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHunt.Input
{
    class MouseReader : IInputReader
    {
        public static Vector2 Position { get; private set; }
        public static Vector2 GridPosition { get; private set; }
        public static Vector2 TransformedPosition { get; private set; }
        public static Vector2 TransformedGridPosition { get; private set; }
        public static MouseState State { get; private set; }

        private static bool placeToggle = false;
        private static bool removeToggle = false;

        public static void Update(GameTime gameTime)
        {
            State = Mouse.GetState();
            Position = State.Position.ToVector2();
            TransformedPosition = Vector2.Transform(Position, Matrix.Invert(PlayingState.viewMatrix));
            TransformedGridPosition = new Vector2(TransformedPosition.X - (TransformedPosition.X % LevelManager.TileSize.X), TransformedPosition.Y - (TransformedPosition.Y % LevelManager.TileSize.Y));
            GridPosition = Vector2.Transform(TransformedGridPosition, PlayingState.viewMatrix);
        }

        public List<IGameCommand> ReadCommands()
        {
            return new List<IGameCommand>();
        }

        public List<IAbility> ReadAbilities()
        {
            List<IAbility> abilities = new List<IAbility>();
            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed || placeToggle)
            {
                placeToggle = true;
                if (mouse.LeftButton == ButtonState.Released)
                {
                    abilities.Add(new PlaceAbility(PlaceAbility.Action.Place));
                    placeToggle = false;
                }
            }
            if (mouse.RightButton == ButtonState.Pressed || removeToggle)
            {
                removeToggle = true;
                if (mouse.RightButton == ButtonState.Released)
                {
                    abilities.Add(new PlaceAbility(PlaceAbility.Action.Remove));
                    removeToggle = false;
                }
            }
            return abilities;
        }
    }
}
