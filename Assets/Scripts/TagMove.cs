using Npgsql;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagMove : MonoBehaviour
{
    public new GameObject tag = null;

    string connString = "Host=localhost;Username=postgres;Password=postgres;Database=pozyx";


    // Start is called before the first frame update
    void Start()
    {
        using NpgsqlConnection connection = new NpgsqlConnection(connString);
        string query = "SELECT* FROM positions";

        using NpgsqlCommand command = new NpgsqlCommand(query, connection);

        connection.Open();
        NpgsqlDataReader dr = command.ExecuteReader();
        if (dr != null)
        {
            Debug.Log(dr[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
