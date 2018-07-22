using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
namespace Pong2.Content
{
    class CollisionHandler
    {

        bool CheckCollision(float x1, float y1, float w1, float h1, float x2, float y2, float w2, float h2){
            return x1 < x2 + w2 &&
                   x2 < x1 + w1 &&
                   y1 < y2 + h2 &&
                   y2 < y1 + h1;
        }

        
        public object[] collidesMTV(Paddle gui1, Ball gui2)
        {
            Vector2 g1p = gui1.Position;
            Vector2 g1s = gui1.Size;
            Vector2 g2p = gui2.Position;
            Vector2 g2s = gui2.Size;

            bool doesCollide = CheckCollision(g1p.X,g1p.Y,g1s.X,g1s.Y,g2p.X,g2p.Y,g2s.X,g2s.Y);
            Vector2 mtv = new Vector2(0,0);
            
            if (doesCollide)
            {
                mtv = new Vector2(1024 ^ 2, 1024 ^ 2);
                float[] edgeCorrespond = new float[] {
                    g1p.X - (g2p.X+ g2s.X), //left
                    (g1p.X + g1s.X) - g2p.X, //right
                    g1p.Y - (g2p.Y + g2s.Y), //top
                    (g1p.Y + g1s.Y) -g2p.Y, //bottom
                };
                
                for (int i = 0; i < edgeCorrespond.Length; i++){
                    if (Math.Abs(edgeCorrespond[i]) < mtv.Length())
                    {
                        if (i == 0 || i == 1){
                            mtv = new Vector2(edgeCorrespond[i], 0);
                        }
                        else
                        {
                            mtv = new Vector2(0, edgeCorrespond[i]);
                        };
                    };
                };

            }
            Debug.Print(mtv.ToString());
            //Tuple.Create(doesCollide, mtv != null ? mtv : new Vector2());
            return new object[] { doesCollide, mtv != null ? mtv : new Vector2() };
        }
    }
}
