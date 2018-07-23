using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong2.Content
{
    /// <summary>
    /// Basic hitbox class to use with the CollisionHandler
    /// </summary>
    public class Hitbox
    {
        Vector2 size_;
        Vector2 position_;
        float rotation_; // may repurpose it later so I can use it in SAT collision to handle rotated collisions


        public Vector2 Size { get {return size_; } set {size_=value; } }
        public Vector2 Position { get { return position_; } set { position_ = value; } }
        public float Rotation { get { return rotation_; } set { rotation_ = value; } }


        public Hitbox(Vector2 HitBox_Size, Vector2 HitBox_Position, float HitBox_Rotation=0)
        {
            this.size_ = HitBox_Size;
            this.position_ = HitBox_Position;
            this.rotation_ = HitBox_Rotation;
        }
    }
}
