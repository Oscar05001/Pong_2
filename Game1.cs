using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Collections.Generic;

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
    public static List<Mittengubbe> mittengubbar = new List<Mittengubbe>();

    public static List<Mittengubberod> mittengubbarrod = new List<Mittengubberod>();
    
    KeyboardState oldState;
    Keys O = Keys.O;
    static Texture2D pixel;
    Texture2D coin;
    SpriteFont font;

    
    //(X,Y,Bred,Höjd)
    public static Rectangle bol = new Rectangle(WINDOW_WHITE/2, WINDOW_HEIGHT/2,15,15);

    

    Rectangle strek = new Rectangle(WINDOW_WHITE/2, 5,2,798);

    Rectangle mi = new Rectangle(WINDOW_WHITE/2-6, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);

    //Padel speed
    public  static int padelspeedR;
    public  static int padelspeedL;
    public  static int padelspeedM = 8;
    int speedmid = padelspeedM;



    public  static  int padelspeedRstart = 5;
    public  static  int padelspeedLstart = 5;

    public static int speedboostL;
    public static int speedboostR;

    
    
    
   
    public static int bolspeedX = 4;
    int bolspeedY = 4;
    public static int bolkommer = 1;

    Random rnd = new Random();


    int poengL = 0;

    int poengR = 0;

    Padel lp;
    Padel rp;
    Powerup power;
    
    
    

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

        coin = Content.Load<Texture2D>("Coin");
        pixel = Content.Load<Texture2D>("Namnlspixel");
        font = Content.Load<SpriteFont>("File");


        lp = new Padel(pixel, 50, true,Keys.W, Keys.S,Keys.Y);
        rp = new Padel(pixel, WINDOW_WHITE-60, false,Keys.Up,Keys.Down,Keys.T);
        power = new Powerup(coin);
        
        
        
        
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

        padelspeedL = padelspeedLstart;
        padelspeedL += speedboostL;

        padelspeedR = padelspeedRstart;
        padelspeedR += speedboostR;
    
        
        //Speed
        bol.Y += bolspeedY;
        bol.X += bolspeedX;

        mi.Y += speedmid;

        

       

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
            speedmid = rnd.Next(2,10);
            
            
        }

        if ( mi.Y+mi.Height >= WINDOW_HEIGHT ){
            speedmid = rnd.Next(2,10);
            speedmid *= -1;
            
        }



        
        
        

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


        foreach (var mittengubbe in mittengubbar)
        {
            if(mittengubbe.Mittengubar.Intersects(bol))
            {
                bolspeedX *= -1;
                
            } 
        }

        foreach (var mittengubberod in mittengubbarrod)
        {
            if(mittengubberod.Mittengubbarrod.Intersects(bol))
            {
                bolspeedX *= -1;
                
            } 




        }
        




        


                 
        if(power.Power.Intersects(bol))
        {
            Powerup.ompower = 1;
            
           Powerup.Powerupsen(toutch);
            
        } 
        
        

    	

        if(oldState.IsKeyUp(O) && kstate.IsKeyDown(O) )
            Powerup.Powerupsen(toutch);
       
            oldState = kstate;

            RemovMiten();
            RemovRod();
        



        lp.Update();
        rp.Update();
        power.Update();

        foreach (var mittengubbe in mittengubbar)
        {
            mittengubbe.Update();
        }
        foreach (var mittengubberod in mittengubbarrod)
        {
            mittengubberod.Update();
        }
       

    }

    public static void SpawnMiten(){    


        
        Random rnd = new Random();
        
        mittengubbar.Add(new Mittengubbe(pixel,padelspeedM,(float)rnd.Next(10,30)));


    }

    

    public static void SpawnRod(){    


        
        Random rnd = new Random();
        
        mittengubbarrod.Add(new Mittengubberod(pixel,padelspeedM,(float)rnd.Next(5,20)));


    }





    public void RemovMiten(){
        
        for (int i = 0; i < mittengubbar.Count; i++)
        {
            if(mittengubbar[i].aredod)
            {
                mittengubbar.RemoveAt(i); 
                i--;

            }


        }


    }
    public void RemovRod(){
        
        for (int i = 0; i < mittengubbarrod.Count; i++)
        {
            if(mittengubbarrod[i].aredod)
            {
                mittengubbarrod.RemoveAt(i); 
                i--;

            }


        }


    }




    




    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        lp.Draw(_spriteBatch);
        rp.Draw(_spriteBatch);
        power.Draw(_spriteBatch);


        _spriteBatch.Draw(pixel, strek, Color .White);
        _spriteBatch.Draw(pixel, bol, Color .Red);
    
        _spriteBatch.Draw(pixel, mi, Color .Yellow);
        
        
        _spriteBatch.DrawString(font,speedboostL.ToString(), new Vector2 (120,0), Color.White);
        _spriteBatch.DrawString(font,poengL.ToString(), new Vector2 (80,0), Color.White);
        _spriteBatch.DrawString(font,poengR.ToString(), new Vector2 (WINDOW_WHITE-100,0), Color.White);

        foreach (var mittengubbe in mittengubbar)
        {
            mittengubbe.Draw(_spriteBatch);
        }
        foreach (var mittengubberod in mittengubbarrod)
        {
            mittengubberod.Draw(_spriteBatch);
        }

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    
}
