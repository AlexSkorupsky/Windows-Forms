 using System;

namespace WindowsForms
{
    [Serializable]
    public class Segment
    {
        public string Color { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        
        public Segment() { }

        public Segment(int x1, int y1, int x2, int y2, string c)
        {
            Color = c;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }
}


