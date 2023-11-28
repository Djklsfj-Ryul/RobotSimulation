using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System;

public class SocketFloat : MonoBehaviour
{
    public string ip = "192.168.0.13";
    public int port = 4444;
    public Socket client;
    [SerializeField]
    private int[] dataOut, dataIn; //debugging

    public void Receive()
    {
        //initialize socket
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            client.Connect(ip, port);
        }
        catch (Exception)
        {
            Debug.Log("Connection Failed");
            throw;
        }
        /*
        //convert floats to bytes, send to port
        var byteArray = new byte[dataOut.Length];
        Buffer.BlockCopy(dataOut, 0, byteArray, 0, byteArray.Length);
        client.Send(byteArray);
        
        //allocate and receive bytes
        byte[] bytes = new byte[4000];
        int n = client.Receive(bytes);
        Debug.Log(Encoding.UTF8.GetString(bytes, 0, n));
        */
        //client.Close();
        Debug.Log("연결 완료");
    }
}