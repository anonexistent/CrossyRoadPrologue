using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult
{
    public string Date { get; set; }
    public string Result { get; set; }

    public GameResult(string date, string res)
    {
        Date = date;
        Result = res;
    }
}
