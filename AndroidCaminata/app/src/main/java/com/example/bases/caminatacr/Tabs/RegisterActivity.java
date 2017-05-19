package com.example.bases.caminatacr.Tabs;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import com.example.bases.caminatacr.R;
import android.support.v7.app.AppCompatActivity;

/**
 * Created by Alexis on 5/19/2017.
 */

public class RegisterActivity extends AppCompatActivity{
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.mymenu, menu);
        return true;
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
            return true;
        }
        if (id == R.id.Registrarse) {
            if (this.getClass().equals(RegisterActivity.class)){
                return true;
            }
            Intent intent = new Intent(this, RegisterActivity.class);
            startActivity(intent);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
