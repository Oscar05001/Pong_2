using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_2
{
    public class Mittengubberod
    {
        
        Texture2D pixel;
        Rectangle mittengubbarrod;


        public Rectangle Mittengubbarrod{
            get{return mittengubbarrod;}
            set{mittengubbarrod = value;}
        }
        

        float timerpower;
        int speedy;
        int speedx;
        int inspeed;
        public bool aredod;
                

        Random rnd = new Random();
        


        public Mittengubberod(Texture2D pixel, int speed,float timerpower){
            
            mittengubbarrod = new Rectangle(rnd.Next(100,(Game1.WINDOW_WHITE)-100),10,15,100);
            
            this.pixel = pixel;
            this.speedy = speed;
            this.speedx = speed;
            this.timerpower = timerpower;
            
           
        }

        public void Update()
        {

        if (mittengubbarrod.Y <= 0 ){
        speedy = rnd.Next(2,10);
        }

        if ( mittengubbarrod.Y+mittengubbarrod.Height >= Game1.WINDOW_HEIGHT ){
            speedy = rnd.Next(2,10);
            speedy += inspeed;
            speedy *= -1;
        }

        if (mittengubbarrod.X <= 200 ){
        speedx = rnd.Next(2,5);
        }

        if ( mittengubbarrod.X >= Game1.WINDOW_WHITE-200 ){
            speedx = rnd.Next(2,5);
            speedx += inspeed;
            speedx *= -1;
        }


        

        
        mittengubbarrod.X += speedx;
        mittengubbarrod.Y += speedy;

        timerpower -= 1f/60f;

        if(timerpower<0)
        aredod = true;

        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,mittengubbarrod,Color.Red);
        }

        
        
    }
}