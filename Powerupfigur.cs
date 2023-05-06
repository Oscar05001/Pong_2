using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pong_2
{
    public class Powerupfigur
    {


       
        Rectangle power;



        int speedx = 2;
        int speedy = 1;


        public static int ompower = 1;
        
        

        Random rnd = new Random();


        public Rectangle Power{
            get{return power;}
            set{power = value;}
        }
        
        
        public Powerupfigur(){ 
            
            power = new Rectangle(Game1.ARENA_RIGHT_WALL/2, Game1.ARENA_FLORE/2,55,55);
            
        }


        public void Update(){
      
            if(!SettingScreen.settingwindoon){
            power.Y += speedy;
            power.X += speedx;
            }



            //Kör Y

            if (power.Y <= Game1.ARENA_ROOF ){
                speedy *= -1;
            }

            if ( power.Y+power.Height >= Game1.ARENA_FLORE ){
                speedy *= -1;
            }
            
            //Kör X

            if (power.X <= Game1.ARENA_LEFT_WALL+70 ){
                speedx *= -1;
            }

            if ( power.X+power.Height >= Game1.ARENA_RIGHT_WALL-70){
                speedx *= -1;
            }

            


        }


        public void Draw(SpriteBatch spriteBatch,Texture2D coin){
            
            spriteBatch.Draw(coin,power,Color.White);


        }

        
    }
}