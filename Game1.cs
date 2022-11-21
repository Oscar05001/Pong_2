using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    SpriteFont font;

    Rectangle leftpadel = new Rectangle(50, 100,15,100);

    Rectangle rightpadel = new Rectangle(740, 100,15,100);
    
    Rectangle bol = new Rectangle(395, 235,15,15);

    Rectangle strek = new Rectangle(395, 5,2,798);


    int padelspeedR = 3;
    int padelspeedL = 3;

    int bolspeedX = 2;
    int bolspeedY = 2;


    int poengL = 0;

    int poengR = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
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


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kstate = Keyboard.GetState();

        if  (kstate.IsKeyDown(Keys.W) && leftpadel.Y >= 0)
                leftpadel.Y-=padelspeedL;
        
        if  (kstate.IsKeyDown(Keys.S) && leftpadel.Y <= 380)
                leftpadel.Y+=padelspeedL;

        if  (kstate.IsKeyDown(Keys.Up) && rightpadel.Y >= 0)
                rightpadel.Y-=padelspeedR;

        if  (kstate.IsKeyDown(Keys.Down) && rightpadel.Y <= 380)
                rightpadel.Y+=padelspeedR;
        
        bol.Y += bolspeedY;
        bol.X += bolspeedX;

        if(bol.Y <= 0 || bol.Y+bol.Height >= 480 )
            bolspeedY *= -1;

        if(bol.X <= 0 )
        {
        poengR ++;
        bol.X = 395;
        bol.Y = 235;
        bolspeedX *= -1;
        }


        if(bol.X+bol.Height >= 800)
        {
        poengL++;
        bol.X = 395;
        bol.Y = 235;
        bolspeedX *= -1;
        }


        if(leftpadel.Intersects(bol))
            bolspeedX *= -1;

        if(rightpadel.Intersects(bol))
            bolspeedX *= -1;



        if(bol.Y >= rightpadel.Y && rightpadel.Y <=380 && bol.X >= 395)
            rightpadel.Y += padelspeedR;

        if(bol.Y <= rightpadel.Y && rightpadel.Y >=0 && bol.X >= 395)
            rightpadel.Y -= padelspeedR;


        
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
       _spriteBatch.Draw(pixel, leftpadel, Color .White);
       _spriteBatch.Draw(pixel, rightpadel, Color .White);
       _spriteBatch.Draw(pixel, bol, Color .White);
        _spriteBatch.Draw(pixel, strek, Color .White);
        _spriteBatch.DrawString(font,poengL.ToString(), new Vector2 (80,0), Color.White);
        _spriteBatch.DrawString(font,poengR.ToString(), new Vector2 (700,0), Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
