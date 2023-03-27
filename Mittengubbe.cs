using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_2
{
    public class Mittengubbe
    {
        Texture2D pixel;
        Rectangle mittengubbar;


        public Rectangle Mittengubar{
            get{return mittengubbar;}
            set{mittengubbar = value;}
        }
        

        float timerpower;
        int speed;
        int inspeed;
        public bool aredod;
                

        Random rnd = new Random();
        


        public Mittengubbe(Texture2D pixel, int speed,float timerpower){
            
            mittengubbar = new Rectangle(rnd.Next(100,(Game1.WINDOW_WHITE)-100),10,15,100);
            
            this.pixel = pixel;
            this.speed = speed;
            this.timerpower = timerpower;
            
           
        }

        public void Update()
        {

        if (mittengubbar.Y <= 0 ){
        speed = rnd.Next(2,10);
        }

        if ( mittengubbar.Y+mittengubbar.Height >= Game1.WINDOW_HEIGHT ){
            speed = rnd.Next(2,10);
            speed += inspeed;
            speed *= -1;
        }

        

        

        mittengubbar.Y += speed;
        timerpower -= 1f/60f;

        if(timerpower<0)
        aredod = true;

        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,mittengubbar,Color.Yellow);
        }

        
        

    }
}