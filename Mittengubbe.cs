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
        //0 Left 1 Right
        int vem;
        
        
        int x;
        int y;
        int h;

        
                

        Random rnd = new Random();
        

        public Mittengubbe(Texture2D pixel,float timerpower,int vem){
            
            
            this.vem = vem;
            

            if(vem != 3)
            {
                if(vem == 0)
                {
                    x = rnd.Next(100,(Game1.WINDOW_WHITE/2)-20);
                    y = rnd.Next(0,(Game1.WINDOW_HEIGHT)-100);

                }
                else
                {
                    x = rnd.Next((Game1.WINDOW_WHITE/2)+20,Game1.WINDOW_WHITE-120);
                    y = rnd.Next(0,(Game1.WINDOW_HEIGHT)-100);

                }

                h = 200;

            }
            else
            {
               x =  rnd.Next(100,(Game1.WINDOW_WHITE)-100);
               h = 100;

            }
            


            mittengubbar = new Rectangle(x,y,15,h);
            
            
            this.pixel = pixel;
            this.timerpower = timerpower;
            this.inspeed = Game1.padelspeedM;
            this.speed = (int)inspeed;
            

            
            
            
           
        }

        public void Update()
        {
        
       
        inspeed = Game1.padelspeedM; 

        if (mittengubbar.Y <= 0 ){
        speed = rnd.Next(2,8);
        speed += (int)inspeed;
        }

        if ( mittengubbar.Y+mittengubbar.Height >= Game1.WINDOW_HEIGHT ){
            speed = rnd.Next(2,8);
            speed += (int)inspeed;
            speed *= -1;
        }

        

        
        if (SettingScreen.settingwindoon == false)
        { 
            if(vem == 3)
                mittengubbar.Y += speed;

            timerpower -= 1f/60f;
        }
        if(timerpower<0)
        aredod = true;


        

        

        

        }

        public void Draw(SpriteBatch spriteBatch){

            if(vem == 3)
                spriteBatch.Draw(pixel,mittengubbar,Color.Yellow);
            else
                spriteBatch.Draw(pixel,mittengubbar,Color.Purple);
        }

        
        

    }
}