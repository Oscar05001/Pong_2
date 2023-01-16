using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong_2
{
    public class Padel
    {

        Keys up;
        Keys down;

        public Rectangle padel;
        int ySpeed = 5;

        public int Speed{
            set{ySpeed=value;}
        }
        
        public Padel(int x, int speed, Keys up, Keys down){
            padel = new Rectangle(x, (int)(Game1.WINDOW_HEIGHT*0.5)-50,15,100);
            ySpeed = speed;
            this.up = up;
            this.down = down;
        }

        public void Update(){
            KeyboardState kstate = Keyboard.GetState();
            if  (kstate.IsKeyDown(up) && padel.Y >= 0)
                padel.Y-= ySpeed;
            if  (kstate.IsKeyDown(down) && padel.Y <= Game1.WINDOW_HEIGHT-100)
                padel.Y+=ySpeed;
        }



    }
}