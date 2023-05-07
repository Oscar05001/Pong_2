using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Pong_2
{
    public class Powerup
    {
 
        

        Keys I = Keys.I;
        KeyboardState oldState;
        SoundEffect effect;
        Random rnd = new Random();



        private static float leftspeedboosttimer;
        private static float rightspeedboosttimer;
        private static float leftlengdtimer;
        private static float rightlengdtimer;
        private static float leftkorttimer;
        private static float rightkorttimer;


        private static int leftlengre;
        private static int rightlengre;
        private static int leftkort;
        private static int rightkort;


        public static int leftspeedboost {get; private set;}
        public static int rightspeedboost {get; private set;}
        public static int leftlengd {get; private set;}
        public static int rightlengd {get; private set;}
        
        private static bool info = false;

        private static float timerpower = 5;



        

        public Powerup(){

            

        }
    
        
        




    

    public void Update(){

        

        KeyboardState kstate = Keyboard.GetState();
        

        
        if(!SettingScreen.settingwindoon&&!Startmenu.startmenyon){
            //när den kommer fram
            timerpower -= 1f/60f;

            //speed boost tid
            leftspeedboosttimer -= 1f/60f;
            rightspeedboosttimer -= 1f/60f;

            //Längd förståring tid
            leftlengdtimer -= 1f/60f;
            rightlengdtimer -= 1f/60f;

            //Längd förminskning tid
            leftkorttimer -= 1f/60f;
            rightkorttimer -= 1f/60f;

        }

            //power up
            if(timerpower<0&&Game1.powerupfigur.Count<=4){
                
                timerpower = (float)rnd.Next(10,15);
                Game1.powerupfigur.Add(new Powerupfigur());
            
            }
        
        


            leftlengd = 100;
            leftlengd += leftlengre;
            leftlengd -= leftkort;

            rightlengd = 100; 
            rightlengd += rightlengre;
            rightlengd -= rightkort;

            PaddelLeft.hurstor = leftlengd;
            PaddelRight.hurstor = rightlengd;

            //Reset efter tid är slut
            if(leftspeedboosttimer <= 0)
            {
                leftspeedboost = 0;
            }
            
            if(rightspeedboosttimer <= 0)
            {
                rightspeedboost = 0;
            }

            //Reset lång till 0 när tid slut
            if(leftlengdtimer <= 0)
            {
               leftlengre = 0; 
            }
            
            if(rightlengdtimer <= 0)
            {
                rightlengre = 0;
            }

            //Reset kort till 0 nä tid slut
            if(leftkorttimer <= 0)
            {
               leftkort = 0; 
            }
            
            if(rightkorttimer <= 0)
            {
                rightkort= 0;
            }
            

        

        if(oldState.IsKeyUp(I) && kstate.IsKeyDown(I)){
            info = !info;
        
        }

        oldState = kstate;



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
        if(num>=0&&num<=20)
            Speed(vem);
        if(num>=20&&num<=40)
            Lengre(vem);
        if(num>=41&&num<=50)
            Kortare(vem);
        if(num>=51&&num<=80)
            SpawnVeg(pixel,vem);
        if(num>=81&&num<=90)
            SpawnMiten(pixel);
        if(num>=90&&num<=100)
            SpawnRod(pixel);



       

    }
    


    private static void Speed(int vem)
    {
        
        Random vspeed = new Random();
        float tid = (float)vspeed.Next(10,30);
        int hspeed = vspeed.Next(6,10);
        if(vem==0){
            leftspeedboost = hspeed;
            leftspeedboosttimer = tid;
        }
        if (vem==1){
            rightspeedboost = hspeed;
            rightspeedboosttimer = tid;
        }

    }

    private static void Lengre(int vem)
    {
        
        Random rnd = new Random();
        float tid = (float)rnd.Next(10,30);
        int lengd = rnd.Next(100,201);
        if(vem==0){
            leftlengre = lengd;
            leftlengdtimer = tid;
        }
        if (vem==1){
            rightlengre = lengd;
            rightlengdtimer = tid;
        }

        

    }

    private static void Kortare(int vem)
    {
        
        Random rnd = new Random();
        float tid = (float)rnd.Next(5,15);
        int lengd = rnd.Next(20,70);
        if(vem==1){
            leftkort = lengd;
            leftkorttimer = tid;
        }
        if (vem==0){
            rightkort = lengd;
            rightkorttimer = tid;
        }

        

    }


    //mittengubbe

    public static void SpawnMiten(Texture2D pixel){    
        

        if(Game1.mittengubbar.Count<=100){
            Random rnd = new Random();
            Game1.mittengubbar.Add(new Mittengubbe(pixel,(float)rnd.Next(30,50),3));
        }
        
    }

    public static void SpawnVeg(Texture2D pixel,int vem){    


        if(Game1.mittengubbarrod.Count<=100){
            Random rnd = new Random();        
            Game1.mittengubbar.Add(new Mittengubbe(pixel,(float)rnd.Next(20,40),vem));
        }
        
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
        
        Game1.mittengubbarrod.Add(new Mittengubberod(pixel,(float)rnd.Next(15,30)));


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

    public static void ResetPowerup(){
        timerpower = 5;
        leftspeedboosttimer = 0;
        rightspeedboosttimer = 0;
        leftlengdtimer = 0;
        rightlengdtimer = 0;
        leftkorttimer = 0;
        rightkorttimer = 0;

        if(Game1.powerupfigur.Count>0){
            for (int i = Game1.powerupfigur.Count; i < 1; i--)
            {

                Game1.powerupfigur.RemoveAt(i);
                
            }
        }



    }





        public void Draw(SpriteBatch spriteBatch,SpriteFont font){
            
            

            if(info){
                spriteBatch.DrawString(font,"Kortare "+leftkort.ToString()+" tid "+((int)leftkorttimer).ToString(), new Vector2 (120,0), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Lengre "+leftlengre.ToString()+" tid "+((int)leftlengdtimer).ToString(), new Vector2 (120,25), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Speedboost "+leftspeedboost.ToString()+" tid "+((int)leftspeedboosttimer).ToString(), new Vector2 (120,50), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Hur manga bollar "+Game1.bolarna.Count.ToString(), new Vector2 (120,100), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Hur manga midrod "+Game1.mittengubbarrod.Count.ToString(), new Vector2 (120,125), Color.LightSkyBlue);

                spriteBatch.DrawString(font,"Kortare "+rightkort.ToString()+" tid "+((int)rightkorttimer).ToString(), new Vector2 (340,0), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Lengre "+rightlengre.ToString()+" tid "+((int)rightlengdtimer).ToString(), new Vector2 (340,25), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Speedboost "+rightspeedboost.ToString()+" tid "+((int)rightspeedboosttimer).ToString(), new Vector2 (340,50), Color.LightSkyBlue);
                spriteBatch.DrawString(font,"Hur manga midgul "+Game1.mittengubbar.Count.ToString(), new Vector2 (340,100), Color.LightSkyBlue);

                

                
            }
                
        }




    }
}