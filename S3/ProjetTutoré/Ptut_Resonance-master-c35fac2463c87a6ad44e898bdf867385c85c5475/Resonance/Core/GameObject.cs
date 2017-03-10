using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Resonance.Core
{
    public class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;
        public GameObject()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        // Dessine un sprite suivant sa texture à une position préalablement définie
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
