using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace CarAvoidGame.Domain
{
    // Base class for all game entities
   
    public abstract class GameObject
    {
        public int X { get; protected set; }    // Horizontal position
        public int Y { get; protected set; }    // Vertical position
        public int Width { get; }               // Object width (fixed)
        public int Height { get; }              // Object height (fixed)


        // Bounding rectangle for collision detection
        public Rectangle Bounds => new Rectangle(X, Y, Width, Height);


        // Constructor - called by derived classes (Car, Obstacle)
        protected GameObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
