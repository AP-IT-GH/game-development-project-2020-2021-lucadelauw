using BlockHunt.interfaces;
using BlockHunt.Level.Background;
using Level.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using BlockHunt.Level.Definition;
using System.Collections.Generic;

namespace BlockHunt.Level
{
    public class LevelManager
    {
        public static List<ICollision> CollisionBoxes { get; set; }
        public static Vector2 TileSize { get; set; } = new Vector2(70, 70);

        private readonly ContentManager content;
        private readonly IBlockDefinitionBuilder blockDefinitionBuilder;
        private readonly ILevelReader levelReader;
        private readonly IBackground background;

        private readonly Dictionary<string, IBlockDefinition> blockDefinitions;
        private byte[,] tileArray;
        private Blok[,] blokArray;

        private Dictionary<string, Texture2D> textures;


        public LevelManager(ContentManager content, IBlockDefinitionBuilder blockDefinitionBuilder, ILevelReader levelReader, IBackground background)
        {
            this.content = content;
            this.blockDefinitionBuilder = blockDefinitionBuilder;
            this.levelReader = levelReader;
            this.background = background;

            CollisionBoxes = new List<ICollision> { };
            blockDefinitions = blockDefinitionBuilder.GetBlockDefinitions();
            tileArray = this.levelReader.GetLevel();
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];

            textures = new Dictionary<string, Texture2D>();

            InitializeContent();
        }

        private void InitializeContent()
        {
            string path = "WorldObjects/Tiles/";
            foreach (KeyValuePair<string, IBlockDefinition> blockDefinition in blockDefinitions)
            {
                textures.Add(blockDefinition.Key, content.Load<Texture2D>(path + blockDefinition.Value.File));
            }
        }



        public void CreateWorld()
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    string blokName;
                    switch (tileArray[x, y])
                    {
                        case 0:
                            // Air
                            break;

                        case 1:
                            blokName = "grass";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 2:
                            blokName = "grass_center";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 3:
                            blokName = "grass_mid";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 4:
                            blokName = "grass_left";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 5:
                            blokName = "grass_right";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 6:
                            blokName = "grass_cliff_left";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 7:
                            blokName = "grass_cliff_right";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 8:
                            blokName = "door_closed_mid";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 9:
                            blokName = "door_closed_top";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 10:
                            blokName = "door_open_mid";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 11:
                            blokName = "door_open_top";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 12:
                            blokName = "fence";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                CollisionBoxes.Add(blokArray[x, y]);
                            break;

                        case 13:
                            blokName = "fence_broken";
                            blokArray[x, y] = new Blok(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
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
