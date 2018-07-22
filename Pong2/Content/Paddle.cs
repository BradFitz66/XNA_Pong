using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame;
using MonoGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
namespace Pong2.Content
{
    class Paddle 
    {

        /// <summary>
        /// Class for Paddles.
        /// </summary>
        Game game;
        Vector2 position_;
        int controller;
        int direction_;
        int speed_=200;
        int speed_ai = 100;
        public Vector2 Position{
            get 
            {
                return this.position_;
            }
            set 
            {
                this.position_ = value;
            }
        }

        //hardcoded size
        public Vector2 Size {
            get { return new Vector2(25, 100); }
        }

        public int Speed {
            get {
                return this.speed_;
            }
            set {
                this.speed_ = value;
            }
        }

        public int Direction {
            get { return direction_; }
            set { direction_ = value; }
        }
        public Paddle(Game game, int player, Vector2 position)
        {
            //player = 1 is player1
            //player = 2 is ai
            this.game = game;
            this.position_ = position;
            this.controller = player;
        }
        

        //Update loop for Paddle
        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Keys[] validKeys = { Keys.Up, Keys.Down};
            Keys[] pressedKeys = (from k in Keyboard.GetState().GetPressedKeys()
                                  where validKeys.Contains(k)
                                  select k).ToArray();
            if (controller == 1)
            {
                if (pressedKeys.Length > 0)
                {
                    if (pressedKeys[0] == Keys.Down)
                    {
                        //down
                        direction_ = -1;
                    }
                    else if (pressedKeys[0] == Keys.Up)
                    {
                        //up
                        direction_ = 1;
                    }
                }
                else
                {
                    //not moving
                    direction_ = 0;
                }
            }


            DoMove(delta);
        }

        void DoMove(float delta)
        {
            if (controller == 1)
               position_.Y = position_.Y - (speed_ * direction_) * delta;
            else
               position_.Y = position_.Y - (speed_ai * direction_) * delta;
            if (position_.Y < 0)
            {
                position_.Y = 0;
            }
            if (position_.Y > game.GraphicsDevice.PresentationParameters.Bounds.Height-100)
            {
                position_.Y = game.GraphicsDevice.PresentationParameters.Bounds.Height-100;
            }
            
        }

    }
}
