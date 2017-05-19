package com.example.bases.caminatacr;

/**
 * Created by Alexis on 5/14/2017.
 */

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.support.v4.content.ContextCompat;
import android.support.v4.content.res.ResourcesCompat;
import android.support.v7.widget.DividerItemDecoration;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.Layout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import com.example.bases.caminatacr.Connection.CaminataConnection;
import com.example.bases.caminatacr.Data.Caminata;

import java.util.ArrayList;
import java.util.List;


public class Tab1 extends Fragment{
    private  String text ;
    private RecyclerView recyclerView;
    private CustomListAdapter listAdapter;
    private List<Caminata> containers ;
    private MainActivity parent;
    private ProgressDialog mdialog;
    public Tab1() {
        containers = new ArrayList<>();

    }
    public void setParent(){this.parent = parent;}
    public void addContainer(Caminata caminata){
        containers.add(caminata);
    }
    public void clearCaminatas(){
        containers.clear();
    }
    public List<Caminata> getData(){

        Drawable myDrawable = ContextCompat.getDrawable(getActivity(),R.drawable.ic_action_users);
        Bitmap bitmap = ((BitmapDrawable) myDrawable).getBitmap();
        containers.add(new Caminata("Alexis",bitmap));
        containers.add(new Caminata("Si se puede",bitmap));
        List<ListContainer> data = new ArrayList<>();
        int[] images= {R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users,R.drawable.ic_action_users};
        String[] titles = {"Alexis","Dale","Hola","Si","Yalo","asdad","asdad","asdasd"};
        for (int i = 0; i <titles.length && i<images.length ; i++) {
            ListContainer current = new ListContainer();
            current.imageId = images[i];
            current.title = titles[i];
            data.add(current);
        }
        return containers;
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.tab1, container, false);
        TextView title = (TextView) rootView.findViewById(R.id.title);
        title.setText("lalolaoloa");
        recyclerView = (RecyclerView) rootView.findViewById(R.id.list_item);
        listAdapter = new CustomListAdapter(getActivity(),getData());
        recyclerView.setAdapter(listAdapter);
        LinearLayoutManager manager =new LinearLayoutManager(getActivity());
        recyclerView.setLayoutManager(manager);

        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(recyclerView.getContext(),
                manager.getOrientation());
        recyclerView.addItemDecoration(dividerItemDecoration);

        return rootView;
    }

}
