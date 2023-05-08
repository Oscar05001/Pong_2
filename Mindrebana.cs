using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Pong_2
{
    public class Mindrebana
    {

        Texture2D pixel;


        public static int ARENA_ROOF{get; private set;} = 0;

        public static int ARENA_FLORE{get; private set;} = Game1.WINDOW_HEIGHT;
        
        public static int ARENA_LEFT_WALL{get; private set;} = 0;
        
        public static int ARENA_RIGHT_WALL{get; private set;} = Game1.WINDOW_WHITE;

        public static float tidarena{get; private set;} 

        private static float saktaner;

        public static int BörRoof{get; private set;} = ARENA_ROOF;
        public static int BörFlore{get; private set;} = ARENA_FLORE;
        public static int BörLeft{get; private set;} = ARENA_LEFT_WALL;
        public static int BörRight{get; private set;} = ARENA_RIGHT_WALL;

        

        private static Random rnd = new Random();


        Rectangle linjeuppe = new Rectangle(ARENA_FLORE,10,10,10);
        Rectangle linjenere = new Rectangle(ARENA_FLORE,10,10,10);
        Rectangle linjehöger = new Rectangle(10,ARENA_RIGHT_WALL,10,10);
        Rectangle linjevänster = new Rectangle(10,ARENA_RIGHT_WALL,10,10);


        public Mindrebana(Texture2D pixel){

            this.pixel = pixel;


        }


        public void Update(){

            
            saktaner -= 1f/60f;

            linjeuppe.X = ARENA_LEFT_WALL-linjevänster.Width;
            linjeuppe.Y = ARENA_ROOF-linjeuppe.Height;
            linjeuppe.Width = ARENA_RIGHT_WALL-ARENA_LEFT_WALL+(linjehöger.Width*3);

            linjenere.X = ARENA_LEFT_WALL-linjevänster.Width;
            linjenere.Y = ARENA_FLORE;
            linjenere.Width = ARENA_RIGHT_WALL-ARENA_LEFT_WALL+(linjehöger.Width*2);

            linjehöger.X = ARENA_RIGHT_WALL+linjehöger.Width;
            linjehöger.Y = ARENA_ROOF;
            linjehöger.Height = ARENA_FLORE-ARENA_ROOF+linjenere.Height;

            linjevänster.X = ARENA_LEFT_WALL-linjevänster.Width;
            linjevänster.Y = ARENA_ROOF-linjeuppe.Height;
            linjevänster.Height = ARENA_FLORE-ARENA_ROOF+(linjenere.Height*2);

            if(tidarena<0){
                BörFlore = Game1.WINDOW_HEIGHT;
                BörRoof = 0;
                BörRight = Game1.WINDOW_WHITE;
                BörLeft = 0;
            }

            if(!Startmenu.startmenyon&&!SettingScreen.settingwindoon){
                Change();
                tidarena -= 1f/60f;
            }
        }


        public static void Storlek(){

            tidarena =  (float)rnd.Next(20,40);
            float prosent = rnd.Next(50,90)*0.01f;
            
            BörRoof = (int)((Game1.WINDOW_HEIGHT/2)-((Game1.WINDOW_HEIGHT/2)*prosent));
            BörFlore = (int)((Game1.WINDOW_HEIGHT/2)+((Game1.WINDOW_HEIGHT/2)*prosent));

            BörLeft = (int)((Game1.WINDOW_WHITE/2)-((Game1.WINDOW_WHITE/2)*prosent)) ;
            BörRight = (int)((Game1.WINDOW_WHITE/2)+((Game1.WINDOW_WHITE/2)*prosent));


        }

        private void Change(){

            if(saktaner<=0){
                if(ARENA_ROOF<BörRoof){
                    ARENA_ROOF += 1;
                }
                else if(ARENA_ROOF>BörRoof){
                    ARENA_ROOF -= 1;
                }

                if(ARENA_FLORE<BörFlore){
                    ARENA_FLORE += 1;
                }
                else if(ARENA_FLORE>BörFlore){
                    ARENA_FLORE -= 1;
                }

                if(ARENA_RIGHT_WALL<BörRight){
                    ARENA_RIGHT_WALL += 1;
                }
                else if(ARENA_RIGHT_WALL>BörRight){
                    ARENA_RIGHT_WALL -= 1;
                }

                if(ARENA_LEFT_WALL<BörLeft){
                    ARENA_LEFT_WALL += 1;
                }
                else if(ARENA_LEFT_WALL>BörLeft){
                    ARENA_LEFT_WALL -= 1;
                }

                if(tidarena>0)
                    saktaner = 0.1f;
                else
                    saktaner = 0.02f;
            }

        }


        public static void Reset(){
            BörFlore = Game1.WINDOW_HEIGHT;
            BörRoof = 0;
            BörRight = Game1.WINDOW_WHITE;
            BörLeft = 0;
            
            tidarena = 0;

            ARENA_FLORE = Game1.WINDOW_HEIGHT;
            ARENA_ROOF = 0;
            ARENA_RIGHT_WALL = Game1.WINDOW_WHITE;
            ARENA_LEFT_WALL = 0;



        }



        public void Draw(SpriteBatch spriteBatch){

            spriteBatch.Draw(pixel,linjeuppe,Color.BlueViolet );
            spriteBatch.Draw(pixel,linjenere,Color.BlueViolet);
            spriteBatch.Draw(pixel,linjehöger,Color.BlueViolet);
            spriteBatch.Draw(pixel,linjevänster,Color.BlueViolet);


        }

        
    }
}