using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public void Update(){
            KeyboardState lstate = Keyboard.GetState();

            KeyboardState rstate = Keyboard.GetState();

            KeyboardState ustate = Keyboard.GetState();

            KeyboardState nstate = Keyboard.GetState();
            
            KeyboardState estate = Keyboard.GetState();
           
            KeyboardState kstate = Keyboard.GetState();

            if(settingwindoon==false){
                vilkenRutaX = 1;
                vilkenRutaY = 1;
            }

            if(vilkenRutaX == 1)
                setting.X = 210;
            else if(vilkenRutaX == 2)
                setting.X = 300;
            else if(vilkenRutaX == 3)
                setting.X = 390;
            else if(vilkenRutaX == 4)
                setting.X = 470;

            


            
            if(lldState.IsKeyUp(Left) && lstate.IsKeyDown(Left) && vilkenRutaX > 1){
                
                if(vilkenRutaY == 1){
                    vilkenRutaX -= 1;
 
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

    	

            if(rldState.IsKeyUp(Right) && rstate.IsKeyDown(Right) && vilkenRutaX < 4){
                
                if(vilkenRutaY == 1){
                    vilkenRutaX += 1;  
 
                }
                
                if(vilkenRutaX == 2 && vilkenRutaY == 2 && paddelLeftStartSpeedSetting<10){
                    paddelLeftStartSpeedSetting += 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 3 && paddelRightStartSpeedSetting<10){
                    paddelRightStartSpeedSetting += 1;
                }

                if(vilkenRutaX == 2 && vilkenRutaY == 4 && paddelMidStartSpeedSetting<10){
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

    	

            if(nldState.IsKeyUp(Down) && nstate.IsKeyDown(Down) && vilkenRutaY < 4 && vilkenRutaX !=4){
                
                if(vilkenRutaX == 3 && vilkenRutaY == 3){


                }
                else
                {
                    vilkenRutaY += 1;
                }
                
                
            
            }

                nldState = nstate;

            if(eldState.IsKeyUp(Enter) && estate.IsKeyDown(Enter)){
                if(vilkenRutaX == 1 && vilkenRutaY == 2){
                    Game1.Resetpoint();
                }

                if(vilkenRutaX == 1 && vilkenRutaY == 3){
                    Game1.Resetround();
                }

                if(vilkenRutaX == 1 && vilkenRutaY == 4){
                    clearmid = true;
                }
                
                
                if(vilkenRutaX == 4){
                    settingwindoon = false;
                    vilkenRutaY = 1;
                    vilkenRutaX = 1;
                    settings.PaddelLeftStartSpeed = paddelLeftStartSpeedSetting;
                    settings.PaddelRightStartSpeed = paddelRightStartSpeedSetting;
                    settings.PaddelMittenStartSpeed = paddelMidStartSpeedSetting;
                    settings.Paddelspeedboost = paddelBoostSetting;
                    settings.MittenPaddelspeedboost = paddelMidBoostSetting;
                    Save(settings);
                    Game1.savemeny= true;
                    LoadContent();
                }

            }
                

                eldState = estate;


            if(oldState.IsKeyUp(P) && kstate.IsKeyDown(P)){
            if(settingwindoon==false){
                paddelLeftStartSpeedSetting = settings.PaddelLeftStartSpeed;
                paddelRightStartSpeedSetting = settings.PaddelRightStartSpeed;
                paddelMidStartSpeedSetting = settings.PaddelMittenStartSpeed;
                paddelBoostSetting = settings.Paddelspeedboost;
                paddelMidBoostSetting = settings.MittenPaddelspeedboost;
                
            }
            
            settingwindoon = !settingwindoon;
             }

            oldState = kstate;


        }

        public  void LoadContent(){
            settings = Load();
            
            
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


        
        
        public void Draw(SpriteBatch spriteBatch){
            
            if(settingwindoon==true){
                spriteBatch.Draw(pixel,whitescreen,Color.White);
                spriteBatch.Draw(pixel,blackscreen,Color.Black );
                spriteBatch.Draw(pixel,setting,Color.White );

                if(vilkenRutaX==1)
                    spriteBatch.DrawString(font,("Game"), new Vector2 (214,228), Color.Black);
                else
                    spriteBatch.DrawString(font,("Game"), new Vector2 (214,228), Color.White);
                
                if(vilkenRutaX==2)
                    spriteBatch.DrawString(font,("Setting"), new Vector2 (301,228), Color.Black);
                else
                    spriteBatch.DrawString(font,("Setting"), new Vector2 (301,228), Color.White);

                if(vilkenRutaX==3)
                    spriteBatch.DrawString(font,("Boost"), new Vector2 (398,228), Color.Black);
                else
                    spriteBatch.DrawString(font,("Boost"), new Vector2 (398,228), Color.White);


                if(vilkenRutaX==4)
                    spriteBatch.DrawString(font,("Save"), new Vector2 (476,228), Color.Black);
                else
                    spriteBatch.DrawString(font,("Save"), new Vector2 (476,228), Color.White);

                //Game
                if(vilkenRutaX==1){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("<Reset point>"), new Vector2 (205,270), Color.White);
                    else
                        spriteBatch.DrawString(font,("Reset point"), new Vector2 (214,270), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("<Reset round>"), new Vector2 (205,300), Color.White);
                    else
                        spriteBatch.DrawString(font,("Reset round"), new Vector2 (214,300), Color.White);
                    
                    if(vilkenRutaY==4)
                        spriteBatch.DrawString(font,("<Clear mid>"), new Vector2 (205,330), Color.White);
                    else
                        spriteBatch.DrawString(font,("Clear mid"), new Vector2 (214,330), Color.White);

                }

                //Setting
                if(vilkenRutaX==2){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("Left paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelLeftStartSpeedSetting)) + ">"), new Vector2 (205,270), Color.White);
                    else
                        spriteBatch.DrawString(font,("Left paddel start speed " + Convert.ToString(Convert.ToInt32(paddelLeftStartSpeedSetting))), new Vector2 (214,270), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("Right paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelRightStartSpeedSetting)) + ">"), new Vector2 (205,300), Color.White);
                    else
                        spriteBatch.DrawString(font,("Right paddel start speed " + Convert.ToString(Convert.ToInt32(paddelRightStartSpeedSetting))), new Vector2 (214,300), Color.White);
                    
                    if(vilkenRutaY==4)
                        spriteBatch.DrawString(font,("Midel paddel start speed <" + Convert.ToString(Convert.ToInt32(paddelMidStartSpeedSetting)) + ">"), new Vector2 (205,330), Color.White);
                    else
                        spriteBatch.DrawString(font,("Midel paddel start speed " + Convert.ToString(Convert.ToInt32(paddelMidStartSpeedSetting))), new Vector2 (214,330), Color.White);
                }

                //Boost
                if(vilkenRutaX==3){

                    if(vilkenRutaY==2)
                        spriteBatch.DrawString(font,("Paddel boost <" + Convert.ToString(Convert.ToDouble(paddelBoostSetting)) + ">"), new Vector2 (205,270), Color.White);
                    else
                        spriteBatch.DrawString(font,("Paddel boost " + Convert.ToString(Convert.ToDouble(paddelBoostSetting))), new Vector2 (214,270), Color.White);
                    
                    if(vilkenRutaY==3)
                        spriteBatch.DrawString(font,("Miten paddel boost <" + Convert.ToString(Convert.ToDouble(paddelMidBoostSetting)) + ">"), new Vector2 (205,300), Color.White);
                    else
                        spriteBatch.DrawString(font,("Mitten paddel boost " + Convert.ToString(Convert.ToDouble(paddelMidBoostSetting))), new Vector2 (214,300), Color.White);
                    
        
                }


                

            
            }

            
            
        }

    }
}
