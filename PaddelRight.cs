using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pong_2
{
    public class PaddelRight
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
        MouseState mouse;
        
        public static int bolvar;
        public static int hurstor = 100;
        public static int hurbred = 15;


        public bool ai = true;

        public static int color = 0;

        
        
        

        
        

        public Rectangle Paddle{
            get{return padel;}
            set{padel = value;}
        }
        
        // true left , falce right
        public PaddelRight( Texture2D pixel, int x, Keys up, Keys down,Keys toggle,Keys paus){
            padel = new Rectangle(x, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);
            this.up = up;
            this.down = down;
            this.pixel = pixel;
            this.toggle = toggle;
            this.paus = paus;
            
            
        }



        public void Update(){
            
            KeyboardState kstate = Keyboard.GetState();

            mouse = Mouse.GetState();
            
            if(SettingScreen.settingwindoon==false){
                
                if(!ai){

                    HumanController(kstate);

                }
                else{
                if((int)mouse.RightButton == 1){
            
            
                    MouseController(mouse);

                }
                else
                    AIController();
                }

                if  (hurstor < padel.Height)
                    ChangeH(-1);
                if  (hurstor > padel.Height)
                    ChangeH(1);

                if  (hurbred < padel.Width)
                    ChangeW(-1);
                if  (hurbred > padel.Width)
                    ChangeW(1);
            
            }
            if(oldState.IsKeyUp(toggle) && kstate.IsKeyDown(toggle))
                ai = !ai;

            oldState = kstate;


            
            

            
            if(Game1.padelspeedR>settings.PaddelRightStartSpeed)
                color = 1;
            else if(ai)
                color = 2;
            else
                color = 0;
            

        }

        private void AIController(){
            //Dator

            //Ai höger

            foreach (var bolar in Game1.bolarna)
            {   


                if(Bolarna.bolspeedX>0 && Bolarna.bolarna.X >Game1.WINDOW_WHITE/2){
                    bolvar = Bolarna.bolarna.Y;
                }
                else
                    bolvar = Game1.WINDOW_HEIGHT/2;
                
                if(Bolarna.bolspeedX<0 && Bolarna.bolarna.X<Game1.WINDOW_WHITE/2){
                    bolvar = Game1.WINDOW_HEIGHT/2;

                }
                
                if(bolvar >= Paddle.Y + Paddle.Height/2 && Paddle.Y <= Game1.WINDOW_HEIGHT-padel.Height)
                    ChangeY((int)Game1.padelspeedR);

                if(bolvar <= Paddle.Y + Paddle.Height/2 && Paddle.Y >=0)
                    ChangeY((int)-Game1.padelspeedR);


                
            }

            

            
            
            
        
            
                
      
                
        }


        private void HumanController(KeyboardState kstate)
        {
                
            if  (kstate.IsKeyDown(up) && padel.Y >= 0)
                ChangeY(-(int)Game1.padelspeedR);
            if  (kstate.IsKeyDown(down) && padel.Y <= Game1.WINDOW_HEIGHT-100)
                ChangeY((int)Game1.padelspeedR);

        }

        private void MouseController(MouseState mouse)
        {
                
            if  (mouse.Position.Y < padel.Y+(padel.Height/2)&& padel.Y >= 0)
                ChangeY(-(int)Game1.padelspeedL);
            if  (mouse.Position.Y > padel.Y+(padel.Height/2) && padel.Y <= Game1.WINDOW_HEIGHT-padel.Height)
                ChangeY((int)Game1.padelspeedL);
                
        }

        public void ChangeY(int value){
            padel.Y += value;
        }

        public void ChangeH(int value){
            padel.Height += value;
        }

        public void ChangeW(int value){
            padel.Width += value;
        }

        public  void LoadContent(){
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
            if(color==2){
            spriteBatch.Draw(pixel,padel,Color.Green);
            }
        }

        

        
    }
}
