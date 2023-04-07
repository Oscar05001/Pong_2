using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_2
{
    public class Powerup
    {
 
        Texture2D coin;
        Texture2D pixel;
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





    public Powerup(Texture2D coin,Texture2D pixel){
        power = new Rectangle(500, 500,45,45);

        this.pixel = pixel;
        this.coin = coin;
    
    
    }

    public void Update(){
        
        if(SettingScreen.settingwindoon==false)
        timerpower -= 1f/60f;
        
        //power up
        if(ompower==1){
            timerpower = (float)rnd.Next(5,10);
            powerx = rnd.Next(50,Game1.WINDOW_WHITE-100);
            powery = rnd.Next(0,Game1.WINDOW_HEIGHT-Power.Height);
            ompower = 0;
        
        }

        if(SettingScreen.settingwindoon==false){
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


        RemovMiten();
        RemovRod();
        if(Game1.mittengubbar.Count==0&&Game1.mittengubbarrod.Count==0)
            SettingScreen.clearmid = false;

    }

    
        


        //Lp=0 Rp=1
    public static void Powerupsen(int vem,Texture2D pixel)
    {
        



        Random vilken = new Random();
        int num = vilken.Next(0,101);
        if(num>=0&&num<=100)
            Speed(vem,(float)vilken.Next(20,30));
        if(num>=210&&num<=400)
            SpawnMiten(pixel);
        if(num>=1000&&num<=2000)
            SpawnRod(pixel);



        

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


    //mittengubbe

    public static void SpawnMiten(Texture2D pixel){    

        Random rnd = new Random();
        
        Game1.mittengubbar.Add(new Mittengubbe(pixel,(float)rnd.Next(10,30)));
    }

    public void RemovMiten(){
        
        for (int i = 0; i < Game1.mittengubbar.Count; i++)
        {
            
            if(Game1.mittengubbar[i].aredod || SettingScreen.clearmid==true)
            {
                Game1.mittengubbar.RemoveAt(i); 
                i--;

            }

            


        }

        


    }


    public static void SpawnRod(Texture2D pixel){    


        
        Random rnd = new Random();
        
        Game1.mittengubbarrod.Add(new Mittengubberod(pixel,(float)rnd.Next(5,20)));


    }

    public void RemovRod(){
        
        for (int i = 0; i < Game1.mittengubbarrod.Count; i++)
        {
            if(Game1.mittengubbarrod[i].aredod || SettingScreen.clearmid==true)
            {
                Game1.mittengubbarrod.RemoveAt(i); 
                i--;

            }


        }

    }





        public void Draw(SpriteBatch spriteBatch){
            
            spriteBatch.Draw(coin,power,Color.Yellow);
        }




    }
}