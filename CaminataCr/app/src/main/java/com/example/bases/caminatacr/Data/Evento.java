package com.example.bases.caminatacr.Data;

import android.graphics.Bitmap;

/**
 * Created by Alexis on 5/14/2017.
 */

public class Evento {
    public float latitud;
    public float longitud;
    public String comentario;
    public int numeroSecuencia;
    public Bitmap imagen;

    public Evento(float latitud, float longitud, String comentario, int numeroSecuencia, Bitmap imagen) {
        this.latitud = latitud;
        this.longitud = longitud;
        this.comentario = comentario;
        this.numeroSecuencia = numeroSecuencia;
        this.imagen = imagen;
    }
}
