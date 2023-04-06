using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pong_2
{
    public class PaddelLeft
    {

        private const string PATH = "setting.json";
        Texture2D pixel;
        KeyboardState oldState;
        Keys up;
        Keys down;
        Keys toggle;
        Keys paus;

        Rectangle padel;
        private SaveandLode settings;
        
        
        public static int bolvar;

        public bool ai = false;

        public static int color = 0;

        
        


        

        public Rectangle Paddle{
            get{return padel;}
            set{padel = value;}
        }
        
        // true left , falce right
        public PaddelLeft( Texture2D pixel, int x, Keys up, Keys down,Keys toggle,Keys paus){
            padel = new Rectangle(x, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);
            this.up = up;
            this.down = down;
            this.pixel = pixel;
            this.toggle = toggle;
            this.paus = paus;
            
            
        }



        public void Update(){
            KeyboardState kstate = Keyboard.GetState();

            if(SettingScreen.settingwindoon==false){
                if(!ai){

                    HumanController(kstate);
                }
                else{
                    AIController();
                }
            }



            if(oldState.IsKeyUp(toggle) && kstate.IsKeyDown(toggle))
                ai = !ai;

            oldState = kstate;

            
            if(Game1.padelspeedL>settings.PaddelLeftStartSpeed)
                color = 1;
            else
                color = 0;
            

            

        }

        private void AIController(){
            //Dator
  
            //true == Ai vänster
                
            if(Game1.bolspeedX<0 && Game1.bol.X<Game1.WINDOW_WHITE/2){
                bolvar = Game1.bol.Y;
            }
            else
                bolvar = Game1.WINDOW_HEIGHT/2;

            if(Game1.bolspeedX>0 && Game1.bol.X>Game1.WINDOW_WHITE/2){
                bolvar = Game1.WINDOW_HEIGHT/2;

            }

        
            if(bolvar >= Paddle.Y + Paddle.Height/2 && Paddle.Y <= Game1.WINDOW_HEIGHT-100)
                ChangeY((int)Game1.padelspeedL);

            if(bolvar <= Paddle.Y + Paddle.Height/2 && Paddle.Y >=0)
                ChangeY(-(int)Game1.padelspeedL);
                
               
                
        }


        private void HumanController(KeyboardState kstate)
        {
                
            if  (kstate.IsKeyDown(up) && padel.Y >= 0)
                ChangeY(-(int)Game1.padelspeedL);
            if  (kstate.IsKeyDown(down) && padel.Y <= Game1.WINDOW_HEIGHT-100)
                ChangeY((int)Game1.padelspeedL);
                
        }

         public void ChangeY(int value){
            padel.Y += value;
        }

        public void LoadContent(){
            settings = Load();
        }

        

        private SaveandLode Load()
        {
            var fileconten = File.ReadAllText(PATH);
            
            return JsonSerializer.Deserialize<SaveandLode>(fileconten);

        
        }

    

        public void Draw(SpriteBatch spriteBatch){
            if(color==0){
            spriteBatch.Draw(pixel,padel,Color.White);
            }
            if(color==1){
            spriteBatch.Draw(pixel,padel,Color.Red);
            }
        }

       
        
    }
}
