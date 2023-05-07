using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong_2
{
    public class SettingScreen
    {
        private const string PATH = "setting.json";

        Texture2D pixel;
        SpriteFont font;
        Rectangle setting;
        Rectangle whitescreen;
        Rectangle blackscreen;
        MouseState mouse;
        private SaveandLode settings;
        


        


        Keys Left = Keys.Left;
        Keys Right = Keys.Right;
        Keys Up = Keys.Up;
        Keys Down = Keys.Down;
        Keys Enter = Keys.Enter;
        Keys P = Keys.P;
        KeyboardState lldState;
        KeyboardState rldState;
        KeyboardState uldState;
        KeyboardState nldState;
        KeyboardState eldState;
        KeyboardState oldState;

        public static bool settingwindoon = false;

        int vilkenRutaX = 1;
        int vilkenRutaY = 1;

        public static bool clearmid = false;
        int paddelLeftStartSpeedSetting = 0;
        int paddelRightStartSpeedSetting = 0;
        int paddelMidStartSpeedSetting = 0;

        double paddelBoostSetting = 1;
        double paddelMidBoostSetting = 1;

        private int volym = 100;
        private float sendit = 0;
        


        int mouseXstratPos;
        int mouseYstartPos;
        bool screenmove = false;

        public Rectangle Setting{
            get{return setting;}
            set{setting = value;}
        }


        //X Y Bred Höjd
        public SettingScreen(Texture2D pixel,SpriteFont font){
            setting = new Rectangle(210, 228,65,24);
            whitescreen = new Rectangle(180, 200,390,250);
            blackscreen = new Rectangle(182, 202,386,246);
            this.pixel = pixel;
            this.font = font;

        }

        public void Update()
        {
            KeyboardState lstate = Keyboard.GetState();

            KeyboardState rstate = Keyboard.GetState();

            KeyboardState ustate = Keyboard.GetState();

            KeyboardState nstate = Keyboard.GetState();
            
            KeyboardState estate = Keyboard.GetState();
           
            KeyboardState kstate = Keyboard.GetState();

            mouse = Mouse.GetState();

            sendit -= 1f/60f;

            //rutan går efter musen när mna ska flyta den
            if(whitescreen.Contains(mouse.Position) && (int)mouse.LeftButton==1&&screenmove==false&&settingwindoon==true){
                mouseXstratPos = mouse.Position.X-whitescreen.X;
                mouseYstartPos = mouse.Position.Y-whitescreen.Y;
                screenmove = true;
                
            }

            if(screenmove==true && (int)mouse.LeftButton==1){
                whitescreen.X = mouse.Position.X-mouseXstratPos;
                whitescreen.Y = mouse.Position.Y-mouseYstartPos;
            }
            else{
                screenmove = false;
            
            }
            //

            //ifal rutan utanför rutan gå in i rutan 
            if (whitescreen.Y > Game1.WINDOW_HEIGHT-50){
                whitescreen.Y = 100;
            }

            if (whitescreen.X > Game1.WINDOW_WHITE-50){
                whitescreen.X = 100;
            }
            //



            if(settingwindoon==false){
                vilkenRutaX = 1;
                vilkenRutaY = 1;
            }

            

            blackscreen.X = whitescreen.X+2;
            blackscreen.Y = whitescreen.Y+2;

            //styra den lilla vit rutan i den stora rutan
            if(vilkenRutaX == 1){
                setting.Y = whitescreen.Y+30;
                setting.X = whitescreen.X+30;}
            else if(vilkenRutaX == 2){
                setting.Y = whitescreen.Y+30;
                setting.X = whitescreen.X+120;}
            else if(vilkenRutaX == 3){
                setting.Y = whitescreen.Y+30;
                setting.X = whitescreen.X+210;}
            else if(vilkenRutaX == 4){
                setting.Y = whitescreen.Y+30;
                setting.X = whitescreen.X+295;}
            //
            


            //styr run i settings menyn
            if(lldState.IsKeyUp(Left) && lstate.IsKeyDown(Left)||(lstate.IsKeyDown(Left)&&sendit<=0)){
                
                if(vilkenRutaY == 1&&vilkenRutaX>=2){
                    vilkenRutaX -= 1;
 
                }

                if(lldState.IsKeyUp(Left) && lstate.IsKeyDown(Left))
                    sendit = 1;


                

                if(vilkenRutaX == 1 && vilkenRutaY == 5 && volym>0){
                    volym -= 1;
                }
                
                if(vilkenRutaX == 2 &&vilkenRutaY == 2 && paddelLeftStartSpeedSetting>1){
                    paddelLeftStartSpeedSetting -= 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 3 && paddelRightStartSpeedSetting>1){
                    paddelRightStartSpeedSetting -= 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 4 && paddelMidStartSpeedSetting>1){
                    paddelMidStartSpeedSetting -= 1;
                }

                if(vilkenRutaX == 3 && vilkenRutaY == 2 && paddelBoostSetting>1){
                    paddelBoostSetting -= 0.5f;
                }

                if(vilkenRutaX == 3 && vilkenRutaY == 3 && paddelMidBoostSetting>1){
                    paddelMidBoostSetting -= 0.5f;
                }



            }

                lldState = lstate;

    	

            if(rldState.IsKeyUp(Right) && rstate.IsKeyDown(Right) && vilkenRutaX < 4||(rstate.IsKeyDown(Right)&&sendit<=0)){
                
                if(vilkenRutaY == 1){
                    vilkenRutaX += 1;  
 
                }

                if(rldState.IsKeyUp(Right) && rstate.IsKeyDown(Right))
                    sendit = 1;


                if(vilkenRutaX == 1 && vilkenRutaY == 5 && volym<=99){
                    volym += 1;
                }
                
                if(vilkenRutaX == 2 && vilkenRutaY == 2 && paddelLeftStartSpeedSetting<15){
                    paddelLeftStartSpeedSetting += 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 3 && paddelRightStartSpeedSetting<15){
                    paddelRightStartSpeedSetting += 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 4 && paddelMidStartSpeedSetting<20){
                    paddelMidStartSpeedSetting += 1;
                }

                if(vilkenRutaX == 3 && vilkenRutaY == 2 && paddelBoostSetting<5){
                    paddelBoostSetting += 0.5f;
                }

                if(vilkenRutaX == 3 && vilkenRutaY == 3 && paddelMidBoostSetting<5){
                    paddelMidBoostSetting += 0.5f;
                }

               
            
            
            }

                rldState = rstate;
            


            
            if(uldState.IsKeyUp(Up) && ustate.IsKeyDown(Up) && vilkenRutaY > 1 && vilkenRutaX !=4){
                vilkenRutaY -= 1;
                
            
            }

                uldState = ustate;

    	

            if(nldState.IsKeyUp(Down) && nstate.IsKeyDown(Down) && vilkenRutaY < 5 && vilkenRutaX !=4){
                
                if(vilkenRutaX == 3 && vilkenRutaY == 3){


                }
                else if(vilkenRutaX == 2 && vilkenRutaY == 4){


                }
                else
                {
                    vilkenRutaY += 1;
                }
                
            }

                nldState = nstate;
            //
            
            //gör någonting när man trycket på enter
            if(eldState.IsKeyUp(Enter) && estate.IsKeyDown(Enter)){
                if(vilkenRutaX == 1 && vilkenRutaY == 2){
                    Game1.Resetpoint();
                }

                if(vilkenRutaX == 1 && vilkenRutaY == 3){
                    Bolarna.Resetround();
                }

                if(vilkenRutaX == 1 && vilkenRutaY == 4){
                    clearmid = true;
                }
                
                
                

            }
                

                eldState = estate;
            //

            //pausar och startar menyn
            if(oldState.IsKeyUp(P) && kstate.IsKeyDown(P)){
                if(settingwindoon==false){
                    paddelLeftStartSpeedSetting = settings.PaddelLeftStartSpeed;
                    paddelRightStartSpeedSetting = settings.PaddelRightStartSpeed;
                    paddelMidStartSpeedSetting = settings.PaddelMittenStartSpeed;
                    paddelBoostSetting = settings.Paddelspeedboost;
                    paddelMidBoostSetting = settings.MittenPaddelspeedboost;
                    whitescreen.X = settings.SettingScreenX;
                    whitescreen.Y = settings.SettingScreenY;
                    
                }
                else{
                    vilkenRutaY = 1;
                    vilkenRutaX = 1;
                    settings.PaddelLeftStartSpeed = paddelLeftStartSpeedSetting;
                    settings.PaddelRightStartSpeed = paddelRightStartSpeedSetting;
                    settings.PaddelMittenStartSpeed = paddelMidStartSpeedSetting;
                    settings.Paddelspeedboost = paddelBoostSetting;
                    settings.MittenPaddelspeedboost = paddelMidBoostSetting;
                    settings.volym = volym;
                    settings.SettingScreenX = whitescreen.X;
                    settings.SettingScreenY = whitescreen.Y;
                    Save(settings);
                    Game1.savemeny= true;
                    LoadContent();

                }
            
                settingwindoon = !settingwindoon;
             }

            oldState = kstate;

            
            //

            SetMusicVolume(volym/100f);
        }

        public  void LoadContent(){
            
            settings = Load();
            volym = settings.volym;
            
            
        }

        private SaveandLode Load()
        {
            var fileconten = File.ReadAllText(PATH);
            
            return JsonSerializer.Deserialize<SaveandLode>(fileconten);

        
        }

        private void Save(SaveandLode saves)
        {
            string serializedText = JsonSerializer.Serialize<SaveandLode>(saves);
            Trace.WriteLine(serializedText);
            File.WriteAllText(PATH,serializedText);



        }

        
        void SetMusicVolume(float vol)
        {
            MediaPlayer.Volume = vol;  
            // or use: MediaPlayer.Volume = vol * g.master_volume_factor; 
        }


        
        
        public void Draw(SpriteBatch spriteBatch){
            
            if(settingwindoon==true){
                spriteBatch.Draw(pixel,whitescreen,Color.White);
                spriteBatch.Draw(pixel,blackscreen,Color.Black );
                spriteBatch.Draw(pixel,setting,Color.White );
                
                //kategorier
                if(vilkenRutaX==1)
                    spriteBatch.DrawString(font,("Game"), new Vector2 (whitescreen.X+34,whitescreen.Y+28), Color.Black);
                else
                    spriteBatch.DrawString(font,("Game"), new Vector2 (whitescreen.X+34,whitescreen.Y+28), Color.White);
                
                if(vilkenRutaX==2)
                    spriteBatch.DrawString(font,("Setting"), new Vector2 (whitescreen.X+121,whitescreen.Y+28), Color.Black);
                else
                    spriteBatch.DrawString(font,("Setting"), new Vector2 (whitescreen.X+121,whitescreen.Y+28), Color.White);

                if(vilkenRutaX==3)
                    spriteBatch.DrawString(font,("Boost"), new Vector2 (whitescreen.X+218,whitescreen.Y+28), Color.Black);
                else
                    spriteBatch.DrawString(font,("Boost"), new Vector2 (whitescreen.X+218,whitescreen.Y+28), Color.White);


                if(vilkenRutaX==4)
                    spriteBatch.DrawString(font,("Info"), new Vector2 (whitescreen.X+310,whitescreen.Y+28), Color.Black);
                else
                    spriteBatch.DrawString(font,("Info"), new Vector2 (whitescreen.X+310,whitescreen.Y+28), Color.White);

                //Game
                if(vilkenRutaX==1){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("<Reset point>"), new Vector2 (whitescreen.X+25,whitescreen.Y+70), Color.White);
                    else
                        spriteBatch.DrawString(font,("Reset point"), new Vector2 (whitescreen.X+34,whitescreen.Y+70), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("<Reset round>"), new Vector2 (whitescreen.X+25,whitescreen.Y+100), Color.White);
                    else
                        spriteBatch.DrawString(font,("Reset round"), new Vector2 (whitescreen.X+34,whitescreen.Y+100), Color.White);
                    
                    if(vilkenRutaY==4)
                        spriteBatch.DrawString(font,("<Clear mid>"), new Vector2 (whitescreen.X+25,whitescreen.Y+130), Color.White);
                    else
                        spriteBatch.DrawString(font,("Clear mid"), new Vector2 (whitescreen.X+34,whitescreen.Y+130), Color.White);
                    if(vilkenRutaY==5)
                        spriteBatch.DrawString(font,("Volym "+"<"+volym.ToString()+">"), new Vector2 (whitescreen.X+25,whitescreen.Y+160), Color.White);
                    else
                        spriteBatch.DrawString(font,("Volym "+volym.ToString()), new Vector2 (whitescreen.X+34,whitescreen.Y+160), Color.White);

                }

                //Setting
                if(vilkenRutaX==2){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("Left paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelLeftStartSpeedSetting)) + ">"), new Vector2 (whitescreen.X+25,whitescreen.Y+70), Color.White);
                    else
                        spriteBatch.DrawString(font,("Left paddel start speed " + Convert.ToString(Convert.ToInt32(paddelLeftStartSpeedSetting))), new Vector2 (whitescreen.X+34,whitescreen.Y+70), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("Right paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelRightStartSpeedSetting)) + ">"), new Vector2 (whitescreen.X+25,whitescreen.Y+100), Color.White);
                    else
                        spriteBatch.DrawString(font,("Right paddel start speed " + Convert.ToString(Convert.ToInt32(paddelRightStartSpeedSetting))), new Vector2 (whitescreen.X+34,whitescreen.Y+100), Color.White);
                    
                    if(vilkenRutaY==4)
                        spriteBatch.DrawString(font,("Midel paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelMidStartSpeedSetting)) + ">"), new Vector2 (whitescreen.X+25,whitescreen.Y+130), Color.White);
                    else
                        spriteBatch.DrawString(font,("Midel paddel start speed " + Convert.ToString(Convert.ToInt32(paddelMidStartSpeedSetting))), new Vector2 (whitescreen.X+34,whitescreen.Y+130), Color.White);
                }

                //Boost
                if(vilkenRutaX==3){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("Paddel boost <" + Convert.ToString(Convert.ToDouble(paddelBoostSetting)) + ">"), new Vector2 (whitescreen.X+25,whitescreen.Y+70), Color.White);
                    else
                        spriteBatch.DrawString(font,("Paddel boost " + Convert.ToString(Convert.ToDouble(paddelBoostSetting))), new Vector2 (whitescreen.X+34,whitescreen.Y+70), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("Miten paddel boost <" + Convert.ToString(Convert.ToDouble(paddelMidBoostSetting)) + ">"), new Vector2 (whitescreen.X+25,whitescreen.Y+100), Color.White);
                    else
                        spriteBatch.DrawString(font,("Mitten paddel boost " + Convert.ToString(Convert.ToDouble(paddelMidBoostSetting))), new Vector2 (whitescreen.X+34,whitescreen.Y+100), Color.White);
                    
        
                }

                if(vilkenRutaX==4){

                    
                    spriteBatch.DrawString(font,("Toggel AI Left = T"), new Vector2 (whitescreen.X+25,whitescreen.Y+70), Color.White);
                    spriteBatch.DrawString(font,("Toggel AI Right = Y"), new Vector2 (whitescreen.X+25,whitescreen.Y+100), Color.White);
                    spriteBatch.DrawString(font,("If AI On you can move padel whid mouse"), new Vector2 (whitescreen.X+25,whitescreen.Y+130), Color.White);
                    spriteBatch.DrawString(font,("Left button for left padel"), new Vector2 (whitescreen.X+25,whitescreen.Y+160), Color.White);
                    spriteBatch.DrawString(font,("Right button for Right padel"), new Vector2 (whitescreen.X+25,whitescreen.Y+190), Color.White);
                    
                   



                }


               

            
            }

             
            
        }

        
    }
}
