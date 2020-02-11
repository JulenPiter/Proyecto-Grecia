using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoRecurso
{
    Pobre,
    Medio,
    Rico,
}

[CreateAssetMenu(fileName = "Recurso Nuevo",menuName ="Ciudad/Recursos")]
public class Recurso : ScriptableObject
{
    public string Nombre;

    public Sprite Icono;

    public int Cantidad;
    public int Precio;
    public int PrecioVenta;
    public int PrecioAnterior;


    public int PrecioTramoBajo;
    public int PrecioTramoAlto;

    public TipoRecurso tipoRecurso;

    public float a;
    public float b;


}


