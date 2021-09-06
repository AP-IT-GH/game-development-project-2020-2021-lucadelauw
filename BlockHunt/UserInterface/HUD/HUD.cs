using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;


namespace BlockHunt.UserInterface.HUD
{
    class HUD : IUserInterface
    {
        // Singleton

        private static HUD _instance;
        private HUD()
        {
        }

        public static HUD Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HUD();

                return _instance;
            }
        }

        // Subject

        private List<IHUDComponent> HUDComponents = new List<IHUDComponent>();


        private static bool placingMode = false;

        public static Rectangle AmountOfBlockNumberRectangle { get; set; } = new Rectangle(1900, 20, 26, 37);
        public static float AmountOfBlockNumberScale { get; set; } = 1.5f;

        public static void TogglePlace()
        {
            placingMode = !placingMode;
        }
        public void Update(GameTime gameTime)
        {
            foreach (IHUDComponent comp in HUDComponents)
            {
                comp.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IHUDComponent comp in HUDComponents)
            {
                comp.Draw(spriteBatch);
            }
        }

        public void AddComponent(IHUDComponent comp)
        {
            if (!HUDComponents.Contains(comp))
                HUDComponents.Add(comp);
        }

        public void RemoveComponent(IHUDComponent comp)
        {
            HUDComponents.Remove(comp);
        }
    }
}
