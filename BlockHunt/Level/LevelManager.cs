using BlockHunt.interfaces;
using BlockHunt.Level.Background;
using Level.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BlockHunt.Level
{
    public class LevelManager
    {
        public static List<ICollision> CollisionBoxes { get; set; }

        private readonly ContentManager content;
        private readonly ILevelReader levelReader;
        private readonly IBackground background;

        private byte[,] tileArray;
        private Blok[,] blokArray;

        private Texture2D texture_grass;
        private Texture2D texture_dirt;
        private Texture2D texture_sky;
        private Texture2D texture_rock;


        public LevelManager(ContentManager content, ILevelReader levelReader, IBackground background)
        {
            this.content = content;
            this.levelReader = levelReader;
            this.background = background;

            CollisionBoxes = new List<ICollision> { };
            tileArray = levelReader.GetLevel();
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];

            InitializeContent();
        }

        private void InitializeContent()
        {
            texture_grass = content.Load<Texture2D>("WorldObjects/grassDirtBlock");
            texture_dirt = content.Load<Texture2D>("WorldObjects/dirtBlock");
            texture_sky = content.Load<Texture2D>("WorldObjects/skyBlock");
            texture_rock = content.Load<Texture2D>("WorldObjects/rock");
        }



        public void CreateWorld()
        {   
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    switch (tileArray[x, y])
                    {
                        case 0:
                            //BlokArray[x, y] = new Blok(texture_sky, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            break;  

                        case 1:
                            blokArray[x, y] = new Blok(texture_grass, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 2:
                            blokArray[x, y] = new Blok(texture_dirt, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 3:
                            blokArray[x, y] = new Blok(texture_rock, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            CollisionBoxes.Add(blokArray[x, y]);
                            break;
                    }
                }
            }
        }

        public void Update(Vector2 heroPosition)
        {
            background.Update(heroPosition);
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            background.Draw(spritebatch);
            for (int x = 0; x < blokArray.GetLength(0); x++)
            {
                for (int y = 0; y < blokArray.GetLength(1); y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }
    }
}
