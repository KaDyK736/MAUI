using System;
using System.Collections.Generic;
public class QuadEquation
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D
    {
        get { return B * B - 4 * A * C; }
    }
    public QuadEquation(float a, float b, float c)
    {
        A = a; B = b; C = c;
    }
    public List<double> Solve()
    {
        var res = new List<double>();
        if (D == 0)
            res.Add(-B / (2 * A));
        else if (D > 0)
        {
            res.Add((-B + Math.Sqrt(D)) / 2 / A);
            res.Add((-B - Math.Sqrt(D)) / 2 / A);
        }
        return res;
    }
}