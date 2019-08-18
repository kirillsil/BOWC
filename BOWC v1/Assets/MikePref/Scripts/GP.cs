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
         new int [] { //---------------- продажи ------------------
            1,  7000, 0,  0,   0,
            2,  9000, 21000,  120,   2,
            3,  15000, 29000,  180,    2,
            4,  20000, 44000,  240,   2,
            5,  30000, 67000,  340,  3,
            6,  45000, 80000, 470,  3,
            7,  70000,    110000,660,3,
            8,  100000,140000,9000,4,
            9,  250000,220000,1800,6,
            10,  500000,300000,3300,6
         },
         new int [] { //---------------- кадры ------------------
            1,  2, 0,  0,   0,
            2,  4, 21000,  120,   2,
            3,  10, 29000,  180,    2,
            4,  15, 44000,  240,   2,
            5,  22, 67000,  340,  3,
            6,  30, 80000, 470,  3,
            7,  36,    110000,660,3,
            8,  40,140000,9000,4,
            9,  45,220000,1800,6,
            10,  50,300000,3300,6
        },
         new int [] { //---------------- accouting ------------------
            1,  40, 0,  0,   0,
            2,  60, 21000,  900,   0,
            3,  90, 80000,  1800,    0,
            4,  150, 120000,  7200,   0,
            5,  250, 200000,  18000,  0,
            6,  600, 300000, 28800,  0,
            7,  1200, 500000,43200, 0,
            8,  2000,   800000,54000,  0,
            9,  3000,   1000000,72000, 0,
            10, 5000,  1400000,180000,   0
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

    public static string [] unitTypeName ={
        "Sales manager",
        "Asset manager",
        "Lawyer",
        "Analyst",
        "PR manager",
        "Security" };

    public static string [] unitTypeDesc ={
        "Sales management is a business discipline which is focused on the practical application of sales techniques and the management of a firm's sales operations.",
        "Asset managers are responsible for the management, procurement, valuation, and disposition of a company's property, data, and documents. These assets may include anything from property to computers to cell phones.",
        "A lawyer gives legal advice to people, government agencies, and businesses and offer representation to them when needed. They prepare legal documents and interpret laws, regulations, and rulings.",
        "A business analyst is someone who analyzes an organization or business domain (real or hypothetical) and documents its business or processes or systems, assessing the business model or its integration with technology",
        "Public Relations Manager develops and implements policies and procedures for the public relations department. Prepares and distributes news releases, fact sheets, scripts, etc. to media outlets.",
        "A security guard (also known as a security inspector or protective agent) is a person employed by a government or private party to protect the employing partys assets (property, people, equipment, money, etc.)" };

    public static int [] [] hire =  // параметры по найму юнитов - цена и время(сек)
    {
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------
        new int [] {50000,  600 },//---------------- продажный менеджер ------------------

    };

    public static int [][] unitAttackDefend=
    {
        new int [] { //sales 
            57,38,
            39,25,
            24,13 },
        new int [] { //asset 
            10,10,
            60,32,
            20,15 },
        new int [] { //lawer 
            57,16,
            33,13,
            99,25 },
        new int [] { //analist 
            12,59,
            7,32,
            5,20 },
        new int [] { //pr 
            9,33,
            21,91,
            15,60 },
        new int [] { //security
            21,37,
            15,27,
            24,60 }
    };
}
