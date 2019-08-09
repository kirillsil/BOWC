using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game params


public class GP 
{
    public static double money = 300000; // initial

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
            1,  500000, 21000,  120,   0,
            2,  550000, 29000,  180,   0,
            3,  
            
            
            
            
            100, 10 },
        new int [] { 10, 10 }
    };
}
