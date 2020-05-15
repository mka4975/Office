using Npgsql;
using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts;

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

    public int BreakEveryXObject = 5;

    private const string ConnString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=pozyx";
    private List<TagObject> _tagObjects = new List<TagObject>();
    private List<TagObject> _sortedList = new List<TagObject>();
    private int _i;
    private bool _waitingForData = false;
    private DateTime _lastDateTime;

    private decimal _counter1;
    private decimal _x1;
    private decimal _y1;
    private decimal _counter2;
    private decimal _x2;
    private decimal _y2;
    private decimal _counter3;
    private decimal _x3;
    private decimal _y3;
    private decimal _counter4;
    private decimal _x4;
    private decimal _y4;
    private decimal _counter5;
    private decimal _x5;
    private decimal _y5;

    // Start is called before the first frame update
    void Start()
    {
        InitText();
        //await GetData("SELECT* FROM positions");
    }

    async void Update()
    {
        if (_i < _sortedList.Count - 1)
        {
            TagObject tagObject = _sortedList[_i];
            switch (tagObject.TagId)
            {
                case 26386 when _counter1 < BreakEveryXObject:
                    _x1 += tagObject.X;
                    _y1 += tagObject.Y;
                    _counter1++;
                    break;
                case 26386:
                    Tag26386.transform.position = new Vector3((float)_x1 / BreakEveryXObject, 8, (float)_y1 / BreakEveryXObject);
                    Text26386.GetComponent<TextMesh>().text =
                        "tagId: 26386" + "\nx: " + _x1 / BreakEveryXObject + "\ny: " + _y1 / BreakEveryXObject;
                    _counter1 = 0;
                    _x1 = 0;
                    _y1 = 0;
                    break;
                case 26474 when _counter2 < BreakEveryXObject:
                    _x2 += tagObject.X;
                    _y2 += tagObject.Y;
                    _counter2++;
                    break;
                case 26474:
                    Tag26474.transform.position = new Vector3((float)_x2 / BreakEveryXObject, 8, (float)_y2 / BreakEveryXObject);
                    Text26474.GetComponent<TextMesh>().text =
                        "tagId: 26474" + "\nx: " + _x2 / BreakEveryXObject + "\ny: " + _y2 / BreakEveryXObject;
                    _counter2 = 0;
                    _x2 = 0;
                    _y2 = 0;
                    break;
                case 26449 when _counter3 < BreakEveryXObject:
                    _x3 += tagObject.X;
                    _y3 += tagObject.Y;
                    _counter3++;
                    break;
                case 26449:
                    Tag26449.transform.position = new Vector3((float)_x3 / BreakEveryXObject, 8, (float)_y3 / BreakEveryXObject);
                    Text26449.GetComponent<TextMesh>().text =
                        "tagId: 26449" + "\nx: " + _x3 / BreakEveryXObject + "\ny: " + _y3 / BreakEveryXObject;
                   _counter3 = 0;
                    _x3 = 0;
                    _y3 = 0;
                    break;
                case 26417 when _counter4 < BreakEveryXObject:
                    _x4 += tagObject.X;
                    _y4 += tagObject.Y;
                    _counter4++;
                    break;
                case 26417:
                    Tag26417.transform.position = new Vector3((float)_x4 / BreakEveryXObject, 8, (float)_y4 / BreakEveryXObject);
                    Text26417.GetComponent<TextMesh>().text =
                        "tagId: 26449" + "\nx: " + _x4 / BreakEveryXObject + "\ny: " + _y4 / BreakEveryXObject;
                    _counter2 = 0;
                    _x4 = 0;
                    _y4 = 0;
                    break;
                case 26468 when _counter5 < BreakEveryXObject:
                    _x5 += tagObject.X;
                    _y5 += tagObject.Y;
                    _counter5++;
                    break;
                case 26468:
                    Tag26468.transform.position = new Vector3((float)_x5 / BreakEveryXObject, 8, (float)_y5 / BreakEveryXObject);
                    Text26468.GetComponent<TextMesh>().text =
                        "tagId: 26468" + "\nx: " + _x5 / BreakEveryXObject + "\ny: " + _y5 / BreakEveryXObject;
                    _x5 = 0;
                    _y5 = 0;
                    break;
            }
            _i += 1;
            _lastDateTime = tagObject.Datetime;
        }
        else
        {
            _waitingForData = true;
            Debug.Log("Waiting for new Data");
        }

        //if (_waitingForData)
        //{
        //    await GetData("SELECT * FROM positions WHERE time >" + _lastDateTime);
        //}

    }

    /*
     * Unity calculates in cm Pozyx in mm therefor every value has to be divided by 100
     * the x-origin of the Pozyx is not the same as in Unity 
     */
    private void InitText()
    {
        Text26386.GetComponent<TextMesh>().text = "tagId: 26386" + "\nNot Connected";
        Text26474.GetComponent<TextMesh>().text = "tagId: 26474" + "\nNot Connected";
        Text26449.GetComponent<TextMesh>().text = "tagId: 26449" + "\nNot Connected";
        Text26417.GetComponent<TextMesh>().text = "tagId: 26417" + "\nNot Connected";
        Text26468.GetComponent<TextMesh>().text = "tagId: 26468" + "\nNot Connected";
    }

    private async Task GetData(String argquery)
    {
        var query = argquery;

        using (NpgsqlConnection connection = new NpgsqlConnection(ConnString))
        {
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                await connection.OpenAsync();
                command.CommandTimeout = 1000;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        bool _correct = !((int)reader.GetDecimal(2) == 0);

                        if (_correct)
                        {
                            TagObject o = new TagObject();
                            o.TagId = reader.GetInt64(0);
                            o.Datetime = reader.GetDateTime(1);
                            o.X = reader.GetDecimal(2) / 100 + 6;
                            o.Y = reader.GetDecimal(3) / 100;
                            _tagObjects.Add(o);
                        }
                    }
                }
            }
        }

        _sortedList = _tagObjects.OrderBy(o => o.Datetime).ToList();
        Debug.Log("There are: " + _sortedList.Count + " Objects in the List.");
    }
}

