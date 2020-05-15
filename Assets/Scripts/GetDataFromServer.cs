using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assets.Scripts;
using UnityEngine;

public class GetDataFromServer : MonoBehaviour
{
    const int PORT_NO = 5000;
    const string SERVER_IP = "127.0.0.1";

    private float nextActionTime = 0.0f;
    public float period = 10f;

    public List<TagObject> Objects = new List<TagObject>();

    private EventManager eventManager;
    // Start is called before the first frame update
    async Task Start()
    {
        await GetData();
        //eventManager = EventManager.instance;
        //eventManager.TriggerEvent("Collecting Data done");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time > nextActionTime)
        //{
        //    nextActionTime += period;
        //    await GetData();
        //}
    }

    private async Task GetData()
    {
        try
        {
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);

            NetworkStream stream = client.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("");
            stream.Write(data, 0, data.Length);

            data = new byte[256];

            string responseData = String.Empty;

            bool newDataAvailable = true;
            while (newDataAvailable)
            {
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                TagObject tagobject = JsonSerializer.Deserialize<TagObject>(responseData);
                print(tagobject);

                //if (responseData == "end")
                //{
                //    newDataAvailable = false;
                //}
                Objects.Add(tagobject);
            }
            stream.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
