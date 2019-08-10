using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game params


public class GP 
{
    public static double money = 500000; // initial

    // Departments Params
    public static int[][] departAmount =  // максимальное значение
    {
        new int [] { 300000, 400000 },  // сейф
        new int [] { 14000, 18000 }     // продажи
    };
    public static int[][] departPrice =
     {
        new int [] { 1000, 2000 },
        new int [] { 1000, 2000 }
    };
    public static int[][] departTime =
    {
        new int [] { 100, 10 },
        new int [] { 10, 10 }
    };
    public static int[][] upgrade =
    {
        new int [] { //---------------- сейф ------------------
            1,  500000, 0,  0,   0,
            2,  550000, 21000,  120,   0,//120
            3,  605000, 29000,  180,    0,
            4,  665000, 44000,  840,   0,
            5,  732000, 67000,  6000,  0,
            6,  800000, 80000, 28800,  0,
            7,  1000000,    110000,39600,0,
            8,  2000000,140000,54000,0,
            9,  5000000,220000,108000,0,
            10, 7000000,300000,200000,0
        },
         new int [] { //---------------- сейф ------------------
            1,  500000, 21000,  120,   0,
            2,  550000, 29000,  180,   0,
            3,  605000, 44000,  840,    0,
            4,  665000, 67000,  6000,   0,
            5,  732000, 80000,  28800,  0,
            6,  800000, 110000, 39600,  0,
            7,  1000000,    140000,54000,0,
            8,  2000000,220000,108000,0,
            9,  5000000,300000,200000,0
        }
     };
    public static string TimeString(float tim_)
    {
        int _t = (int)tim_;
        int _d = _t / 86400;
        _t = _t % 86400;
        int _h = _t / 3600;
        _t = _t % 3600;
        int _m = _t / 60;
        _t = _t % 60;
        int _s = _t % 60;
        string _r="";
        if (_d > 0) _r = _d.ToString() + "дней";
        if (_h > 0) _r += _h.ToString() + "час.";

        if (_m > 0) _r += _m.ToString() + "мин.";
        if (_s > 0) _r += _s.ToString() + "сек.";
        return _r;

    }
}
