using System;

public class Satellite
{
    public enum SatelliteType { Sender, Receiver }

    public string Name { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double VelocityX { get; set; }
    public double VelocityY { get; set; }
    public SatelliteType Type { get; set; }

    private double orbitRadius;
    private double angularVelocity;
    private double angle;
    private double centerX;
    private double centerY;

    public Satellite(string name, SatelliteType type, double centerX, double centerY, double orbitRadius, double initialAngle, double angularVelocity)
    {
        Name = name;
        Type = type;
        this.centerX = centerX;
        this.centerY = centerY;
        this.orbitRadius = orbitRadius;
        this.angle = initialAngle;
        this.angularVelocity = angularVelocity;
        X = centerX + orbitRadius * Math.Cos(angle);
        Y = centerY + orbitRadius * Math.Sin(angle);
    }

    public void UpdatePosition(double timeStep)
    {
        double angleIncrement = angularVelocity * timeStep;
        angle += angleIncrement;

        X = centerX + orbitRadius * Math.Cos(angle);
        Y = centerY + orbitRadius * Math.Sin(angle);
    }
}
