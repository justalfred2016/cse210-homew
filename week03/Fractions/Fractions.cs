using System;
using System.Diagnostics;
using System.Formats.Asn1;


public class Fractions
{
    private int _top;
    private int _bottom;

    public Fractions(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    
    public Fractions(int bottom){
        _top = 1;
        _bottom = bottom;
    }
    public Fractions(){
        _top = 1;
        _bottom = 1;
    }

    public string GetFractionString(){
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue(){
        return (double)_top / _bottom;
    }
}
