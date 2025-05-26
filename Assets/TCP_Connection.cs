using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

[System.Serializable]
public class LaserData
{
    public string laserType;
    public float x;
    public float y;
}

public class TCP_Connection : MonoBehaviour
{
    Thread thread;
    public int connectionPort = 25001;
    TcpListener server;
    TcpClient client;
    bool running;
    string signalType = "";
    readonly object dataLock = new object();

    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    void Connection()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if (!string.IsNullOrEmpty(dataReceived))
        {
            string parsedSignal = ParseData(dataReceived);

            lock (dataLock)
            {
                signalType = parsedSignal;
            }

            nwStream.Write(buffer, 0, bytesRead);
        }
    }


    // Use-case specific function, need to re-write this to interpret whatever data is being sent
    public static string ParseData(string dataString)
    {
        Debug.Log($"Received: {dataString}");

        try
        {
            LaserData data = JsonUtility.FromJson<LaserData>(dataString);
            return data.laserType;
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning("Failed to parse JSON: " + ex.Message);
            return "";
        }
    }


    // Position is the data being received in this example


    void Update()
    {
        string currentSignal;

        lock (dataLock)
        {
            currentSignal = signalType;
        }
        InputHandler.Instance.signaltype = currentSignal;

    }
}