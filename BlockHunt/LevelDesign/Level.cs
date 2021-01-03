using BlockHunt.interfaces;
using BlockHunt.LevelDesign;
using BlockHunt.LevelDesign.Background;
using LevelDesign.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace LevelDesign.LevelDesign
{
    public class Level
    {
        public Rectangle[] CollisionBox { get; set; }

        private Texture2D texture_grass;
        private Texture2D texture_dirt;
        private Texture2D texture_sky;
        private Texture2D texture_rock;

        private ParallaxBackground background;


        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {0,1,2,2,1,0 },
            {0,1,2,2,1,0 },
            {0,1,2,2,1,0 },
            {0,1,2,2,1,0 }
        };

        private Blok[,] blokArray = new Blok[33, 6];

        private ContentManager content;

        public Level(ContentManager content)
        {
            this.content = content;
            background = new ParallaxBackground(content);

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
            for (int x = 0; x < 33; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    switch (tileArray[x, y])
                    {
                        case 0:
                            //blokArray[x, y] = new Blok(texture_sky, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            break;  

                        case 1:
                            blokArray[x, y] = new Blok(texture_grass, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            break;

                        case 2:
                            blokArray[x, y] = new Blok(texture_dirt, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
                            break;

                        case 3:
                            blokArray[x, y] = new Blok(texture_rock, new Vector2(y * 32, x * 32), new Rectangle(0, 0, 32, 32));
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
            for (int x = 0; x < 33; x++)
            {
                for (int y = 0; y < 6; y++)
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
