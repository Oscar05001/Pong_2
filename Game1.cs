﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_2;

public class Game1 : Game
{
    //Y
    public const int WINDOW_HEIGHT = 800;
    //X
    public const int WINDOW_WHITE = 1200;
    public int toutch = 0;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    SpriteFont font;


    public static Rectangle bol = new Rectangle(WINDOW_WHITE/2, 235,15,15);

    Rectangle strek = new Rectangle(WINDOW_WHITE/2, 5,2,798);


    int padelspeedR = 3;
    int padelspeedL = 3;

    int bolspeedX = 4;
    int bolspeedY = 4;


    int poengL = 0;

    int poengR = 0;

    Padel lp;
    Padel rp;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        _graphics.PreferredBackBufferWidth = WINDOW_WHITE;
    }   

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        pixel = Content.Load<Texture2D>("Namnlspixel");
        font = Content.Load<SpriteFont>("File");
        lp = new Padel(pixel, 50, 5,Keys.W, Keys.S, Keys.T);
        rp = new Padel(pixel, WINDOW_WHITE-60, 2,Keys.Up,Keys.Down,Keys.None, true);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kstate = Keyboard.GetState();


        
        
        
        bol.Y += bolspeedY;
        bol.X += bolspeedX;

        if(bol.Y <= 0 || bol.Y+bol.Height >= WINDOW_HEIGHT )
            bolspeedY *= -1;

        if(bol.X <= 0 )
        {
        poengR ++;
        bol.X = WINDOW_WHITE-405;
        bol.Y = WINDOW_HEIGHT-245;
        bolspeedX *= -1;
        }


        if(bol.X+bol.Height >= WINDOW_WHITE)
        {
        poengL++;
        bol.X = WINDOW_WHITE-405;
        bol.Y = WINDOW_HEIGHT-245;
        bolspeedX *= -1;
        }

        lp.Update();
        rp.Update();

        //boll rör padel
        if(lp.Paddle.Intersects(bol))
        {
            bolspeedX *= -1;
            toutch = 0;
        }

        if(rp.Paddle.Intersects(bol))
        {
            bolspeedX *= -1;
            toutch = 1;
        }   

        


        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        lp.Draw(_spriteBatch);
        rp.Draw(_spriteBatch);
       _spriteBatch.Draw(pixel, bol, Color .White);
        _spriteBatch.Draw(pixel, strek, Color .White);
        _spriteBatch.DrawString(font,poengL.ToString(), new Vector2 (80,0), Color.White);
        _spriteBatch.DrawString(font,poengR.ToString(), new Vector2 (WINDOW_WHITE-100,0), Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}