using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Resonance.Core;
namespace Resonance
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Resonance : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int WINDOW_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int WINDOW_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        private EcranDémarrage ecran;
        private Pointeur pointeur;
        private BoutonEcran[] bouton;
        private SpriteFont textFont;
        private Heros heros;
        private Texture2D masque;
        private bool[] modes;
        enum Mode : int
        {
            menu,
            jouer,
            éditeur,
            options,
            niveauTest
        }
        private int scrolling;
        private int nbBtMenu = 5;
        public int nbniveaux = 125;
        public Resonance()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            //this.graphics.IsFullScreen = true;  
        }
        public void Quit()
        {
            if (this != null)
            {
                Exit();
            }
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public bool DansEcran(int x, int y)
        //Vérifie que les coordonnées indiquées constituent un point de l'écran
        {
            return (x >= 0 && x < WINDOW_WIDTH && y >= 0 && y < WINDOW_HEIGHT);    
        }
        public bool DansEcran(Vector2 point)
        //Vérifie que les coordonnées du vecteur indiqué constituent un point de l'écran
        {
            return (point.X >= 0 && point.X < WINDOW_WIDTH && point.Y >= 0 && point.Y < WINDOW_HEIGHT);
        }
        public Color[] AndresCircle(int xc, int yc, int r_min, int r_med, int r_max)
        //Dessine une succession de cercles qui forme le masque du jeu
        {
            Color[] cercle = new Color[WINDOW_WIDTH * WINDOW_HEIGHT];
            Color couleur = new Color(0, 0, 0, 255);

            for (int r = r_med; r < r_max; r++) {

                int x = 0;
                int y = r;
                int d = r - 1;

                
                    while (y >= x)
                    {
                        if (DansEcran(xc + x, yc + y))
                            cercle[xc + x + (yc + y) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc + y, yc + x))
                            cercle[xc + y + (yc + x) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc - x, yc + y))
                            cercle[xc - x + (yc + y) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc - y, yc + x))
                            cercle[xc - y + (yc + x) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc + x, yc - y))
                            cercle[xc + x + (yc - y) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc + y, yc + x))
                            cercle[xc + y + (yc - x) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc - x, yc - y))
                            cercle[xc - x + (yc - y) * WINDOW_WIDTH] = couleur;
                        if (DansEcran(xc - y, yc - x))
                            cercle[xc - y + (yc - x) * WINDOW_WIDTH] = couleur;

                        if (d >= 2 * x)
                        {
                            d -= 2 * x + 1;
                            x++;
                        }
                        else if (d < 2 * (r - y))
                        {
                            d += 2 * y - 1;
                            y--;
                        }
                        else
                        {
                            d += 2 * (y - x - 1);
                            y--;
                            x++;
                        }
                    }
            }
            double ratio_opacité = 305 / (double)(r_med - r_min);
            for (int r = r_min; r < r_med; r++)
            {
                double opacité = ratio_opacité * (double)(r - r_min);
                couleur = new Color(0, 0, 0, (int)(opacité));
                int x = 0;
                int y = r;
                int d = r - 1;


                while (y >= x)
                {
                    if (DansEcran(xc + x, yc + y))
                        cercle[xc + x + (yc + y) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc + y, yc + x))
                        cercle[xc + y + (yc + x) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc - x, yc + y))
                        cercle[xc - x + (yc + y) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc - y, yc + x))
                        cercle[xc - y + (yc + x) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc + x, yc - y))
                        cercle[xc + x + (yc - y) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc + y, yc + x))
                        cercle[xc + y + (yc - x) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc - x, yc - y))
                        cercle[xc - x + (yc - y) * WINDOW_WIDTH] = couleur;
                    if (DansEcran(xc - y, yc - x))
                        cercle[xc - y + (yc - x) * WINDOW_WIDTH] = couleur;

                    if (d >= 2 * x)
                    {
                        d -= 2 * x + 1;
                        x++;
                    }
                    else if (d < 2 * (r - y))
                    {
                        d += 2 * y - 1;
                        y--;
                    }
                    else
                    {
                        d += 2 * (y - x - 1);
                        y--;
                        x++;
                    }
                }
            }
            return cercle;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ecran = new EcranDémarrage();
            pointeur = new Pointeur();
            heros = new Heros();
            bouton = new BoutonEcran[nbBtMenu + nbniveaux];
            bouton[0] = new BoutonEcran(new Vector2(WINDOW_WIDTH / 2, WINDOW_HEIGHT / 3), "Jouer");
            bouton[1] = new BoutonEcran(new Vector2(WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2), "Creer niveau");
            bouton[2] = new BoutonEcran(new Vector2(WINDOW_WIDTH / 2, 2 * WINDOW_HEIGHT / 3), "Options");
            bouton[3] = new BoutonEcran(new Vector2(WINDOW_WIDTH / 15, WINDOW_HEIGHT / 15), "Retour");
            bouton[4] = new BoutonEcran(new Vector2(WINDOW_WIDTH/ 2, 4*WINDOW_HEIGHT/5), "Niveau Test");
            for (int i = nbBtMenu; i < bouton.Length; i++)
            {
                bouton[i] = new BoutonEcran(new Vector2(WINDOW_WIDTH / 2, (i - 3) * WINDOW_HEIGHT / 10), String.Concat("Niveau ",(i-4).ToString()));
            }
            modes = new bool[5];
            modes[0] = true;
            for (int i = 1; i < 5; i++) modes[i] = false;
            masque = new Texture2D(graphics.GraphicsDevice, WINDOW_WIDTH, WINDOW_HEIGHT);
            masque.SetData<Color>(AndresCircle(WINDOW_WIDTH/2,WINDOW_HEIGHT/2,WINDOW_HEIGHT/7,WINDOW_HEIGHT/2,(int) Math.Sqrt(Math.Pow(WINDOW_HEIGHT/2,2) + Math.Pow(WINDOW_WIDTH / 2,2))));

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (modes[(int)Mode.niveauTest])
            {
                ecran.Texture = Content.Load<Texture2D>("niveauTest");
                heros.Texture = Content.Load<Texture2D>("perso_test");
                heros.Position = new Vector2((WINDOW_WIDTH - heros.Texture.Width)/2, (WINDOW_HEIGHT - heros.Texture.Height) / 2 );
            }
            else
            {
                ecran.Texture = Content.Load<Texture2D>("menu");
                ecran.Position = new Vector2(0, 0);
                pointeur.Texture = Content.Load<Texture2D>("souris");
                pointeur.Position = new Vector2(0, 0);
                textFont = Content.Load<SpriteFont>("Police1");
            }
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
            // Déplace le curseur - Change la couleur des buttons si las souris est dessus - Fait naviguer entre les menus - Fait scroll l'écran des niveaux avec la molette - fait déplacer le héros dans le niveaut test
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Quit();
            pointeur.Position = Mouse.GetState().Position.ToVector2();
            for (int i = 0; i < bouton.Length; i++)
            {
                if (bouton[i].CheckSelection()) bouton[i].couleur = Color.Yellow;
                else bouton[i].couleur = Color.White;
            }
            if (modes[(int)Mode.menu])
            {
                if (bouton[0].CheckSelection() && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    modes[(int)Mode.menu] = false;
                    modes[(int)Mode.jouer] = true;
                    scrolling = Mouse.GetState().ScrollWheelValue;
                }
                if(bouton[1].CheckSelection()&&Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    modes[(int)Mode.menu] = false;
                    this.Exit();
                    using (var game = new Niveaux.Editeur())
                        game.Run();
                }
                if (bouton[4].CheckSelection() && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    modes[(int)Mode.menu] = false;
                    modes[(int)Mode.niveauTest] = true;
                    LoadContent();
                }
            }
            else if (modes[(int)Mode.jouer])
            {
                if (Mouse.GetState().ScrollWheelValue < scrolling)
                {
                    if (bouton[bouton.Length - 1].position.Y > 9 * WINDOW_HEIGHT / 10) for (int i = nbBtMenu; i < bouton.Length; i++) bouton[i].position.Y -= WINDOW_HEIGHT / 10;
                    scrolling = Mouse.GetState().ScrollWheelValue;
                }
                if (Mouse.GetState().ScrollWheelValue > scrolling)
                {
                    if (bouton[nbBtMenu].position.Y < WINDOW_HEIGHT / 10) for (int i = nbBtMenu; i < bouton.Length; i++) bouton[i].position.Y += WINDOW_HEIGHT / 10;
                    scrolling = Mouse.GetState().ScrollWheelValue;
                }
                if (bouton[3].CheckSelection() && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    modes[(int)Mode.menu] = true;
                    modes[(int)Mode.jouer] = false;
                }
                else
                    for (int i = 4; i < bouton.Length; i++)
                        if (bouton[i].CheckSelection() && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            modes[(int)Mode.menu] = false;
                            this.Exit();
                            using (var game = new Jeu.Jeu(bouton[i].texte))
                                game.Run();
                        }
            }
            else if (modes[(int)Mode.niveauTest])
            {
                heros.Bouger(Keyboard.GetState(),ecran);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
            // Ecran - boutons ecran de base - boutons niveaux - niveau test (héros - masque) - curseur 
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //ecran.Draw(spriteBatch);
            if (modes[(int)Mode.menu])
            {
                bouton[0].Draw(spriteBatch, textFont, 2);
                bouton[1].Draw(spriteBatch, textFont, 2);
                bouton[2].Draw(spriteBatch, textFont, 2);
                bouton[4].Draw(spriteBatch, textFont, 2);
            }
            else if (modes[(int)Mode.jouer])
            {
                bouton[3].Draw(spriteBatch, textFont, 1);
                for (int i = nbBtMenu; i < bouton.Length; i++)
                {
                    if (bouton[i].position.Y < 9 * WINDOW_HEIGHT / 10&& bouton[i].position.Y >= WINDOW_HEIGHT / 10) bouton[i].Draw(spriteBatch, textFont , 1);
                }
                
            }
            else if (modes[(int)Mode.niveauTest])
            {
                heros.Draw(spriteBatch);
                spriteBatch.Draw(masque, new Vector2(0, 0), Color.White);
            }
            pointeur.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here
            this.Window.Title = "Resonance";
            base.Draw(gameTime);
        }
    }
}
