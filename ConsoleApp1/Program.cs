﻿using System;
using System.IO;
namespace ConsoleApp1
{
    //
    class MainClass
    {

        class Tr
        {
            public struct x_y
            {
                public double x, y;
            }

            public double degrees, speed, angle;

            public void angle_set(double degrees)
            {
                angle = (Math.PI * degrees / 180);
            }

            public x_y get_Tr(double time)
            {
                x_y coor;
                coor.x = speed * time * Math.Cos(angle);
                coor.y = speed * time * Math.Sin(angle) - 4.9 * time * time;
                if (coor.y <= 0)
                    coor.y = 0;

                return (coor);
            }

            public void find_dot(double time)
            {
                x_y coor;
                coor.x = speed * time * Math.Cos(angle); ;
                coor.y = speed * time * Math.Sin(angle) - 4.9 * time * time;
                if (coor.y <= 0)
                    coor.y = 0;

                Console.WriteLine(coor.x + " " + coor.y);
                
               
                return;
            }
            
            public void Tr_paint(double time, double steps)
            {
                string writePath = @"../../../Txt.txt";
                for (double i = 0; i < time; i += steps)
                {
                    x_y point = get_Tr(i);
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(point.x);
                            sw.WriteLine(point.y);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                find_dot(time);
            }

            public Tr(double degrees, double speed)
            {
                this.degrees = degrees;
                this.speed = speed;
                angle_set(degrees);
            }
        }


        public static void Main(string[] args)
        {
            Tr Gr = new Tr(60, 20);
            Gr.Tr_paint(10, 0.5);
        }
    }
}
