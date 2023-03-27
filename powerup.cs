using System;
using System.Timers;


namespace Pong_2
{
    public class Powerup
    {
        

        //Lp=0 Rp=1
        public static void Powerupsen(int vem)
    {
        Random vilken = new Random();
        int num = vilken.Next(0,101);
        if(num>=0&&num<=50)
            Speed(vem);
        else if(num>=51&&num<=100)
        {
            Game1.SpawnMiten();

        }
            
        


    }
    


    private static void Speed(int vem)
    {
        Timer timer = new Timer(1000);
        Random vspeed = new Random();
        int hspeed = vspeed.Next(2,5);
        if(vem==0)
            Game1.padelspeedL += hspeed;
        
        if (vem==1)
            Game1.padelspeedR += hspeed;


    }

    

    


    }
}