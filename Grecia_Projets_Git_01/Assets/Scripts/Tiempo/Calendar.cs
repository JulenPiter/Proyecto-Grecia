using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    

    [Range(1, 366)]
    //public int Dias = 1;

    public int dia = 1;
    public string mes = "Enero";
    public int año = 500;

    public void SumarDia()
    {
      
        Globals.Dias++;
    }

    
    void Update()
    {


        if (Globals.Dias > 0 && Globals.Dias <= 31)
        {
            mes = "Enero";
            dia = Globals.Dias;
        }
        else if (Globals.Dias > 31 && Globals.Dias <= 59)
        {
            mes = "Febrero";
            dia = Globals.Dias - 31;
        }

        else if (Globals.Dias > 59 && Globals.Dias <= 90)
        {
            mes = "Marzo";
            dia = Globals.Dias - 59;
        }

        else if (Globals.Dias > 90 && Globals.Dias <= 120)
        {
            mes = "Abril";
            dia = Globals.Dias - 90;
        }

        else if (Globals.Dias > 120 && Globals.Dias <= 151)
        {
            mes = "Mayo";
            dia = Globals.Dias - 120;
        }

        else if (Globals.Dias > 151 && Globals.Dias <= 181)
        {
            mes = "Junio";
            dia = Globals.Dias - 151;
        }

        else if (Globals.Dias > 181 && Globals.Dias <= 212)
        {
            mes = "Julio";
            dia = Globals.Dias - 181;
        }

        else if (Globals.Dias > 212 && Globals.Dias <= 243)
        {
            mes = "Agosto";
            dia = Globals.Dias - 212;
        }

        else if (Globals.Dias > 243 && Globals.Dias <= 273)
        {
            mes = "Septiembre";
            dia = Globals.Dias - 243;
        }

        else if (Globals.Dias > 273 && Globals.Dias <= 304)
        {
            mes = "Octubre";
            dia = Globals.Dias - 273;
        }

        else if (Globals.Dias > 304 && Globals.Dias <= 334)
        {
            mes = "Noviembre";
            dia = Globals.Dias - 304;
        }

        else if (Globals.Dias > 334 && Globals.Dias <= 365)
        {
            mes = "Diciembre";
            dia = Globals.Dias - 334;
        }

        else if (Globals.Dias == 366)
        {
            año--;
            Globals.Dias = 1;
        }



    }

}
