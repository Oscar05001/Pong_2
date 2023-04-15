using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace Pong_2;

public class Game1 : Game
{
    public static PaddelLeft lp;
    public static PaddelRight rp;
    public static Powerup power;
    SettingScreen settscreen;
    public SaveandLode settings;
    private const string PATH = "setting.json";

    MouseState mouse;
    

    //Arena box
    public static int ARENA_ROOF = 0;

    public static int ARENA_FLORE = WINDOW_HEIGHT;
    
    public static int ARENA_LEFT_WALL = 0;
    
    public static int ARENA_RIGHT_WALL = WINDOW_WHITE;
    //


    //Y
    public const int WINDOW_HEIGHT = 800;
    //X
    public const int WINDOW_WHITE = 1400;


    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public static List<Mittengubbe> mittengubbar = new List<Mittengubbe>();

    public static List<Mittengubberod> mittengubbarrod = new List<Mittengubberod>();

    public static List<Bolarna> bolarna = new List<Bolarna>();

    public static List<Powerupfigur> powerupfigur = new List<Powerupfigur>();
    
    
    KeyboardState bldState;
    Keys O = Keys.O;

    
    static Texture2D pixel;
    Texture2D coin;
    SpriteFont font;
    Random rnd = new Random();
    
    //SpriteFont meny;

    
    //(X,Y,Bred,Höjd)
    public static Rectangle bol = new Rectangle((ARENA_RIGHT_WALL/2)-7, ARENA_FLORE/2,15,15);


    Rectangle strek = new Rectangle(ARENA_RIGHT_WALL/2, 5,2,ARENA_FLORE-2);

    public static Rectangle mi = new Rectangle(ARENA_RIGHT_WALL/2-6, (int)(Game1.ARENA_FLORE*0.5)-50,15,100);

    //Padel speed
    public  static double padelspeedR{get; private set;}
    public  static double padelspeedL{get; private set;}
    public  static double padelspeedM{get; private set;}
    

    private int speedmid = 8;
    private int randommidspeed;

    private static double speedboostL;
    private static double speedboostR;
    private static double speedboostbolar;


    public static bool savemeny{get; set;} = false;    


    public static int poengL{get; set;} = 0;

