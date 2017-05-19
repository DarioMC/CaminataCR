package com.example.bases.caminatacr;

import android.app.LauncherActivity;
import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.bases.caminatacr.Data.Caminata;

import java.util.Collections;
import java.util.List;

import static android.R.attr.data;

/**
 * Created by Alexis on 5/16/2017.
 */

public class CustomListAdapter extends RecyclerView.Adapter<CustomListHolder>{
    private  LayoutInflater inflater;
    private List<Caminata> listItems= Collections.emptyList();
    public CustomListAdapter(Context context,List<Caminata> listitems){
        inflater =LayoutInflater.from(context);
        this.listItems = listitems;
    }
    @Override
    public CustomListHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = inflater.inflate(R.layout.custom_list,parent,false);
        CustomListHolder holder = new CustomListHolder(view);
        return holder;
    }

    @Override
    public void onBindViewHolder(CustomListHolder holder, int position) {
        Caminata current = listItems.get(position);
        holder.title.setText(current.direccion);
        holder.imageView.setImageBitmap(current.imagen);
    }

    @Override
    public int getItemCount() {
        return listItems.size();
    }
}
