using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Timers;

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

    
    //(X,Y,Bred,Höjd)
    public static Rectangle bol = new Rectangle(WINDOW_WHITE/2, WINDOW_HEIGHT/2,15,15);

    Rectangle power = new Rectangle(500, 500,45,45);

    Rectangle strek = new Rectangle(WINDOW_WHITE/2, 5,2,798);

    Rectangle mi = new Rectangle(WINDOW_WHITE/2-6, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);

    //Padel speed
    public  static int padelspeedR = 5;
    public  static int padelspeedL = 5;
    public  static int padelspeedM = 8;
    int powerx;
    int powery;
    int time = 0;
    int ompower = 1;
    int hurmångamit = 1;
   
    public static int bolspeedX = 4;
    int bolspeedY = 4;
    public static int bolkommer = 1;

    Random rnd = new Random();
    
    Random ti = new Random();
    
    
    
    Random powertid = new Random();


    int poengL = 0;

    int poengR = 0;

    Padel lp;
    Padel rp;
    
    public Rectangle Power { get => power; set => power = value; }

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
        lp = new Padel(pixel, 50, padelspeedL,Keys.W, Keys.S,Keys.None);
        rp = new Padel(pixel, WINDOW_WHITE-60, padelspeedR,Keys.Up,Keys.Down,Keys.T, true);
        

        
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        //Exit (rör ej)
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kstate = Keyboard.GetState();

        // TODO: Add your update logic here

        base.Update(gameTime);
    
        
        //Speed
        bol.Y += bolspeedY;
        bol.X += bolspeedX;

        mi.Y += padelspeedM;

       

        //Ändra bol Y
        if(bol.Y <= 0 || bol.Y+bol.Height >= WINDOW_HEIGHT ){
            bolspeedY *= -1;
            bolkommer *= -1;
        }

    
       

        if(bol.X <= 0 )
        {
        poengR ++;
        bol.X = WINDOW_WHITE/2;
        bol.Y = WINDOW_HEIGHT/2;
        bolspeedX *= -1;
        
        }


        if(bol.X+bol.Height >= WINDOW_WHITE)
        {
        poengL++;
        bol.X = WINDOW_WHITE/2;
        bol.Y = WINDOW_HEIGHT/2;
        bolspeedX *= -1;
        
        }



        //Mid padel
        if (mi.Y <= 0 ){
            padelspeedM = rnd.Next(2,10);
            
            
        }

        if ( mi.Y+mi.Height >= WINDOW_HEIGHT ){
            padelspeedM = rnd.Next(2,10);
            padelspeedM *= -1;
            
        }



        lp.Update();
        rp.Update();
        
        

        //boll rör padel ädnar X
        if(lp.Paddle.Intersects(bol) )
        {
            bolspeedX *= -1;
            toutch = 0;
        }

        if(rp.Paddle.Intersects(bol))
        {
            bolspeedX *= -1;
            toutch = 1;
        }

        if(mi.Intersects(bol))
        {
            bolspeedX *= -1;
            
        }   


        
        if(bol.Intersects(power))
        {
            ompower=1;
            
           Powerup.Powerupsen(toutch);
            
        } 
        
        //power up
        if(ompower==1){
        Random rx = new Random();
        Random ry = new Random();
        //time = ti.Next(1000,10000);
        powerx = rx.Next(50,1101);
        powery = ry.Next(0,801);
        //Timer powertid = new Timer(time);
        //powertid.AutoReset = true;
        //powertid.Start();
        power.X=powerx;
        power.Y=powery;
        ompower = 0;
        
        }


        power.X=powerx;
        power.Y=powery;
       
        

        
        

    	//
       

    }

    



    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        lp.Draw(_spriteBatch);
        rp.Draw(_spriteBatch);

        _spriteBatch.Draw(pixel, bol, Color .Red);
        
        _spriteBatch.Draw(pixel, strek, Color .White);
        _spriteBatch.Draw(pixel, mi, Color .Yellow);
        _spriteBatch.Draw(pixel, power, Color .Yellow);
        
        _spriteBatch.DrawString(font,padelspeedL.ToString(), new Vector2 (150,0), Color.White);
        _spriteBatch.DrawString(font,poengL.ToString(), new Vector2 (80,0), Color.White);
        _spriteBatch.DrawString(font,poengR.ToString(), new Vector2 (WINDOW_WHITE-100,0), Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    
}