    public static int poengR{get; set;} = 0;

    

    
    
    
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferHeight = Game1.WINDOW_HEIGHT;
        _graphics.PreferredBackBufferWidth = Game1.WINDOW_WHITE;
        
        
    }   

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        settings = new SaveandLode()
        {
        Scren_WHITE = 800,
        Scren_HEIGHT = 1200,
        Paddelspeedboost = 1, 
        MittenPaddelspeedboost = 1,
        Bolspeedboost = 1,
        PaddelLeftStartSpeed = 5, 
        PaddelRightStartSpeed = 5,
        BolStartSpeed = 4,
        PaddelMittenStartSpeed = 8, 

        };

        
        
        
        

        

        coin = Content.Load<Texture2D>("Coin");
        pixel = Content.Load<Texture2D>("Namnlspixel");
        font = Content.Load<SpriteFont>("File");
        //meny = Content.Load<SpriteFont>("Meny");


        lp = new PaddelLeft(pixel, 50,Keys.W, Keys.S,Keys.T,Keys.P);
        rp = new PaddelRight(pixel, ARENA_RIGHT_WALL-60,Keys.Up,Keys.Down,Keys.Y,Keys.P);
        settscreen = new SettingScreen(pixel,font);
        power = new Powerup();

        settings = Load();
        lp.LoadContent();
        rp.LoadContent();
        settscreen.LoadContent();
        




        foreach (var bolen in bolarna)
        {
            bolen.LoadContent();
        }

        
        
        

       

        
        
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        //Exit (rör ej)
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Save(settings);
            Exit();
        }

        mouse = Mouse.GetState();

         //Lägger till en bol i början
        if(bolarna.Count<1){
            bolarna.Add(new Bolarna(pixel));
        }

        for (int i = 0; i < bolarna.Count; i++)
        {
            
            if(bolarna[i].aredod)
            {
                bolarna.RemoveAt(i); 
                i--;

            }

        }
       
        

        if(savemeny==true){
            lp.LoadContent();
            rp.LoadContent();
            settings = Load();

            foreach (var bolen in bolarna)
            {
                bolen.LoadContent();
            }

            savemeny = false;

        }
            

        

        KeyboardState jstate = Keyboard.GetState();

        // TODO: Add your update logic here

        base.Update(gameTime);



        //Set speed allting
        padelspeedL = settings.PaddelLeftStartSpeed;
        padelspeedL += speedboostL;
        padelspeedL += Powerup.leftspeedboost;
        padelspeedL *= settings.Paddelspeedboost;

        padelspeedR = settings.PaddelRightStartSpeed;
        padelspeedR += speedboostR;
        padelspeedR += Powerup.rightspeedboost;
        padelspeedR *= settings.Paddelspeedboost;

        padelspeedM = settings.PaddelMittenStartSpeed;
        padelspeedM *= settings.MittenPaddelspeedboost;
        //
        

        if (!SettingScreen.settingwindoon){
            mi.Y += speedmid;

        }
        




        //Mid padel
        if (mi.Y <= Game1.ARENA_ROOF ){
            randommidspeed = rnd.Next(4,8);
            mi.Height = rnd.Next(70,151);
            speedmid = randommidspeed * (int)settings.MittenPaddelspeedboost;
            
            
        }

        if ( mi.Y+mi.Height >= ARENA_FLORE ){
            randommidspeed = rnd.Next(4,8);
            mi.Height = rnd.Next(70,151);
            speedmid = randommidspeed * (int)settings.MittenPaddelspeedboost;
            speedmid *= -1;
            
        }


    	
        foreach (var bolen in bolarna)
        {

            if(bldState.IsKeyUp(O) && jstate.IsKeyDown(O)){
            
                Powerup.Powerupsen(Bolarna.toutch,pixel);  
            
            }
            bldState = jstate;

        }

        

            

        
        

        //Update andra obijekt

        lp.Update();
        rp.Update();
        power.Update();
        settscreen.Update();

        foreach (var mittengubbe in mittengubbar)
        {
            mittengubbe.Update();
        }
        foreach (var mittengubberod in mittengubbarrod)
        {
            mittengubberod.Update();

            
        }
        foreach (var bolen in bolarna)
        {

            bolen.Update();

        }

        foreach (var figuren in powerupfigur)
        {

            figuren.Update();

        }
       

    }

    

    public static void Resetpoint(){
        poengL = 0;
        poengR = 0;

    }

    private void Save(SaveandLode saves)
    {
        string serializedText = JsonSerializer.Serialize<SaveandLode>(saves);
        Trace.WriteLine(serializedText);
        File.WriteAllText(PATH,serializedText);



    }

    
        
    

   


    

    private SaveandLode Load()
    {
        var fileconten = File.ReadAllText(PATH);
        
        return JsonSerializer.Deserialize<SaveandLode>(fileconten);

    
    }



    




    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        

        _spriteBatch.Begin();
        

        _spriteBatch.Draw(pixel, strek, Color .White);  
        
        
        
    
        _spriteBatch.Draw(pixel, mi, Color .Yellow);

        

        
        
        
        _spriteBatch.DrawString(font,poengL.ToString(), new Vector2 (80,0), Color.White);
        _spriteBatch.DrawString(font,poengR.ToString(), new Vector2 (ARENA_RIGHT_WALL-100,0), Color.White);

        

        foreach (var mittengubbe in mittengubbar)
        {
            mittengubbe.Draw(_spriteBatch);
        }
        foreach (var mittengubberod in mittengubbarrod)
        {
            mittengubberod.Draw(_spriteBatch);
        }
        foreach (var bolen in bolarna)
        {
            bolen.Draw(_spriteBatch);
        }
        foreach (var figuren in powerupfigur)
        {
            figuren.Draw(_spriteBatch,coin);
        }
        
        power.Draw(_spriteBatch,font);
        lp.Draw(_spriteBatch);
        rp.Draw(_spriteBatch);

        settscreen.Draw(_spriteBatch);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    
}
