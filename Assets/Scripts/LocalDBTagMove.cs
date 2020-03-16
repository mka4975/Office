using Npgsql;
using UnityEngine;
using System.Threading;
using System;

public class LocalDBTagMove : MonoBehaviour
{
    public GameObject Tag26386 = null;
    public GameObject Text26386 = null;

    public GameObject Tag26474 = null;
    public GameObject Text26474 = null;

    public GameObject Tag26449 = null;
    public GameObject Text26449 = null;

    public GameObject Tag26417 = null;
    public GameObject Text26417 = null;

    public GameObject Tag26468 = null;
    public GameObject Text26468 = null;

    private int _counter1;
    private int _x1;
    private int _y1;
    private int _counter2;
    private int _x2;
    private int _y2;
    private int _counter3;
    private int _x3;
    private int _y3;
    private int _counter4;
    private int _x4;
    private int _y4;
    private int _counter5;
    private int _x5;
    private int _y5;

    private const string ConnString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=pozyx";
    private NpgsqlDataReader _dr;

    private void Connect()
    {
        var connection = new NpgsqlConnection(ConnString);
        connection.Open();

        const string query = "SELECT* FROM positions";
        var command = new NpgsqlCommand(query, connection);

        _dr = command.ExecuteReader();
        try
        {
            Text26386.GetComponent<TextMesh>().text = "tagId: 26386" + "\nNot Connected";
            Text26474.GetComponent<TextMesh>().text = "tagId: 26474" + "\nNot Connected";
            Text26449.GetComponent<TextMesh>().text = "tagId: 26449" + "\nNot Connected";
            Text26417.GetComponent<TextMesh>().text = "tagId: 26417" + "\nNot Connected";
            Text26468.GetComponent<TextMesh>().text = "tagId: 26468" + "\nNot Connected";
        }
        catch (Exception e)
        {
            print(e.Message);
        }
    }

    private void Init()
    {
        _counter1 = 0;
        _x1 = 0;
        _y1 = 0;

        _counter2 = 0;
        _x2 = 0;
        _y2 = 0;

        _counter3 = 0;
        _x3 = 0;
        _y3 = 0;

        _counter4 = 0;
        _x4 = 0;
        _y4 = 0;

        _counter5 = 0;
        _x5 = 0;
        _y5 = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            _dr.Read();
        }
        catch (Exception e)
        {
            print("No more Data");
            Debug.Log(e.Message);
            throw;
        }

        if (_dr.GetInt32(2) == 0)
        {
            return;
        }

        /*
         * for the positioning of the tags 5 values are used and normalized for better result
         * Unity calculates in cm Pozyx in mm therefor every value has to be divided by 100
         * the x-origin of the Pozyx is not the same as in Unity 
         */
        Init();
        if (_dr.GetInt32(0) == 26386)
        {
            for (; _counter1 < 5; _counter1++)
            {
                _x1 += _dr.GetInt32(2) / 100 + 6;   
                _y1 += _dr.GetInt32(3) / 100;
            }

            if (_counter1 == 5)
            {
                Tag26386.transform.position = new Vector3(_x1 / 5, 8, _y1 / 5);
                Text26386.GetComponent<TextMesh>().text = "tagId: 26386" + "\nx: " + _x1 / 5 + "\ny: " + _y1 / 5;
                _counter1 = 0;
            }

        }
        else if (_dr.GetInt32(0) == 26474)
        {
            for (; _counter2 < 5; _counter2++)
            {
                _x2 += _dr.GetInt32(2) / 100 + 6;
                _y2 += _dr.GetInt32(3) / 100;
            }

            if (_counter2 == 5)
            {
                Tag26474.transform.position = new Vector3(_x2 / 5, 8, _y2 / 5);
                Text26474.GetComponent<TextMesh>().text = "tagId: 26474" + "\nx: " + _x2 / 5 + "\ny: " + _y2 / 5;
                _counter2 = 0;
            }
        }
        else if (_dr.GetInt32(0) == 26449)
        {
            for (; _counter3 < 5; _counter3++)
            {
                _x3 += _dr.GetInt32(2) / 100 + 6;
                _y3 += _dr.GetInt32(3) / 100;
            }

            if (_counter3 == 5)
            {
                Tag26449.transform.position = new Vector3(_x3 / 5, 8, _y3 / 5);
                Text26449.GetComponent<TextMesh>().text = "tagId: 26449" + "\nx: " + _x3 / 5 + "\ny: " + _y3 / 5;
                _counter3 = 0;
            }
        }
        else if (_dr.GetInt32(0) == 26417)
        {
            for (; _counter4 < 5; _counter4++)
            {
                _x4 += _dr.GetInt32(2) / 100 + 6;
                _y4 += _dr.GetInt32(3) / 100;
            }

            if (_counter4 == 5)
            {
                Tag26417.transform.position = new Vector3(_x4 / 5, 8, _y4 / 5);
                Text26417.GetComponent<TextMesh>().text = "tagId: 26417" + "\nx: " + _x4 / 5 + "\ny: " + _y4 / 5;
                _counter4 = 0;
            }
        }
        else if (_dr.GetInt32(0) == 26468)
        {
            for (; _counter5 < 5; _counter5++)
            {
                _x5 += _dr.GetInt32(2) / 100 + 6;
                _y5 += _dr.GetInt32(3) / 100;
            }

            if (_counter4 == 5)
            {
                Tag26468.transform.position = new Vector3(_x5 / 5, 8, _y5 / 5);
                Text26468.GetComponent<TextMesh>().text = "tagId: 26468" + "\nx: " + _x5 / 5 + "\ny: " + _y5 / 5;
                _counter5 = 0;
            }
        }
        Thread.Sleep(1);
    }
}

