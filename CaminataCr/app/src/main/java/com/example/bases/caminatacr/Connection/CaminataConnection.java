package com.example.bases.caminatacr.Connection;

import android.app.ProgressDialog;

import com.example.bases.caminatacr.MainActivity;
import com.example.bases.caminatacr.Tab1;
import com.example.bases.caminatacr.Tabs.LoginActivity;
import com.example.bases.caminatacr.Tabs.RegisterActivity;

import java.sql.CallableStatement;
import java.sql.Types;

/**
 * Created by Alexis on 5/18/2017.
 */

public class CaminataConnection extends SQLConnection {
    Object activity;
    String [] parameters;
    SpTypes type;
    String ip;
    public CaminataConnection (Object activity,String[] parameters,SpTypes type,String ip){
        super();
        this.activity = activity;
        this.parameters =parameters;
        this.type = type;
        this.ip = ip;
    }
    @Override
    protected void onPreExecute() {


        if (activity.getClass().getClass().equals(MainActivity.class)){
            activity  = (MainActivity)activity;

        }
        else if(activity.getClass().getClass().equals(LoginActivity.class)){
            activity  = (LoginActivity)activity;
            ((LoginActivity) activity).getLoginDialog().show();
        }
        else if (activity.getClass().getClass().equals(RegisterActivity.class)){
            activity  = (RegisterActivity)activity;
        }

    }

    @Override
    protected Object doInBackground(Object[] params) {
        try {
            switch (type){
                case LOGIN:
                    LoginAcces(parameters[0],parameters[1]);
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

        System.out.println("Llego");
        if (activity.getClass().getClass().equals(MainActivity.class)){
            activity  = (MainActivity)activity;

        }
        else if(activity.getClass().getClass().equals(LoginActivity.class)){
            activity  = (LoginActivity)activity;
            ((LoginActivity) activity).getLoginDialog().dismiss();
        }
        else if (activity.getClass().getClass().equals(RegisterActivity.class)){
            activity  = (RegisterActivity)activity;
        }
    }
}
