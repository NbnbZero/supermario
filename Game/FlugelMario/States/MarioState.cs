using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Goomba;
using SuperMario.Sprites.Koopa;
using SuperMario.Sprites.Blocks;
using SuperMario.Sprites.StairBlocks;
using SuperMario.Sprites.Items;

namespace SuperMario.States.MarioStates
{
    public class MarioState : IMarioState
    {
        public Sprite StateSprite { get; set; }
        public Posture MarioPosture { get; set; }
        public Direction MarioDirection { get; set; }
        public Shape MarioShape { get; set; }
        private int _screenWidth;
        private int _screenHeight;

        private InputState marioState { get; set; }

        public Vector2 Location { get; set; }

        public MarioState(Vector2 location, int screenWidth, int screenHeight)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite(location);
            MarioPosture = Posture.Stand;
            MarioDirection = Direction.Right;
            marioState = InputState.Nothing;

            Location = location;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public Sprite RespondToCollision(Sprite sprite, CollisionDirection direction)
        {
            if (sprite != null)
            {
                if (sprite.GetType() == typeof(GoombaSprite) || (sprite.GetType() == typeof(KoopaSprite)))
                {
                    sprite = EnemyCollision(sprite, direction);
                }
                else if ((sprite.GetType() == typeof(BrickBlockSprite))
                  || (sprite.GetType() == typeof(StairBlockSprite))
                  || (sprite.GetType() == typeof(RockBlockSprite))
                  || (sprite.GetType() == typeof(QuestionBlockSprite))
                  || (sprite.GetType() == typeof(UsedBlockSprite))
                  || (sprite.GetType() == typeof(HiddenBlockSprite)))
                {
                    sprite = BlockCollision(sprite, direction);
                }
                else if (sprite.GetType() == typeof(SuperMushroomSprite)
                  || sprite.GetType() == typeof(FlowerSprite))
                {
                    ItemCollision(sprite, direction);
                }
            }

            return sprite;
        }

        private Sprite EnemyCollision(Sprite enemy, CollisionDirection direction)
        {
            if (direction == CollisionDirection.Left || direction == CollisionDirection.Right)
            {
                if (enemy.Alive)
                {
                    switch (MarioShape)
                    {
                        case Shape.Small:
                            Terminated();
                            break;
                        case Shape.Big:
                            ChangeSizeToSmall();
                            break;
                        case Shape.Fire:
                            ChangeSizeToSmall();
                            break;
                    }
                }

                if (direction == CollisionDirection.Left)
                {
                    Location = new Vector2(Location.X - 1, Location.Y);
                }
                else if (direction == CollisionDirection.Right)
                {
                    Location = new Vector2(Location.X + 1, Location.Y);
                }
                else if (direction == CollisionDirection.Top)
                {
                    Location = new Vector2(Location.X, Location.Y - 1);
                }
                else if (direction == CollisionDirection.Bottom)
                {
                    Location = new Vector2(Location.X, Location.Y + 1);
                }

            }
            else
            {
                BeIdle();
                if (enemy.GetType() == typeof(GoombaSprite))
                {
                    enemy = EnemySpriteFactory.Instance.CreateDeadGoombaSprite(enemy.Location);
                }
                else if (enemy.GetType() == typeof(KoopaSprite))
                {
                    enemy = EnemySpriteFactory.Instance.CreateDeadKoopaSprite(enemy.Location);
                }
            }
            return enemy;



        }

        private Sprite BlockCollision(Sprite block, CollisionDirection direction)
        {
            BeIdle();
            if (direction == CollisionDirection.Left)
            {
                Location = new Vector2(Location.X - 1, Location.Y);
            }
            else if (direction == CollisionDirection.Right)
            {
                Location = new Vector2(Location.X + 1, Location.Y);
            }
            else if (direction == CollisionDirection.Top)
            {
                Location = new Vector2(Location.X, Location.Y - 1);
            }
            else if (direction == CollisionDirection.Bottom)
            {
                Descend();
                if (block.GetType() == typeof(QuestionBlockSprite))
                {
                    block = BlockSpriteFactory.Instance.CreateUsedBlock(block.Location);
                }
            }

            return block;
        }

