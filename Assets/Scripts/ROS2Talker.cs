using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ROS2;
using ROS2.Utils;

public class ROS2Talker : MonoBehaviour
{

    private int cont = 0;
    private IPublisher<std_msgs.msg.String> chatter_pub;
    private INode node;

    void Start()
    {
        RCLdotnet.Init();
        node = RCLdotnet.CreateNode("talker");
        chatter_pub = node.CreatePublisher<std_msgs.msg.String>("chatter");
    }

    void Update()
    {
        if (RCLdotnet.Ok())
        {
            std_msgs.msg.String msg = new std_msgs.msg.String();
            msg.Data = "Hello World: " + cont++;
            chatter_pub.Publish(msg);
        }
        else
        {
            Debug.Log("Nothing happening by update");
        }
    }

    public void Button_Click()
    {
        if (RCLdotnet.Ok())
        {
            std_msgs.msg.String msg = new std_msgs.msg.String();
            msg.Data = "Hello World: " + cont++;
            chatter_pub.Publish(msg);
        }
        else
        {
            Debug.Log("Nothing happening by onclick");
        }
    }
}