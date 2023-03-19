using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_2
{
    public class Padel
    {
        Texture2D pixel;
        KeyboardState oldState;
        Keys up;
        Keys down;
        Keys toggle;

        Rectangle padel;
        int ySpeed = 5;
        public static int bolvar;

        public bool ai = false;


        public int Speed{
            set{ySpeed=value;}
        }

        public Rectangle Paddle{
            get{return padel;}
            set{padel = value;}
        }
        
        public Padel( Texture2D pixel, int x, int speed, Keys up, Keys down,Keys toggle, bool ai = false){
            padel = new Rectangle(x, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);
            this.ySpeed = speed;
            this.up = up;
            this.down = down;
            this.pixel = pixel;
            this.ai = ai;
            this.toggle = toggle;
        }

        public void Update(){
            KeyboardState kstate = Keyboard.GetState();
            if(!ai){

                HumanController(kstate);
            }
            else{
                AIController();
            }
            if(oldState.IsKeyUp(toggle) && kstate.IsKeyDown(toggle))
                ai = !ai;

            oldState = kstate;
        }

        private void AIController(){
            //Dator

                

                if(Game1.bolspeedX>0&&Game1.bol.X>Game1.WINDOW_WHITE/2){
                    bolvar = Game1.bol.Y;
                }
                else{
                    bolvar = Game1.WINDOW_HEIGHT/2;

                }


                if(bolvar >= Paddle.Y+50 && Paddle.Y <= Game1.WINDOW_HEIGHT-100 && Game1.bol.X >= Game1.WINDOW_WHITE/2)
                    ChangeY(Game1.padelspeedR);

                if(bolvar <= Paddle.Y+50 && Paddle.Y >=0 && Game1.bol.X >= Game1.WINDOW_WHITE/2)
                    ChangeY(-Game1.padelspeedR);
        }






        private void HumanController(KeyboardState kstate)
        {
                if  (kstate.IsKeyDown(up) && padel.Y >= 0)
                    padel.Y-= Game1.padelspeedL;
                if  (kstate.IsKeyDown(down) && padel.Y <= Game1.WINDOW_HEIGHT-100)
                    padel.Y+=Game1.padelspeedL;
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(pixel,padel,Color.White);
        }

        public void ChangeY(int value){
            padel.Y += value;
        }

        
    }
}