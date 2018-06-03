using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace WindowsForms
{
    class Serialization
    {  
    public static void Serialize(string filename, List<Segment> lines)
    {
       
        XmlSerializer formatter = new XmlSerializer(typeof(List<Segment>));

        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            formatter.Serialize(fs, lines);
        }
    }

    public static List<Segment> Deserialize(string filename)
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Segment>));
        var lines = new List<Segment>();
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            lines = (List<Segment>)formatter.Deserialize(fs);
        }
        return lines;
            

        
    }

}
}
