package com.example.bases.caminatacr.Tabs;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.bases.caminatacr.Connection.CaminataConnection;
import com.example.bases.caminatacr.Connection.LoginConnection;
import com.example.bases.caminatacr.Connection.SpTypes;
import com.example.bases.caminatacr.MainActivity;
import com.example.bases.caminatacr.R;


/**
 * Created by Alexis on 5/18/2017.
 */

public class LoginActivity extends AppCompatActivity {
    private EditText txt_Username;
    private EditText txt_Password;
    private Button bt;
    private ProgressDialog loginDialog;
    LoginConnection connection ;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        bt = (Button) findViewById(R.id.Acceder);
        txt_Username = (EditText)findViewById(R.id.txt_Username);
        txt_Password = (EditText)findViewById(R.id.txt_PassWord);
        loginDialog=new ProgressDialog(this);
        loginDialog.setTitle("Wait");
        loginDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        bt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                connection = new LoginConnection(LoginActivity.this,new String[]{txt_Username.getText().toString(),txt_Password.getText().toString()}, SpTypes.LOGIN,"192.168.1.104");
                connection.execute();
                System.out.println("Toco boton");
            }
        });
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.mymenu, menu);
        return true;
    }
    public void init(){

    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.Acceder) {
            if (this.getClass().equals(LoginActivity.class)){
                return true;
            }
            Intent intent = new Intent(this,LoginActivity.class);
            startActivity(intent);
            finish();
        }
        if (id == R.id.Registrarse) {
            if (this.getClass().equals(RegisterActivity.class)){
                return true;
            }
            Intent intent = new Intent(this,RegisterActivity.class);
            startActivity(intent);
            finish();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public ProgressDialog getLoginDialog() {
        return loginDialog;
    }

    public void setLoginDialog(ProgressDialog loginDialog) {
        this.loginDialog = loginDialog;
    }
    public void startMainActivity(){

        Intent intent = new Intent(LoginActivity.this,MainActivity.class);
        startActivity(intent);
        finish();
    }
    public void makeToasT(String text){

        Toast.makeText(this,text,Toast.LENGTH_SHORT).show();

    }
}
