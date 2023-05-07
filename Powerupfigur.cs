using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pong_2
{
    public class Powerupfigur
    {


       
        Rectangle power;



        int speedx = 2;
        int speedy = 2;


        public static int ompower = 1;
        
        

        Random rnd = new Random();


        public Rectangle Power{
            get{return power;}
            set{power = value;}
        }
        
        
        public Powerupfigur(){ 
            
            power = new Rectangle(Mindrebana.ARENA_RIGHT_WALL/2, Mindrebana.ARENA_FLORE/2,55,55);
            
        }


        public void Update(){
      
            if(!SettingScreen.settingwindoon){
            power.Y += speedy;
            power.X += speedx;
            }



            //Kör Y

            if (power.Y <= Mindrebana.ARENA_ROOF ){
                speedy = 2;
            }

            if ( power.Y+power.Height >= Mindrebana.ARENA_FLORE ){
                speedy = -2;
            }
            
            //Kör X

            if (power.X <= Mindrebana.ARENA_LEFT_WALL+70 ){
                speedx = 2;
            }

            if ( power.X+power.Height >= Mindrebana.ARENA_RIGHT_WALL-70){
                speedx = -2;
            }

            


        }


        public void Draw(SpriteBatch spriteBatch,Texture2D coin){
            
            spriteBatch.Draw(coin,power,Color.White);


        }

        
    }
}