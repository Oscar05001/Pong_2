using System;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Pong_2
{

    public class Bolarna
    {

        Texture2D pixel;
        Rectangle bollarna;
        private SaveandLode settings;
        private const string PATH = "setting.json";


        public Rectangle Bollarna{
                get{return bollarna;}
                set{bollarna = value;}
            }
        

        public static int bolspeedX = 4;
        public static int bolspeedY = 4;
            
        Random rnd = new Random();


        public Bolarna(Texture2D pixel){
                
            bollarna = new Rectangle(100,10,15,100);
                
            this.pixel = pixel;
            
                
            
            }



        public void Update(){






        }




        

        public void LoadContent(){
            settings = Load();
        }

            

        private SaveandLode Load()
        {
            var fileconten = File.ReadAllText(PATH);
            
            return JsonSerializer.Deserialize<SaveandLode>(fileconten);

        
        }




        public void Draw(SpriteBatch spriteBatch){



        }




    }
}