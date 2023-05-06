using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong_2
{
    public class Startmenu
    {
        
        Rectangle meny;

        Texture2D pixel;
        SpriteFont menytext;
        MouseState mouse;
        MouseState oldmouse;
        MouseState oldmousetwo;


        public static int tillhurmånga{get;private set;} = 1;

        private float sendit;

        public float timegame{get;private set;}=0;
        private float sek=0;
        private float min=0;

        public static bool startmenyon{get;private set;} = true;

        private Rectangle startknapp = new Rectangle ((Game1.WINDOW_WHITE/2)-50,(Game1.WINDOW_HEIGHT/2)-50,100,50);
        
        private Rectangle plus = new Rectangle ((Game1.WINDOW_WHITE/2)-50,(Game1.WINDOW_HEIGHT/2)+45,25,25);
        private Rectangle minus = new Rectangle ((Game1.WINDOW_WHITE/2)+20,(Game1.WINDOW_HEIGHT/2)+45,25,25);
        


        public Rectangle Menyn{
                get{return meny;}
                set{meny = value;}
        }


        public Startmenu(Texture2D pixel,SpriteFont menytext){

            Random rnd = new Random();

            meny = new Rectangle((Game1.WINDOW_WHITE/2)-100,(Game1.WINDOW_HEIGHT/2)-100,200,200);
                
            this.pixel = pixel;
            this.menytext = menytext;
            
                
            
        }


        public void Update(){
            mouse = Mouse.GetState();


            if(!startmenyon)
                sek += 1f/60f;

            if(startknapp.Contains(mouse.Position) && (int)mouse.LeftButton==1){
                startmenyon = false;
                sek = 0;
                min = 0;
                MediaPlayer.Stop();
            }
            sendit -= 1f/60f;
           

            if(sek>=60){
                min ++;
                sek = 0;


            }




            //Ändra hur många man kör till
            if(plus.Contains(mouse.Position) && (int)mouse.LeftButton==1&&((int)oldmouse.LeftButton==0||sendit<=0)&&tillhurmånga<99){
                
                if((int)mouse.LeftButton==1&&(int)oldmouse.LeftButton==0)
                    sendit = 1;


                tillhurmånga ++;
                
            }

            oldmouse = mouse;



            if(minus.Contains(mouse.Position) && (int)mouse.LeftButton==1&&((int)oldmousetwo.LeftButton==0||sendit<=0)&&tillhurmånga>1){
                
                if((int)mouse.LeftButton==1&&(int)oldmousetwo.LeftButton==0)
                    sendit = 1;

                
                tillhurmånga --;
                
            }

            oldmousetwo = mouse;


            //


            if(Game1.poengL==tillhurmånga||Game1.poengR==tillhurmånga){
                startmenyon = true;


            }


        }


        public void Draw(SpriteBatch spriteBatch){



            if(startmenyon){
            spriteBatch.Draw(pixel,meny,Color.Wheat);
            spriteBatch.Draw(pixel,startknapp,Color.White);
            spriteBatch.Draw(pixel,plus,Color.White);
            spriteBatch.Draw(pixel,minus,Color.White);
            spriteBatch.DrawString(menytext,"Start", new Vector2 (startknapp.X+10 ,startknapp.Y+10), Color.Black);
            spriteBatch.DrawString(menytext,"Max point", new Vector2 (plus.X-15 ,plus.Y-38), Color.Black);
            spriteBatch.DrawString(menytext,"+", new Vector2 (plus.X+5 ,plus.Y-3), Color.Black);
            spriteBatch.DrawString(menytext,"-", new Vector2 (minus.X+9 ,minus.Y-6), Color.Black);


            if(tillhurmånga<=9)
                spriteBatch.DrawString(menytext,tillhurmånga.ToString(), new Vector2 (plus.X+41 ,plus.Y-2), Color.Black);
            else
                spriteBatch.DrawString(menytext,tillhurmånga.ToString(), new Vector2 (plus.X+32 ,plus.Y-2), Color.Black);



            }


            //Time game
            if(min<=10)
                spriteBatch.DrawString(menytext,"Min/Sek "+((int)min).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)-145,0), Color.White);
            else
                spriteBatch.DrawString(menytext,"Min/Sek"+((int)min).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)-155,0), Color.White);
            
            spriteBatch.DrawString(menytext,((int)sek).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)+8,0), Color.White);
            



        }
        




    }
}