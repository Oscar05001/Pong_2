using System;
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

        private Rectangle startknapp = new Rectangle ((Mindrebana.ARENA_RIGHT_WALL/2)-50,(Mindrebana.ARENA_FLORE/2)-50,100,50);
        
        private Rectangle plus = new Rectangle ((Mindrebana.ARENA_RIGHT_WALL/2)-50,(Mindrebana.ARENA_FLORE/2)+45,25,25);
        private Rectangle minus = new Rectangle ((Mindrebana.ARENA_RIGHT_WALL/2)+20,(Mindrebana.ARENA_FLORE/2)+45,25,25);
        


        public Rectangle Menyn{
                get{return meny;}
                set{meny = value;}
        }


        public Startmenu(Texture2D pixel,SpriteFont menytext){

            Random rnd = new Random();

            meny = new Rectangle((Mindrebana.ARENA_RIGHT_WALL/2)-100,(Mindrebana.ARENA_FLORE/2)-100,200,200);
                
            this.pixel = pixel;
            this.menytext = menytext;
            
                
            
        }


        public void Update(){
            mouse = Mouse.GetState();


            if(!startmenyon&&!SettingScreen.settingwindoon)
                sek += 1f/60f;

            if(startknapp.Contains(mouse.Position) && (int)mouse.LeftButton==1&&startmenyon){
                startmenyon = false;
                sek = 0;
                min = 0;
                SettingScreen.clearmid = true;
                Powerup.ResetPowerup();
                Game1.Resetpoint();
                Mindrebana.Reset();
                MediaPlayer.Stop();
            }
            sendit -= 1f/60f;
           

            if(sek>=60){
                min ++;
                sek = 0;


            }




            //Ändra hur många man kör till
            if(plus.Contains(mouse.Position) && (int)mouse.LeftButton==1&&((int)oldmouse.LeftButton==0||sendit<=0)&&tillhurmånga<99&&startmenyon){
                
                if((int)mouse.LeftButton==1&&(int)oldmouse.LeftButton==0)
                    sendit = 1;


                tillhurmånga ++;
                
            }

            oldmouse = mouse;



            if(minus.Contains(mouse.Position) && (int)mouse.LeftButton==1&&((int)oldmousetwo.LeftButton==0||sendit<=0)&&tillhurmånga>1&&startmenyon){
                
                if((int)mouse.LeftButton==1&&(int)oldmousetwo.LeftButton==0)
                    sendit = 1;

                
                tillhurmånga --;
                
            }

            oldmousetwo = mouse;


            //


            if(Game1.poengL==tillhurmånga||Game1.poengR==tillhurmånga&&startmenyon==false){
                startmenyon = true;
                MediaPlayer.Stop();

            
                for (int i = 0; i < Game1.powerupfigur.Count; i++)
                {
                        Game1.powerupfigur.RemoveAt(i); 
                        i--;

                }


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

            spriteBatch.DrawString(menytext,"Min Sek ", new Vector2 ((Game1.WINDOW_WHITE/2)-55,0), Color.White);

            if(min<=10)
                spriteBatch.DrawString(menytext,((int)min).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)-20,30), Color.White);
            else
                spriteBatch.DrawString(menytext,((int)min).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)-45,30), Color.White);
            
            spriteBatch.DrawString(menytext,((int)sek).ToString(), new Vector2 ((Game1.WINDOW_WHITE/2)+7,30), Color.White);
            



        }
        




    }
}