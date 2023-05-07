using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Text.Json;
using System.IO;


namespace Pong_2
{

    public class Bolarna
    {

        Texture2D pixel;
        private Rectangle bolarna;

        SoundEffect måleffect;
        SoundEffect powereffect;
        SoundEffect hiteffect;

        

        
        private SaveandLode settings;
        private const string PATH = "setting.json";


        public Rectangle Bollarna{
                get{return bolarna;}
                set{bolarna = value;}
            }
        

        public  int bolspeedX{get; private set;} = 4;
        public int bolspeedY{get; private set;} = 4;
        public int toutch{get; private set;} = 4;
        public static bool vetej{get; private set;} = false;
        public bool aredod{get; private set;} = false;
        
        private int speedX = 4;
        private int speedY = 4;
        private float väntatimermid;
        private float väntatimermidrod;
        private float väntatimerensammid;
        Random rnd = new Random();

        //(X,Y,Bred,Höjd)
        
        
        

        public Bolarna(Texture2D pixel,SoundEffect effect,SoundEffect powereffect,SoundEffect hiteffect){

            Random rnd = new Random();

            bolarna = new Rectangle((Mindrebana.ARENA_RIGHT_WALL/2)-7,rnd.Next(10,Mindrebana.ARENA_FLORE-10),15,15);
                
            this.pixel = pixel;
            this.måleffect = effect;
            this.powereffect = powereffect;
            this.hiteffect = hiteffect;

            
                
            
            }



        public void Update(){

            
            
            
            

            väntatimermid -= 1f/60f;
            väntatimermidrod -= 1f/60f;
            väntatimerensammid -= 1f/60f;

            if (!SettingScreen.settingwindoon&&!Startmenu.startmenyon){

        
                //Kör bol mid paddel
                bolarna.Y += speedY;
                bolarna.X += speedX;

                
            }

            //Ändra bol Y
            if(bolarna.Y <= Mindrebana.ARENA_ROOF){
                speedY = bolspeedY;
                hiteffect.Play();
                
                
            }

            
            if(bolarna.Y+bolarna.Height >= Mindrebana.ARENA_FLORE ){
                speedY = bolspeedY * -1;
                hiteffect.Play();
                
                
            }




            if(Startmenu.startmenyon==false){
                //Poeng
                if(bolarna.X <= Mindrebana.ARENA_LEFT_WALL ){
                    
                    måleffect.Play();
                    Game1.poengR ++;
                    speedX = -5;
                    bolarna.X = Mindrebana.ARENA_RIGHT_WALL/2;
                    bolarna.Y = Mindrebana.ARENA_FLORE/2;
                    speedX *= -1;
                    aredod = true;
                    
                    
                    
                }


                if(bolarna.X+bolarna.Height >= Mindrebana.ARENA_RIGHT_WALL){
                    
                    måleffect.Play();
                    Game1.poengL++;
                    speedX = 5;
                    bolarna.X = Mindrebana.ARENA_RIGHT_WALL/2;
                    bolarna.Y = Mindrebana.ARENA_FLORE/2;
                    speedX *= -1;
                    aredod = true;
                    
                    
            
                }
                //


                //boll rör padel ädnar X
                if(bolarna.Intersects(PaddelRight.kubeR))
                {   
                    hiteffect.Play();
                    if(toutch==0)
                        bolspeedX += 1;
                    speedX = bolspeedX * -1;
                    toutch = 1;
                    
                    
                }

                if(bolarna.Intersects(PaddelLeft.kubeL))
                {
                    hiteffect.Play();
                    if(toutch==1)
                        bolspeedX -= 1;
                    speedX = bolspeedX;
                    toutch = 0;
                    
                    
                }

                if(bolarna.Intersects(Game1.mi)&&väntatimerensammid<=0)
                {
                    hiteffect.Play();
                    speedX *= -1;
                    
                    väntatimerensammid = 0.15f;
                        
                }  



                foreach (var mittengubbe in Game1.mittengubbar)
                {
                    if(mittengubbe.Mittengubar.Intersects(bolarna)&&väntatimermidrod<=0)
                    {
                        hiteffect.Play();
                        speedX *= -1;

                        väntatimermidrod = 0.15f;

                    }
                }

                foreach (var mittengubberod in Game1.mittengubbarrod)
                {
                    if(mittengubberod.Mittengubbarrod.Intersects(bolarna)&&väntatimermid<=0)
                    {
                        hiteffect.Play();
                        speedX *= -1;
                        väntatimermid = 0.15f; 
                        
                    } 

                }
                //

                //Powerup kör
                for (int i = 0; i < Game1.powerupfigur.Count; i++)
                {
                    
                    if(Game1.powerupfigur[i].Power.Intersects(bolarna))
                    {   
                        powereffect.Play();
                        Powerup.Powerupsen(toutch,pixel);
                        Game1.powerupfigur.RemoveAt(i); 
                        i--;

                    }

                }
            }


            


            

            if(vetej){

                speedX = 5;
                bolarna.X = (Mindrebana.ARENA_RIGHT_WALL/2)-7;
                bolarna.Y = Mindrebana.ARENA_FLORE/2;
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