public class GroundStation
{
    public enum StationType { Communication, Tracking, Both }

    public string Name { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double CommunicationRadius { get; set; }
    public StationType Type { get; set; }

    public GroundStation(string name, StationType type, double x, double y, double communicationRadius)
    {
        Name = name;
        Type = type;
        X = x;
        Y = y;
        CommunicationRadius = communicationRadius;
    }

    public bool IsSatelliteInFoV(Satellite satellite)
    {
        double dist = Math.Sqrt(Math.Pow(satellite.X - X, 2) + Math.Pow(satellite.Y - Y, 2));
        return dist <= CommunicationRadius;
    }
}
