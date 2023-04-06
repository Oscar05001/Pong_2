namespace Pong_2
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;
    public class SaveandLode
    {
        
        public  int Scren_WHITE { get; set; }
        public  int Scren_HEIGHT { get; set; }
        public  double Paddelspeedboost {get; set;}
        public  double MittenPaddelspeedboost {get; set;}
        public  double Bolspeedboost {get; set;}
        public  int PaddelLeftStartSpeed {get; set;}
        public  int PaddelRightStartSpeed {get; set;}
        public  int BolStartSpeed {get; set;}
        public  int PaddelMittenStartSpeed {get; set;}

    }
}