package com.example.bases.caminatacr;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.drawable.BitmapDrawable;
import android.support.annotation.Nullable;
import android.support.design.widget.TabLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;

import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.view.Gravity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.PopupWindow;

import com.example.bases.caminatacr.Connection.CaminataConnection;
import com.example.bases.caminatacr.Tabs.LoginActivity;

public  class MainActivity extends AppCompatActivity {

    /**
     * The {@link android.support.v4.view.PagerAdapter} that will provide
     * fragments for each of the sections. We use a
     * {@link FragmentPagerAdapter} derivative, which will keep every
     * loaded fragment in memory. If this becomes too memory intensive, it
     * may be best to switch to a
     * {@link android.support.v4.app.FragmentStatePagerAdapter}.
     */
    private SectionsPagerAdapter mSectionsPagerAdapter;
    private ProgressDialog mdialog;

    /**
     * The {@link ViewPager} that will host the section contents.
     */
    private ViewPager mViewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        /*Button bt = (Button) findViewById(R.id.button) ;
        bt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                View popUpView1 = getLayoutInflater().inflate(R.layout.pop_login, null);
                PopupWindow mpopup1 = new PopupWindow(popUpView1, 500,600, true);
                //*mpopup.setAnimationStyle(R.style.Animations_GrowFromBottom);
                //mpopup1.setBackgroundDrawable(new BitmapDrawable());
               mpopup1.setOutsideTouchable(false);
                mpopup1.showAtLocation(popUpView1, Gravity.CENTER,100,0);
              /*  mpopup1.setOnDismissListener(new PopupWindow.OnDismissListener() {
                    @Override
                    public void onDismiss() {

                        System.out.println("dismiss");
                    }
                });
            }
        });*/

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager());

        // Set up the ViewPager with the sections adapter.
        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);

        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(mViewPager);
        tabLayout.getTabAt(0).setIcon(R.drawable.ic_golf_course);
        tabLayout.getTabAt(1).setIcon(R.drawable.ic_local_atm);
        tabLayout.getTabAt(2).setIcon(R.drawable.ic_people);
        /*FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });*/


       // System.out.println("Pasoooooooooooooooooooooo");
        //SQLConnection Connect = new SQLConnection();
       // Connect.execute();
        //mdialog=new ProgressDialog(this);
     //   mdialog.setTitle("Wait");
      //  mdialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);




    }

    @Override
    protected void onPostCreate(@Nullable Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }
        if (id == R.id.action_cerraSesion) {
            Intent intent = new Intent(this,LoginActivity.class);
            startActivity(intent);
            finish();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public Dialog getMdialog() {
        return mdialog;
    }

    public void mdialogShow() {
        this.mdialog.show();
    }
}


