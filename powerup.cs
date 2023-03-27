using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pong_2
{
    public class Powerup
    {

        Texture2D coin;
        Rectangle power;

        public Rectangle Power{
            get{return power;}
            set{power = value;}
        }
        



        int powerx;
        int powery;
        int speedx = 1;
        int speedy = 1;


        public static int ompower = 1;
        
        public static float timerpower;

        Random rnd = new Random();





    public Powerup(Texture2D coin){
        power = new Rectangle(500, 500,45,45);


        this.coin = coin;
    
    
    }

    public void Update(){
        
        timerpower -= 1f/60f;
        
        //power up
        if(ompower==1){
            timerpower = (float)rnd.Next(5,10);
            powerx = rnd.Next(50,Game1.WINDOW_WHITE-100);
            powery = rnd.Next(0,Game1.WINDOW_HEIGHT-Power.Height);
            ompower = 0;
        
        }

        if(timerpower>0.2){
            power.Y=Game1.WINDOW_HEIGHT+50;
            power.X=powerx;


        }
        else if (timerpower<0.2&&timerpower>0){
            power.Y=powery;
            power.X=powerx;


        }
        else{

            
            power.Y += speedy;
            power.X += speedx;

        }



        //Kör Y

        if (power.Y <= 0 ){
            speedy *= -1;
        }

        if ( power.Y+power.Height >= Game1.WINDOW_HEIGHT ){
            speedy *= -1;
        }
        
        //Kör X

        if (power.X <= 100 ){
            speedx *= -1;
        }

        if ( power.X+power.Height >= Game1.WINDOW_WHITE-100){
            speedx *= -1;
        }

        

    }

    
        


        //Lp=0 Rp=1
    public static void Powerupsen(int vem)
    {
        



        Random vilken = new Random();
        int num = vilken.Next(0,101);
        if(num>=0&&num<=100)
            Speed(vem,(float)vilken.Next(20,30));
        if(num>=210&&num<=400)
            Game1.SpawnMiten();
        if(num>=1000&&num<=2000)
            Game1.SpawnRod();



        

    }
    


    private static void Speed(int vem,float tid)
    {
        
        Random vspeed = new Random();
        int hspeed = vspeed.Next(6,10);
        if(vem==0)
            Game1.speedboostL = hspeed;
        
        if (vem==1)
            Game1.speedboostR = hspeed;

        while(tid>0)
        {
            tid -= 1f/60f;
        }
        if(vem==0)
            Game1.speedboostL = 0;
        
        if (vem==1)
            Game1.speedboostR = 0;

    }

        public void Draw(SpriteBatch spriteBatch){
            
            spriteBatch.Draw(coin,power,Color.Yellow);
        }




    }
}