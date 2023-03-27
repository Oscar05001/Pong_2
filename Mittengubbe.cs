using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_2
{
    public class Mittengubbe
    {
        Texture2D pixel;
        Rectangle mittengubbar;

        float timerpower;
        int speed;
        int inspeed;
        public bool aredod;
                

        Random rnd = new Random();


        public Mittengubbe(Texture2D pixel, int speed,float timerpower){
            mittengubbar = new Rectangle(rnd.Next(50,Game1.WINDOW_WHITE-50),0,15,100);
            
            this.pixel = pixel;
            this.speed = inspeed;
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





        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,mittengubbar,Color.Yellow);
        }

        public void ChangeY(int value){
            mittengubbar.Y += value;
        }
        

    }
}