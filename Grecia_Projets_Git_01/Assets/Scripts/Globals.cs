using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    private static int dinero = 10000;

    [Range(1, 366)]
    private static int dias = 1;

    public static int Dinero
    {
        get
        {
            return dinero;
        }

        set
        {
            dinero = value;
        }
    }

    public static int Dias
    {
        get
        {
            return dias;
        }

        set
        {
            dias = value;
        }
    }
}
