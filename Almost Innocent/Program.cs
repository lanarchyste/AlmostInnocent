﻿// See https://aka.ms/new-console-template for more information

using Almost_Innocent.Scenarios;
using System.Text.RegularExpressions;

Regex regexScenario = new("^[1-7]{1}$");

Console.Write("Choisissez un scénario : ");

var scenario = ChooseScenario();
scenario.Launch();

IScenario ChooseScenario()
{
    var scenario = Console.ReadLine();

    if(string.IsNullOrEmpty(scenario) || !regexScenario.IsMatch(scenario))
    {
        Console.Write("Je n'ai pas compris votre choix ! ");
        return ChooseScenario();
    }

    return scenario switch
    {
        "7" => Scenario7.Setup(),
        "6" => Scenario6.Setup(),
        "5" => Scenario5.Setup(),
        "4" => Scenario4.Setup(),
        "3" => Scenario3.Setup(),
        "2" => Scenario2.Setup(),
        _ => Scenario1.Setup(),
    };
}