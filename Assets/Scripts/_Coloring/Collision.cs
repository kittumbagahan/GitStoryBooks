﻿using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using System;
using UnityEngine.UI;

=======
using System;
using UnityEngine.UI;

>>>>>>> master
public class Collision : MonoBehaviour {

    [SerializeField]
    Colors.COLORS Color;

    [SerializeField]
    RawImage GreyLayer, WhiteLayer;    
      
    bool clicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
<<<<<<< HEAD
	}    
   
    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            Colors.instance.ClickCheck();
        }

        //print("Clicked " + gameObject.name);
        if (Colors.selectedColor == Color)
        {            
            GreyLayer.enabled = false; WhiteLayer.enabled = false;
            print("correct color");            
        }
        else if(Colors.selectedColor == Colors.COLORS.NULL)
        {

        }
        else
        {          
            print("not correct color, selected color: " + Colors.selectedColor + " area color: " + Color);
            GreyLayer.enabled = true; WhiteLayer.enabled = false;
            GreyLayer.color = Colors.instance.SelectedColorValue();
        }                   
    }
=======
	}    
   
    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            Colors.instance.ClickCheck();
        }

        //print("Clicked " + gameObject.name);
        if (Colors.selectedColor == Color)
        {            
            GreyLayer.enabled = false; WhiteLayer.enabled = false;
            print("correct color");            
        }
        else if(Colors.selectedColor == Colors.COLORS.NULL)
        {

        }
        else
        {          
            print("not correct color, selected color: " + Colors.selectedColor + " area color: " + Color);
            GreyLayer.enabled = true; WhiteLayer.enabled = false;
            GreyLayer.color = Colors.instance.SelectedColorValue();
        }                   
    }
>>>>>>> master

	void OnMouseUp()
	{
		if(Colors.selectedColor == Colors.COLORS.NULL)
		{
			print("UP but null");
		}
		else
		{
			print("up with color");
		}
	}
<<<<<<< HEAD

    //public Colors.COLORS MyColor
    //{
    //    get { return Color; }
    //}
=======

    //public Colors.COLORS MyColor
    //{
    //    get { return Color; }
    //}
>>>>>>> master
}
