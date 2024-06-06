using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

public partial class Form1 : Form
{
    private List<Satellite> satellites = new List<Satellite>();
    private List<GroundStation> groundStations = new List<GroundStation>();
    private Timer simulationTimer = new Timer();
    private double earthCenterX = 400;  // Center of the PictureBox
    private double earthCenterY = 225;
    private double earthRadius = 100;   // Radius of the Earth

    public Form1()
    {
        InitializeComponent();
        simulationTimer.Interval = 100;  // ms
        simulationTimer.Tick += SimulationTick;
    }

    private void btnStartSimulation_Click(object sender, EventArgs e)
    {
        simulationTimer.Start();
    }

    private void btnAddSatellite_Click(object sender, EventArgs e)
    {
        using (var dialog = new SatelliteDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                satellites.Add(new Satellite(
                    dialog.SatelliteName,
                    dialog.SatelliteType,
                    dialog.CenterX,
                    dialog.CenterY,
                    dialog.OrbitRadius,
                    dialog.InitialAngle,
                    dialog.AngularVelocity
                ));
                pictureBox1.Invalidate();  // Update the display
            }
        }
    }

    private void btnAddGroundStation_Click(object sender, EventArgs e)
    {
        using (var dialog = new GroundStationDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                groundStations.Add(new GroundStation(
                    dialog.GroundStationName,
                    dialog.GroundStationType,
                    dialog.InitialX,
                    dialog.InitialY,
                    dialog.CommunicationRadius
                ));
                pictureBox1.Invalidate();  // Update the display
            }
        }
    }

    private void SimulationTick(object sender, EventArgs e)
    {
        foreach (var satellite in satellites)
        {
            satellite.UpdatePosition(5);  // Update position with time step
        }
        CheckInteractions();
        pictureBox1.Invalidate();  // Forces the form to redraw
    }

    private void CheckInteractions()
    {
        foreach (var station in groundStations)
        {
            foreach (var satellite in satellites)
            {
                if (station.IsSatelliteInFoV(satellite))
                {
                    if (station.Type == GroundStation.StationType.Communication || station.Type == GroundStation.StationType.Both)
                    {
                        if (satellite.Type == Satellite.SatelliteType.Sender)
                        {
                            Console.WriteLine($"Ground Station {station.Name} is receiving data from Satellite {satellite.Name}");
                        }
                        else if (satellite.Type == Satellite.SatelliteType.Receiver)
                        {
                            Console.WriteLine($"Ground Station {station.Name} is sending data to Satellite {satellite.Name}");
                        }
                    }

                    if (station.Type == GroundStation.StationType.Tracking || station.Type == GroundStation.StationType.Both)
                    {
                        Console.WriteLine($"Ground Station {station.Name} is tracking Satellite {satellite.Name}");
                    }
                }
            }
        }
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.Black);

        // Draw Earth
        g.FillEllipse(Brushes.Blue, (float)(earthCenterX - earthRadius), (float)(earthCenterY - earthRadius), (float)(2 * earthRadius), (float)(2 * earthRadius));

        // Draw satellites
        foreach (var satellite in satellites)
        {
            g.FillEllipse(Brushes.White, (float)satellite.X - 5, (float)satellite.Y - 5, 10, 10);
        }

        // Draw ground stations and their FoVs
        foreach (var station in groundStations)
        {
            g.FillEllipse(Brushes.Green, (float)station.X - 5, (float)station.Y - 5, 10, 10);
            g.DrawEllipse(Pens.Yellow, (float)(station.X - station.CommunicationRadius), (float)(station.Y - station.CommunicationRadius), (float)(2 * station.CommunicationRadius), (float)(2 * station.CommunicationRadius));
        }
    }
}
