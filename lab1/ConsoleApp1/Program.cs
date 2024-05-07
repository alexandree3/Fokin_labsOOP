using System;
using zadanie_2;
class Program
{
    static void Main(string[] args)
    {

        //zadanie2

        DDateTime decoratedEuropeanDateTime = new LDecorator(new FDecorator(new DateEuroStyle(), "AAA "), "FFF");
        DDateTime decoratedAmericanDateTime = new LDecorator(new FDecorator(new DateAmericanStyle(), "AAA "), "FFF");
    

        Console.WriteLine("Decorated European DateTime: " + decoratedEuropeanDateTime.Print());
        Console.WriteLine("Decorated American DateTime: " + decoratedAmericanDateTime.Print());
        
    }
}