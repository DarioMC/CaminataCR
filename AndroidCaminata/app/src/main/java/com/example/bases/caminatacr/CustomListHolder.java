package com.example.bases.caminatacr;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

/**
 * Created by Alexis on 5/17/2017.
 */

public class CustomListHolder  extends RecyclerView.ViewHolder{
    TextView title;
    ImageView imageView;
    public CustomListHolder(View itemView) {
        super(itemView);
        title = (TextView) itemView.findViewById(R.id.listTitle);
        imageView = (ImageView) itemView.findViewById(R.id.listImage);
    }
}
