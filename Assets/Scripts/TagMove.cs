using Npgsql;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System.Threading;

public class TagMove : MonoBehaviour
{
    public GameObject tag26386 = null;
    public GameObject text26386 = null;

    public GameObject tag26474 = null;
    public GameObject text26474 = null;

    public GameObject tag26449 = null;
    public GameObject text26449 = null;

    public GameObject tag26417 = null;
    public GameObject text26417 = null;

    public GameObject tag26468 = null;
    public GameObject text26468 = null;


    string connString = "Host=localhost;Username=postgres;Password=postgres;Database=pozyx";
    NpgsqlDataReader dr = null;

    void Connect()
    {
        InformationObject informationObject = new InformationObject();
        NpgsqlConnection connection = new NpgsqlConnection(connString);
        connection.Open();

        string query = "SELECT* FROM positions";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        dr = command.ExecuteReader();
        text26386.GetComponent<TextMesh>().text = "tagId: 26386" + "\nNot Connected";
        text26474.GetComponent<TextMesh>().text = "tagId: 26474" + "\nNot Connected";
        text26449.GetComponent<TextMesh>().text = "tagId: 26449" + "\nNot Connected";
        text26417.GetComponent<TextMesh>().text = "tagId: 26417" + "\nNot Connected";
        text26468.GetComponent<TextMesh>().text = "tagId: 26468" + "\nNot Connected";
    }

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        dr.Read();
        if (dr.GetInt32(2) == 0)
        {
            return;
        }

        int i1 = 0;
        int x1 = 0;
        int y1 = 0;
        int i2 = 0;
        int x2 = 0;
        int y2 = 0;
        int i3 = 0;
        int x3 = 0;
        int y3 = 0;
        int i4 = 0;
        int x4 = 0;
        int y4 = 0;
        int i5 = 0;
        int x5 = 0;
        int y5 = 0;

        if (dr.GetInt32(0) == 26386)
        {
            for (; i1 < 5; i1++)
            {
                x1 += dr.GetInt32(2) / 100 + 6;
                y1 += dr.GetInt32(3) / 100;
            }

            if (i1 == 5)
            {
                tag26386.transform.position = new Vector3(x1 / 5, 8, y1 / 5);
                text26386.GetComponent<TextMesh>().text = "tagId: 26386" + "\nx: " + x1 / 5 + "\ny: " + y1 / 5;
                i1 = 0;
            }

        }
        else if (dr.GetInt32(0) == 26474)
        {
            for (; i2 < 5; i2++)
            {
                x2 += dr.GetInt32(2) / 100 + 6;
                y2 += dr.GetInt32(3) / 100;
            }

            if (i2 == 5)
            {
                tag26474.transform.position = new Vector3(x2 / 5, 8, y2 / 5);
                text26474.GetComponent<TextMesh>().text = "tagId: 26474" + "\nx: " + x2 / 5 + "\ny: " + y2 / 5;
                i1 = 0;
            }
            tag26474.transform.position = new Vector3(dr.GetInt32(2) / 100 + 6, 8, dr.GetInt32(3) / 100);
            text26474.GetComponent<TextMesh>().text = "tagId: " + dr.GetInt32(0) + "\nx: " + dr.GetInt32(2) + "\ny: " + dr.GetInt32(3);
        }
        else if (dr.GetInt32(0) == 26449)
        {
            for (; i3 < 5; i3++)
            {
                x3 += dr.GetInt32(2) / 100 + 6;
                y3 += dr.GetInt32(3) / 100;
            }

            if (i3 == 5)
            {
                tag26449.transform.position = new Vector3(x3 / 5, 8, y3 / 5);
                text26449.GetComponent<TextMesh>().text = "tagId: 26386" + "\nx: " + x3 / 5 + "\ny: " + y3 / 5;
                i3 = 0;
            }
        }
        else if (dr.GetInt32(0) == 26417)
        {
            tag26417.transform.position = new Vector3(dr.GetInt32(2) / 100 + 6, 8, dr.GetInt32(3) / 100);
            text26417.GetComponent<TextMesh>().text = "tagId: " + dr.GetInt32(0) + "\nx: " + dr.GetInt32(2) + "\ny: " + dr.GetInt32(3);
        }
        else if (dr.GetInt32(0) == 26468)
        {
            tag26468.transform.position = new Vector3(dr.GetInt32(2) / 100 + 6, 8, dr.GetInt32(3) / 100);
            text26468.GetComponent<TextMesh>().text = "tagId: " + dr.GetInt32(0) + "\nx: " + dr.GetInt32(2) + "\ny: " + dr.GetInt32(3);
        }
        Thread.Sleep(10);
    }
}
