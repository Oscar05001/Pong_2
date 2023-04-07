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
        double inspeed;
        public bool aredod;

        
                

        Random rnd = new Random();
        

        public Mittengubbe(Texture2D pixel,float timerpower){
            
            mittengubbar = new Rectangle(rnd.Next(100,(Game1.WINDOW_WHITE)-100),10,15,100);
            
            this.pixel = pixel;
            this.timerpower = timerpower;
            this.inspeed = Game1.padelspeedM;
            this.speed = (int)inspeed;
            
            
           
        }

        public void Update()
        {

        inspeed = Game1.padelspeedM; 

        if (mittengubbar.Y <= 0 ){
        speed = rnd.Next(2,10);
        speed += (int)inspeed;
        }

        if ( mittengubbar.Y+mittengubbar.Height >= Game1.WINDOW_HEIGHT ){
            speed = rnd.Next(2,10);
            speed += (int)inspeed;
            speed *= -1;
        }

        

        
        if (SettingScreen.settingwindoon == false)
        { 
            mittengubbar.Y += speed;
            timerpower -= 1f/60f;
        }
        if(timerpower<0)
        aredod = true;


        

        

        

        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,mittengubbar,Color.Yellow);
        }

        
        

    }
}