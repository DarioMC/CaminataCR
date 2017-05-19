package com.example.bases.caminatacr.Connection;

import android.os.AsyncTask;
import android.util.Log;

import java.sql.CallableStatement;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Types;

/**
 * Created by Alexis on 5/14/2017.
 */

public class SQLConnection extends AsyncTask{
    private String reader ="";
    protected ResultSet resultSet ;
    protected java.sql.Connection SqlConnection;
    private String username = "Dario";
    private String password = "0000";
    public int openConnectionWithReturnProcedure(String procedure,String ip)throws Exception{
            Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
            SqlConnection = DriverManager.getConnection("jdbc:jtds:sqlserver://"+ip+"/Caminata;user=" + username + ";password=" + password);
            Log.w("SQLConnection","open");
            //Statement stmt = SqlConnection.createStatement();
            // ResultSet reset = stmt.executeQuery(procedure);

        return  0;
    }
    public void finishConnection() throws SQLException {
        SqlConnection.close();
    }

    public String getReader() {
        return reader;
    }

    public void setReader(String reader) {
        this.reader = reader;
    }


    @Override
    protected Object doInBackground(Object[] params) {
        return null;
    }
}
