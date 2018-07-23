using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong2.Content
{

    public class Ball
    {
        Hitbox hitbox_;
        Vector2 position_;
        Vector2 velocity_;

        public Vector2 Position
        {
            get { return position_; }
            set { position_ = value; }
        }
        public Vector2 Velocity 
        {
            get { return velocity_; }
            set { velocity_ = value; }
        }
        //hardcoded size
        public Vector2 Size {
            get { return new Vector2(20,20); }
        }
        public Hitbox Hit_Box {
            get { return hitbox_; }
        } 

        public Ball(Vector2 startPos, int startDirection)
        {
            position_ = startPos;
            velocity_ = startDirection == 1 ? new Vector2(-100, -20) : new Vector2(100, 20);
            hitbox_ = new Hitbox(Size, position_);
        }

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position_ = (position_ + velocity_ * delta) ;
            hitbox_.Position = position_;
            if (position_.Y < 0 || position_.Y > (480-20))
            {
                velocity_.Y= -velocity_.Y;
            }
            if (position_.X< 0 || position_.X > (800 - 20))
            {
                position_ = new Vector2(400 - 10, 240 - 10);
                Random r = new Random();
                int dir = r.Next(1, 2);
                velocity_ = dir == 1 ? new Vector2(-100, -20) : new Vector2(100, 20);
            }
            

        }

    }
}
