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
        MouseState mouse;
        
        
        public static int bolvar{get; private set;}

        public static int hurstor{get; set;} = 100;
        public static int hurbred{get; set;} = 15;


        private bool ai = true;

        private static int color = 0;

        
        
        public static Rectangle kubeL = new Rectangle (Game1.lp.Paddle.X-10, Game1.lp.Paddle.Y,Game1.lp.Paddle.Width+20,Game1.lp.Paddle.Height);

        

        public Rectangle Paddle{
            get{return padel;}
            set{padel = value;}
        }
        
        // true left , falce right
        public PaddelLeft( Texture2D pixel, int x, Keys up, Keys down,Keys toggle,Keys paus){
            padel = new Rectangle(x, (int)(Game1.ARENA_FLORE*0.5)-50,15,100);
            this.up = up;
            this.down = down;
            this.pixel = pixel;
            this.toggle = toggle;
            this.paus = paus;
            
            
        }



        public void Update(){
            KeyboardState kstate = Keyboard.GetState();

            mouse = Mouse.GetState();
            
            //kör kube
            kubeL.X = Paddle.X-20;
            kubeL.Y = Paddle.Y;
            kubeL.Height = Paddle.Height;
            kubeL.Width = Paddle.Width+20;
            //

            if(SettingScreen.settingwindoon==false){
               
                
                if(!ai){

                    HumanController(kstate);

                }
                else{
                if((int)mouse.LeftButton == 1){
            
            
                    MouseController(mouse);

                }
                else
                    AIController();
                }


                if  (hurstor < padel.Height)
                    ChangeH(-1);
                if  (hurstor > padel.Height)
                    ChangeH(1);

                if  (hurbred > padel.Width)
                    ChangeW(-1);
                if  (hurbred < padel.Width)
                    ChangeW(1);
                
            }



            if(oldState.IsKeyUp(toggle) && kstate.IsKeyDown(toggle))
                ai = !ai;

            oldState = kstate;

            
            if(Game1.padelspeedL>settings.PaddelLeftStartSpeed)
                color = 1;
            else if(ai)
                color = 2;
            else
                color = 0;
            

            

        }

        private void AIController(){
            //Dator
  
            //true == Ai vänster
                
            
                
            foreach (var bolar in Game1.bolarna)
            {   


                if(Bolarna.bolspeedX<0 && Bolarna.bolarna.X<Game1.ARENA_RIGHT_WALL/2){
                    bolvar = Bolarna.bolarna.Y;
                }
                else
                    bolvar = Game1.ARENA_FLORE/2;

                if(Bolarna.bolspeedX>0 && Bolarna.bolarna.X>Game1.ARENA_RIGHT_WALL/2){
                    bolvar = Game1.ARENA_FLORE/2;

                }

            
                if(bolvar >= Paddle.Y + Paddle.Height/2 && Paddle.Y <= Game1.ARENA_FLORE-padel.Height)
                    ChangeY((int)Game1.padelspeedL);

                if(bolvar <= Paddle.Y + Paddle.Height/2 && Paddle.Y >=Game1.ARENA_ROOF)
                    ChangeY(-(int)Game1.padelspeedL);


                    
                }



            
                
        }


        private void HumanController(KeyboardState kstate)
        {
                
            if  (kstate.IsKeyDown(up) && padel.Y >= Game1.ARENA_ROOF)
                ChangeY(-(int)Game1.padelspeedL);
            if  (kstate.IsKeyDown(down) && padel.Y <= Game1.ARENA_FLORE-padel.Height)
                ChangeY((int)Game1.padelspeedL);
                
        }

        private void MouseController(MouseState mouse)
        {
                
            if  (mouse.Position.Y < padel.Y+(padel.Height/2)&& padel.Y >= Game1.ARENA_ROOF)
                ChangeY(-(int)Game1.padelspeedL);
            if  (mouse.Position.Y > padel.Y+(padel.Height/2) && padel.Y <= Game1.ARENA_FLORE-padel.Height)
                ChangeY((int)Game1.padelspeedL);
                
        }

         public void ChangeY(int value){
            padel.Y += value;
        }

        public void LoadContent(){
            settings = Load();
        }

        public void ChangeH(int value){
            padel.Height += value;
        }

        public void ChangeW(int value){
            padel.Width += value;
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