        private void ItemCollision(Sprite item, CollisionDirection direction)
        {
            if (item.CanCollide)
            {
                if (item.GetType() == typeof(SuperMushroomSprite))
                {
                    ChangeSizeToBig();
                    item.CanCollide = false;
                }
                else if (item.GetType() == typeof(FlowerSprite))
                {
                    ChangeFireMode();
                    item.CanCollide = false;
                }

                if (direction == CollisionDirection.Left)
                {
                    RunRight();
                }
                else
                {
                    RunLeft();
                }
            }
        }

        public void RunLeft()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite(Location);
            }
            else if (MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftBigMarioSprite(Location);
            }
            else if (MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftFireMarioSprite(Location);
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
            }

            MarioDirection = Direction.Left;
            marioState = InputState.RunLeft;
        }

        public void RunRight()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite(Location);
            }
            else if (MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightBigMarioSprite(Location);
            }
            else if (MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightFireMarioSprite(Location);
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
            }

            MarioDirection = Direction.Right;
            marioState = InputState.RunRight;
        }

        public void BeIdle()
        {
            if (MarioShape == Shape.Small)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite(Location);
                    marioState = InputState.IdleRight;
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite(Location);
                    marioState = InputState.IdleLeft;
                }
            }
            else if (MarioShape == Shape.Big)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite(Location);
                    marioState = InputState.IdleRight;
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite(Location);
                    marioState = InputState.IdleLeft;
                }
            }
            else if (MarioShape == Shape.Fire)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite(Location);
                    marioState = InputState.IdleRight;
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite(Location);
                    marioState = InputState.IdleLeft;
                }
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                marioState = InputState.Nothing;
            }
        }

        public void BeIdle(InputState state)
        {
            if (state == InputState.IdleLeft)
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }
                MarioDirection = Direction.Left;
            }
            else
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }
                MarioDirection = Direction.Right;
            }

        }

        public void Crouch()
        {
            if (MarioDirection == Direction.Right && MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite(Location);
            }
            else if (MarioDirection == Direction.Left && MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftBigMarioSprite(Location);
            }
            else if (MarioDirection == Direction.Right && MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightFireMarioSprite(Location);
            }
            else if (MarioDirection == Direction.Left && MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftFireMarioSprite(Location);
            }
        }

        public void Jump()
        {
            if (MarioDirection == Direction.Right)
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }

                MarioDirection = Direction.Right;
                marioState = InputState.Ascend;
            }
            else
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }

                MarioDirection = Direction.Left;
                marioState = InputState.Ascend;
            }
        }

        public void Descend()
        {
            if (MarioDirection == Direction.Right)
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }

                MarioDirection = Direction.Right;
                marioState = InputState.Descend;
            }
            else
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite(Location);
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite(Location);
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite(Location);
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
                }

                MarioDirection = Direction.Left;
                marioState = InputState.Descend;
            }
        }

        public void ChangeFireMode()
        {
            MarioShape = Shape.Fire;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite(Location);
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite(Location);
            }
        }

        public void ChangeSizeToBig()
        {
            MarioShape = Shape.Big;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite(Location);
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite(Location);
            }
        }

        public void Terminated()
        {
            marioState = InputState.MakeDead;
            MarioShape = Shape.Dead;
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite(Location);
        }

        public void ChangeSizeToSmall()
        {
            MarioShape = Shape.Small;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite(Location);
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite(Location);
            }
        }

        public void Update()
        {
            StateSprite.Update();

            if (marioState == InputState.RunLeft)
            {
                if (Location.X > 0)
                    Location = new Vector2(Location.X - 2, Location.Y);
            }
            else if (marioState == InputState.RunRight)
            {
                if (Location.X < _screenWidth)
                    Location = new Vector2(Location.X + 2, Location.Y);
            }

            if (marioState == InputState.Ascend)
            {
                if (Location.Y > 0)
                    Location = new Vector2(Location.X, Location.Y - 2);
            }
            else if (marioState == InputState.Descend)
            {
                if (Location.Y < _screenHeight)
                    Location = new Vector2(Location.X, Location.Y + 2);
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, Location);
        }
    }
}
