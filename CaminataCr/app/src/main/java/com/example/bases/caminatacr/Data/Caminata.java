package com.example.bases.caminatacr.Data;

import android.graphics.Bitmap;

import java.util.ArrayList;
import java.util.Date;

/**
 * Created by Alexis on 5/14/2017.
 */

public class Caminata {
    public String direccion;
    public Date fecha;
    public Bitmap imagen;
    public int nivelDificultad;
    public float latitud;
    public float longitud;
    public ArrayList<Evento> eventos ;

    public Caminata(String direccion,Bitmap imagen) {
        this.direccion = direccion;
        this.imagen = imagen;
    }

    public Caminata(String direccion, Date fecha, Bitmap imagen, int nivelDificultad, float latitud, float longitud) {
        this.direccion = direccion;
        this.fecha = fecha;
        this.imagen = imagen;
        this.nivelDificultad = nivelDificultad;
        this.latitud = latitud;
        this.longitud = longitud;
        eventos = new ArrayList<Evento>();
    }
}
