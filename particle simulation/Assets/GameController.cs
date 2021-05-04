using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public InputField part_radius; //Declares the input fields used in unity
    public InputField part_height; 
    public Dropdown temperature; //Declares the dropdown menu used in Unity

    public string radius; //Variables for calculations 
    public string height;
    public double result;
    public double air_viscosity;
    public double prefactor;

    public Camera main_Camera;
    public Camera canvas_Camera;

    public InputField in_num_part;
    public ParticleSystem model;
    public WindZone Vent1;
    public WindZone Vent2;
    public WindZone Vent3;
    public WindZone Vent4;
    public WindZone Vent5;



    public void checkInput(string test) //Method is useless. Is this way to get Unity to recognize the function
    {
        radius = part_radius.text; //sets the input variable to the value from the input field
        height = part_height.text;
        var in_num_particles = in_num_part.text;
        int.TryParse(in_num_particles, out int num_particles);

        if (temperature.value == 0) //Sets the air viscosity dependent on the temperature of the air
        {
            air_viscosity = 1.778 * Math.Pow(10, -8) ;
        }else if (temperature.value == 1)
        {
            air_viscosity = 1.802 * Math.Pow(10, -8);
        }else if (temperature.value == 2)
        {
            air_viscosity = 1.825 * Math.Pow(10, -8);
        }else if (temperature.value == 3)
        {
            air_viscosity = 1.849 * Math.Pow(10, -8);
        }else if (temperature.value == 4)
        {
            air_viscosity = 1.872 * Math.Pow(10, -8);
        }

        prefactor = 9 * air_viscosity / (2 * Math.Pow(10, -12) * (9.8 * Math.Pow(10, 6))); //Calculates the prefactor

        if (double.TryParse(radius, out double result_radius) && double.TryParse(height, out double result_height)) //Converts the string to a double and outputs the varialbe to the variable result
        {
            result = prefactor * (result_height * Math.Pow(10, 6) / Math.Pow(result_radius, 2)); //does the calculation
            result = (int)result;
            Debug.Log(result); //outputs the result to the debug console
        }

        var main = model.main;
        main.maxParticles = num_particles;

    }

    public void switch_Camera(string Test)
    {
        canvas_Camera.enabled = false;
        main_Camera.enabled = true;
    }

    public void switch_Camera_Back(string Test)
    {
        main_Camera.enabled = false;
        canvas_Camera.enabled = true;
    }

    void Start() //A second way of calling the function (may be redundant now that we have a Run button)
    {
        if (Input.GetKeyDown("space"))
        {
            checkInput("test");
        }
    }
}
