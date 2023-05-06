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
        

        private float timerpower;
        private int speedy;
        private int speedx;
        private double inspeed;


        public bool aredod{get; private set;}
                

        Random rnd = new Random();
        


        public Mittengubberod(Texture2D pixel,float timerpower){
            
            mittengubbarrod = new Rectangle(rnd.Next(Game1.ARENA_LEFT_WALL+120,(Game1.ARENA_RIGHT_WALL)-120),10,15,100);
            
            this.pixel = pixel;
            this.timerpower = timerpower;
            this.inspeed = Game1.padelspeedM;
            this.speedx = (int)inspeed;
            this.speedy = (int)inspeed;
            
            
           
        }

        public void Update()
        {
        
        inspeed = Game1.padelspeedM; 
        
        
           

        if (mittengubbarrod.Y <= Game1.ARENA_ROOF ){
            speedy = rnd.Next(2,8);
            speedy += (int)inspeed;
        }

        if ( mittengubbarrod.Y+mittengubbarrod.Height >= Game1.ARENA_FLORE ){
            speedy = rnd.Next(2,8);
            speedy += (int)inspeed;
            speedy *= -1;
        }

        foreach (var bolen in Game1.bolarna)
        {
            if(mittengubbarrod.Intersects(bolen.Bollarna)){
                speedx *= -1;
                speedx += (int)inspeed;
        }
        }
       

        if (mittengubbarrod.X <= Game1.ARENA_LEFT_WALL+150 ){
        speedx = rnd.Next(2,5);
        speedx += (int)inspeed;
        }

        if ( mittengubbarrod.X >= Game1.ARENA_RIGHT_WALL-150 ){
            speedx = rnd.Next(2,5);
            speedx += (int)inspeed;
            speedx *= -1;
        }


        

        if(!SettingScreen.settingwindoon &&!Startmenu.startmenyon)
        {
            mittengubbarrod.X += speedx;
            mittengubbarrod.Y += speedy;
            timerpower -= 1f/60f;
        }


        if(timerpower<0)
            aredod = true;

        

        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,mittengubbarrod,Color.Red);
        }

        
        
    }
}