using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.Json;
using System.IO;

namespace Pong_2
{

    public class Bolarna
    {

        Texture2D pixel;
        public static Rectangle bolarna;

        

        
        private SaveandLode settings;
        private const string PATH = "setting.json";


        public Rectangle Bollarna{
                get{return bolarna;}
                set{bolarna = value;}
            }
        

        public static int bolspeedX{get; private set;} = 4;
        public static int bolspeedY{get; private set;} = 4;
        public static int toutch{get; private set;} = 4;
        public static bool vetej{get; private set;} = false;
        public bool aredod{get; private set;} = false;

        private float väntatimermid;
        private float väntatimermidrod;
        private float väntatimerleftpadel;
        private float väntatimerrightpdel;
        private float väntatimerensammid;
        Random rnd = new Random();

        //(X,Y,Bred,Höjd)
        
        
        

        public Bolarna(Texture2D pixel){

            Random rnd = new Random();

            bolarna = new Rectangle((Game1.ARENA_RIGHT_WALL/2)-7,rnd.Next(10,Game1.ARENA_FLORE-10),15,15);
                
            this.pixel = pixel;
            
                
            
            }



        public void Update(){

            
            

            

            väntatimermid -= 1f/60f;
            väntatimermidrod -= 1f/60f;
            väntatimerleftpadel -= 1f/60f;
            väntatimerrightpdel -= 1f/60f;
            väntatimerensammid -= 1f/60f;

            if (!SettingScreen.settingwindoon){

        
                //Kör bol mid paddel
                bolarna.Y += bolspeedY;
                bolarna.X += bolspeedX;

                
            }

            //Ändra bol Y
            if(bolarna.Y <= Game1.ARENA_ROOF || bolarna.Y+bolarna.Height >= Game1.ARENA_FLORE ){
                bolspeedY *= -1;
                
                
            }





            //Poeng
            if(bolarna.X <= Game1.ARENA_LEFT_WALL ){
                
                Game1.poengR ++;
                bolspeedX = -5;
                bolarna.X = Game1.ARENA_RIGHT_WALL/2;
                bolarna.Y = Game1.ARENA_FLORE/2;
                bolspeedX *= -1;
                aredod = true;
                
                
                
            }


            if(bolarna.X+bolarna.Height >= Game1.ARENA_RIGHT_WALL){
                
                Game1.poengL++;
                bolspeedX = 5;
                bolarna.X = Game1.ARENA_RIGHT_WALL/2;
                bolarna.Y = Game1.ARENA_FLORE/2;
                bolspeedX *= -1;
                aredod = true;
                
                
        
            }
            //


            //boll rör padel ädnar X
            if(bolarna.Intersects(PaddelRight.kubeR)&&väntatimerrightpdel <= 0)
            {   
                if(toutch==0)
                    bolspeedX += 1;
                bolspeedX *= -1;
                toutch = 1;
                väntatimerrightpdel = 0.2f;
                
            }

            if(bolarna.Intersects(PaddelLeft.kubeL)&&väntatimerleftpadel <= 0)
            {
                if(toutch==1)
                    bolspeedX -= 1;
                bolspeedX *= -1;
                toutch = 0;
                väntatimerleftpadel = 0.2f;
                
            }

            if(bolarna.Intersects(Game1.mi)&&väntatimerensammid<=0)
            {
                bolspeedX *= -1;
                
                väntatimerensammid = 0.2f;
                    
            }  



            foreach (var mittengubbe in Game1.mittengubbar)
            {
                if(mittengubbe.Mittengubar.Intersects(bolarna)&&väntatimermidrod<=0)
                {
                    bolspeedX *= -1;

                    väntatimermidrod = 0.2f;

                }
            }

            foreach (var mittengubberod in Game1.mittengubbarrod)
            {
                if(mittengubberod.Mittengubbarrod.Intersects(bolarna)&&väntatimermid<=0)
                {
                    bolspeedX *= -1;
                    väntatimermid = 0.2f; 
                    
                } 

            }
            //

            //Powerup kör
            for (int i = 0; i < Game1.powerupfigur.Count; i++)
            {
                
                if(Game1.powerupfigur[i].Power.Intersects(bolarna))
                {   
                    Powerup.Powerupsen(toutch,pixel);
                    Game1.powerupfigur.RemoveAt(i); 
                    i--;

                }

            }


            


            

            if(vetej){

                bolspeedX = 5;
                bolarna.X = (Game1.ARENA_RIGHT_WALL/2)-7;
                bolarna.Y = Game1.ARENA_FLORE/2;
                Game1.mi.Y = 2;
                toutch = 4;

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