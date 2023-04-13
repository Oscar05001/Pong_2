using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_2
{

    public class Bolarna
    {

        Texture2D pixel;
        public static Rectangle bolarna;

        Powerup powerup;
        
        private SaveandLode settings;
        private const string PATH = "setting.json";


        public Rectangle Bollarna{
                get{return bolarna;}
                set{bolarna = value;}
            }
        

        public static int bolspeedX = 4;
        public static int bolspeedY = 4;
        public static int toutch = 0;
        public static bool vetej = false;
            
        Random rnd = new Random();

        //(X,Y,Bred,Höjd)
        Rectangle kubeR = new Rectangle (Game1.rp.Paddle.X, Game1.rp.Paddle.Y,Game1.rp.Paddle.Width+20,Game1.rp.Paddle.Height);
        
        Rectangle kubeL = new Rectangle (Game1.lp.Paddle.X-10, Game1.lp.Paddle.Y,Game1.lp.Paddle.Width+20,Game1.lp.Paddle.Height);

        public Bolarna(Texture2D pixel){
                
            bolarna = new Rectangle((Game1.WINDOW_WHITE/2)-7, Game1.WINDOW_HEIGHT/2,15,15);
                
            this.pixel = pixel;
            
                
            
            }



        public void Update(){

            
            kubeR.X = Game1.rp.Paddle.X;
            kubeR.Y = Game1.rp.Paddle.Y;
            kubeR.Height = Game1.rp.Paddle.Height;
            kubeR.Width = Game1.rp.Paddle.Width+20;

            kubeL.X = Game1.lp.Paddle.X-20;
            kubeL.Y = Game1.lp.Paddle.Y;
            kubeL.Height = Game1.lp.Paddle.Height;
            kubeL.Width = Game1.lp.Paddle.Width+20;


            if (!SettingScreen.settingwindoon){

        
                //Kör bol mid paddel
                bolarna.Y += bolspeedY;
                bolarna.X += bolspeedX;

                
            }

            //Ändra bol Y
            if(bolarna.Y <= 0 || bolarna.Y+bolarna.Height >= Game1.WINDOW_HEIGHT ){
                bolspeedY *= -1;
                
            }






            if(bolarna.X <= 0 ){
                
                Game1.poengR ++;
                bolspeedX = -5;
                bolarna.X = Game1.WINDOW_WHITE/2;
                bolarna.Y = Game1.WINDOW_HEIGHT/2;
                bolspeedX *= -1;
                Game1.mi.Y = 2;
                
            }


            if(bolarna.X+bolarna.Height >= Game1.WINDOW_WHITE){
                Game1.poengL++;
                bolspeedX = 5;
                bolarna.X = Game1.WINDOW_WHITE/2;
                bolarna.Y = Game1.WINDOW_HEIGHT/2;
                bolspeedX *= -1;
                Game1.mi.Y = 2;
        
            }


            //boll rör padel ädnar X
            if(bolarna.Intersects(kubeR))
            {
                bolspeedX += 1;
                bolspeedX *= -1;
                toutch = 1;
                
            }

            if(bolarna.Intersects(kubeL))
            {
                bolspeedX -= 1;
                bolspeedX *= -1;
                toutch = 0;
                
            }

            if(bolarna.Intersects(Game1.mi))
            {
                bolspeedX *= -1;
                float väntatimer = 2;
                    while(väntatimer>0)
                    {
                        väntatimer -= 1f/60f;

                    }
                
            }  



            foreach (var mittengubbe in Game1.mittengubbar)
            {
                if(mittengubbe.Mittengubar.Intersects(bolarna))
                {
                    bolspeedX *= -1;

                    float väntatimer = 1;
                    while(väntatimer>0)
                    {
                        väntatimer -= 1f/60f;

                    }
                } 
            
            }

            foreach (var mittengubberod in Game1.mittengubbarrod)
            {
                if(mittengubberod.Mittengubbarrod.Intersects(bolarna))
                {
                    bolspeedX *= -1;

                    float väntatimer = 1;
                    while(väntatimer>0)
                    {
                        väntatimer -= 1f/60f;

                    }
                    
                } 




            }




            if(Game1.power.Power.Intersects(bolarna))
            {
                Powerup.ompower = 1;
                
                Powerup.Powerupsen(toutch,pixel);
            
            }

            if(vetej){

                bolspeedX = 5;
                bolarna.X = (Game1.WINDOW_WHITE/2)-7;
                bolarna.Y = Game1.WINDOW_HEIGHT/2;
                Game1.mi.Y = 2;

                vetej = false;
            }





        }




        

        public void LoadContent(){

            
            settings = Load();

        }

        public static void Resetround(){
            vetej = true;

        }

            

        private SaveandLode Load()
        {
            var fileconten = File.ReadAllText(PATH);
            
            return JsonSerializer.Deserialize<SaveandLode>(fileconten);

        
        }




        public void Draw(SpriteBatch spriteBatch){
            
            spriteBatch.Draw(pixel, bolarna , Color .Blue);
            
            

        }




    }
}