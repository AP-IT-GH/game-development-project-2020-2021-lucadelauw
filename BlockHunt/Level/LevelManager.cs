using BlockHunt.interfaces;
using BlockHunt.Level.Background;
using BlockHunt.Level.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using BlockHunt.Level.Definition;
using System.Collections.Generic;
using BlockHunt.Input;

namespace BlockHunt.Level
{
    public enum LevelName
    {
        Level1,
        Level2,
        Level3
    }
    public class LevelManager
    {
        private static List<ICollision> StaticCollisionBoxes { get; set; }
        private static Dictionary<Tuple<int, int>, ICollision> DynamicCollisionBoxes { get; set; }
        public static List<ICollision> CollisionBoxes { get; private set; }
        public static Vector2 TileSize { get; set; } = new Vector2(70, 70);

        private static ContentManager content;
        private static IBlockDefinitionBuilder blockDefinitionBuilder;
        private static ILevelReader levelReader;
        private static IPropertiesReader propertiesReader;
        private static List<Enemy> enemies;
        private static List<Portal> portals;

        private static IBackground background;

        private static Dictionary<string, IBlockDefinition> blockDefinitions;
        private static byte[,] tileArray;
        private static Block[,] blockArray;

        private static Dictionary<string, Texture2D> textures;


        public LevelManager(ContentManager content, IBlockDefinitionBuilder blockDefinitionBuilder, ILevelReader levelReader, IPropertiesReader propertiesReader,IBackground background, LevelName levelName = LevelName.Level2)
        {
            LevelManager.content = content;
            LevelManager.blockDefinitionBuilder = blockDefinitionBuilder;
            LevelManager.levelReader = levelReader;
            LevelManager.propertiesReader = propertiesReader;
            LevelManager.background = background;



            SetLevel(levelName);

            InitializeContent();
        }

        public static void SetLevel(LevelName level)
        {
            switch (level)
            {
                case LevelName.Level1:
                    propertiesReader.SetLevel("Level1");
                    levelReader.SetLevel("Level1");
                    break;

                case LevelName.Level2:
                    propertiesReader.SetLevel("Level2");
                    levelReader.SetLevel("Level2");
                    break;

                case LevelName.Level3:
                    propertiesReader.SetLevel("Level3");
                    levelReader.SetLevel("Level3");
                    break;
            }

            InitializeContent();
        }

        private static void InitializeContent()
        {
            StaticCollisionBoxes = new List<ICollision> { };
            DynamicCollisionBoxes = new Dictionary<Tuple<int, int>, ICollision>();
            CollisionBoxes = new List<ICollision> { };
            blockDefinitions = blockDefinitionBuilder.GetBlockDefinitions();
            tileArray = levelReader.GetLevel();
            enemies = propertiesReader.GetEnemies(content);
            portals = propertiesReader.GetPortals(content);
            blockArray = new Block[tileArray.GetLength(0), tileArray.GetLength(1)];

            textures = new Dictionary<string, Texture2D>();
            string path = "WorldObjects/Tiles/";
            foreach (KeyValuePair<string, IBlockDefinition> blockDefinition in blockDefinitions)
            {
                textures.Add(blockDefinition.Key, content.Load<Texture2D>(path + blockDefinition.Value.File));
            }

            CreateWorld();
        }



        public static void CreateWorld()
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
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 2:
                            blokName = "grass_center";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 3:
                            blokName = "grass_mid";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 4:
                            blokName = "grass_left";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 5:
                            blokName = "grass_right";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 6:
                            blokName = "grass_cliff_left";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 7:
                            blokName = "grass_cliff_right";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 8:
                            blokName = "door_closed_mid";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 9:
                            blokName = "door_closed_top";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 10:
                            blokName = "door_open_mid";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 11:
                            blokName = "door_open_top";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 12:
                            blokName = "fence";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 13:
                            blokName = "fence_broken";
                            blockArray[x, y] = new Block(textures[blokName], new Vector2(y * TileSize.Y, x * TileSize.X), new Rectangle(0, 0, (int)blockDefinitions[blokName].CollisionBoxSize.X, (int)blockDefinitions[blokName].CollisionBoxSize.Y));
                            if (blockDefinitions[blokName].HasHitbox)
                                StaticCollisionBoxes.Add(blockArray[x, y]);
                            break;

                        case 99:
                            blokName = "portal_end";

                            break;
                    }

                }
            }
        }

        public void Update(GameTime gameTime)
        {
            background.Update();
            enemies.ForEach(e => e.Update(gameTime));
            portals.ForEach(p => p.Update(gameTime));

            CollisionBoxes = new List<ICollision>();
            CollisionBoxes.AddRange(StaticCollisionBoxes);
            enemies.ForEach(e => CollisionBoxes.Add(e));
            portals.ForEach(p => CollisionBoxes.Add(p));
            foreach (KeyValuePair<Tuple<int,int>,ICollision> keyValuePair in DynamicCollisionBoxes)
                CollisionBoxes.Add(keyValuePair.Value);
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            background.Draw(spritebatch);
            for (int x = 0; x < blockArray.GetLength(0); x++)
            {
                for (int y = 0; y < blockArray.GetLength(1); y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(spritebatch);
                    }
                }
            }

            portals.ForEach(p => p.Draw(spritebatch));
            enemies.ForEach(e => e.Draw(spritebatch));
        }

        public static bool PlaceBlock()
        {
            string blockName = "dynamic";
            int index1 = (int)MouseReader.TransformedGridPosition.Y / (int)TileSize.Y;
            int index2 = (int)MouseReader.TransformedGridPosition.X / (int)TileSize.X;
            if (blockArray[index1, index2] == null)
            {
                Block dynamicBlock = new Block(textures[blockName], MouseReader.TransformedGridPosition, new Rectangle(0, 0, (int)blockDefinitions[blockName].CollisionBoxSize.X, (int)blockDefinitions[blockName].CollisionBoxSize.Y));
                blockArray[index1, index2] = dynamicBlock;
                DynamicCollisionBoxes.Add(new Tuple<int, int>(index1, index2), blockArray[index1, index2]);
                return true;
            }
            return false;
        }

        public static bool RemoveBlock()
        {
            int index1 = (int)MouseReader.TransformedGridPosition.Y / (int)TileSize.Y;
            int index2 = (int)MouseReader.TransformedGridPosition.X / (int)TileSize.X;
            if (blockArray[index1, index2] != null)
                if (blockArray[index1, index2]._texture == textures["dynamic"])
                {
                    blockArray[index1, index2] = null;
                    DynamicCollisionBoxes.Remove(new Tuple<int, int>(index1, index2));
                    return true;
                }
            return false;
        }
    }
}
