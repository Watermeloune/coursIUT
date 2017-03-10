using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resonance.Core
{
    class Heros : GameObject
    {
        public float vitesse = 4;
        private enum Direction
        {
            HAUT = 0,
            BAS = 1,
            GAUCHE = 2,
            DROITE = 3
        }
        private Direction DernièreDirection = Direction.HAUT;
        public void Bouger(KeyboardState state, EcranDémarrage ecran)
        {
            if (state.IsKeyDown(Keys.A)) vitesse = 6;
            else if (state.IsKeyDown(Keys.Z)) vitesse = 2;
            else vitesse = 3;
            if (state.IsKeyDown(Keys.Up)&& ecran.Position.Y < 0)
            {
                ecran.Position.Y += (int)vitesse;
                DernièreDirection = Direction.HAUT;
            }
            else if (state.IsKeyDown(Keys.Down) && ecran.Position.Y > -(ecran.Texture.Height - Resonance.WINDOW_HEIGHT))
            {
                ecran.Position.Y -= (int)vitesse;
                DernièreDirection = Direction.BAS;
            }
            else if (state.IsKeyDown(Keys.Left) && ecran.Position.X < 0)
            {
                ecran.Position.X += (int)vitesse;
                DernièreDirection = Direction.GAUCHE;
            }
            else if (state.IsKeyDown(Keys.Right) && ecran.Position.X > -(ecran.Texture.Width - Resonance.WINDOW_WIDTH))
            {
                ecran.Position.X -= (int)vitesse;
                DernièreDirection = Direction.DROITE;
            }
        }
    }
}
