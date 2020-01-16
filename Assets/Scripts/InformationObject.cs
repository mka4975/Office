using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class InformationObject
    {
        //JObject jObject = null;
        //public InformationObject()
        //{

            
        //}

        //public InformationObject(string json)
        //{
        //    if (json != null && json.Length > 1)
        //    {
        //        jObject = JObject.Parse(json);
        //        TagId = (int)jObject["tagId"];
        //        DateTime = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        //        DateTime = DateTime.AddSeconds((double)jObject["timestamp"]);

        //        JToken data = jObject["data"];

        //        if (data != null)
        //        {
        //            JToken coordinates = data["coordinates"];
        //            X = (int)coordinates["x"];
        //            Y = (int)coordinates["y"];
        //            Z = (int)coordinates["z"];

        //            JToken orientation = data["orientation"];
        //            Yaw = (double)orientation["yaw"];
        //            Roll = (double)orientation["roll"];
        //            Pitch = (double)orientation["pitch"];

        //            JToken metrics = data["metrics"];
        //            Latency = (double)metrics["latency"];
        //        }
        //    }
        //}

        //public InformationObject(int id, DateTime dateTime, int x, int y, int z, double yaw, double roll, double pitch, double latency)
        //{
        //    TagId = id;
        //    DateTime = dateTime;
        //    X = x;
        //    Y = y;
        //    Z = z;
        //    Yaw = yaw;
        //    Roll = roll;
        //    Pitch = pitch;
        //    Latency = latency;
        //}

        //public int TagId { get; set; }
        //public DateTime DateTime { get; set; }
        //public int X { get; set; }
        //public int Y { get; set; }
        //public int Z { get; set; }
        //public double Yaw { get; set; }
        //public double Roll { get; set; }
        //public double Pitch { get; set; }
        //public double Latency { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder stb = new StringBuilder();
        //    stb.Append("InformationObject:\nId: " + TagId);
        //    stb.Append("\nDateTime: " + DateTime);
        //    stb.Append("\nX: " + X);
        //    stb.Append("\nY: " + Y);
        //    stb.Append("\nZ: " + Z);
        //    stb.Append("\nYaw: " + Yaw);
        //    stb.Append("\nRoll: " + Roll);
        //    stb.Append("\nPitch: " + Pitch);
        //    stb.Append("\nLatency: " + Latency);

        //    return stb.ToString();
        //}
    }
}

