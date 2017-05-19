package com.example.bases.caminatacr.Connection;

import android.widget.Toast;

import com.example.bases.caminatacr.MainActivity;
import com.example.bases.caminatacr.Tabs.LoginActivity;
import com.example.bases.caminatacr.Tabs.RegisterActivity;

import java.sql.CallableStatement;
import java.sql.Types;

/**
 * Created by Alexis on 5/19/2017.
 */

public class LoginConnection extends SQLConnection{
    LoginActivity activity;
    String [] parameters;
    SpTypes type;
    boolean returnValue;
    String ip;
    public LoginConnection (LoginActivity activity,String[] parameters,SpTypes type,String ip){
        super();
        this.activity = activity;
        this.parameters =parameters;
        this.type = type;
        this.ip = ip;
        this.activity = activity;
    }
    @Override
    protected void onPreExecute() {

            activity.getLoginDialog().show();

    }

    @Override
    protected Object doInBackground(Object[] params) {
        try {
            switch (type){
                case LOGIN:
                    System.out.println("sisisisi");
                    returnValue = LoginAcces(parameters[0],parameters[1]);
                    System.out.println("holaoalsdnjk    "+returnValue);
                    finishConnection();
                    break;

            }

        }catch (Exception e){
            System.out.println("Error : "+ e.toString());
        }

        return null;

    }


    public boolean LoginAcces(String username,String password) throws Exception {
        String procedure = "{ ? = call dbo.SPS_LoginHiker(?,?) }";
        super.openConnectionWithReturnProcedure(procedure,ip);
        int returnValue = 0;
        CallableStatement storeProcedure = SqlConnection.prepareCall(procedure);
        storeProcedure.setString(2,username);
        storeProcedure.setString(3,password);
        storeProcedure.registerOutParameter(1, Types.INTEGER);
        storeProcedure.execute();
        if (storeProcedure.getInt(1)== 1){
            super.resultSet = storeProcedure.getResultSet();
            return true;
        }
        return false;
    }

    @Override
    protected void onPostExecute(Object o) {
        super.onPostExecute(o);
        activity.getLoginDialog().dismiss();
        if (returnValue){
            activity.startMainActivity();
        }
        else {
            activity.makeToasT("Usuario o contraseña incorrectos");
        }
    }
}
