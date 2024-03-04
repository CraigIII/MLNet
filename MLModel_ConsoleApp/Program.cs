﻿
// This file was auto-generated by ML.NET Model Builder. 

using MLModel_ConsoleApp;

// Create single instance of sample data from first line of dataset for model input
MLModel.ModelInput sampleData = new MLModel.ModelInput()
{
    Checking_status = @"0<=X<200",
    Duration = 48F,
    Credit_history = @"existing paid",
    Purpose = @"radio/tv",
    Credit_amount = 5951F,
    Savings_status = @"<100",
    Employment = @"1<=X<4",
    Installment_commitment = 2F,
    Personal_status = @"female div/dep/mar",
    Other_parties = @"none",
    Residence_since = 2F,
    Property_magnitude = @"real estate",
    Age = 22F,
    Other_payment_plans = @"none",
    Housing = @"own",
    Existing_credits = 1F,
    Job = @"skilled",
    Num_dependents = 1F,
    Own_telephone = @"none",
};



Console.WriteLine("Using model to make single prediction -- Comparing actual Class with predicted Class from sample data...\n\n");


Console.WriteLine($"Checking_status: {@"0<=X<200"}");
Console.WriteLine($"Duration: {48F}");
Console.WriteLine($"Credit_history: {@"existing paid"}");
Console.WriteLine($"Purpose: {@"radio/tv"}");
Console.WriteLine($"Credit_amount: {5951F}");
Console.WriteLine($"Savings_status: {@"<100"}");
Console.WriteLine($"Employment: {@"1<=X<4"}");
Console.WriteLine($"Installment_commitment: {2F}");
Console.WriteLine($"Personal_status: {@"female div/dep/mar"}");
Console.WriteLine($"Other_parties: {@"none"}");
Console.WriteLine($"Residence_since: {2F}");
Console.WriteLine($"Property_magnitude: {@"real estate"}");
Console.WriteLine($"Age: {22F}");
Console.WriteLine($"Other_payment_plans: {@"none"}");
Console.WriteLine($"Housing: {@"own"}");
Console.WriteLine($"Existing_credits: {1F}");
Console.WriteLine($"Job: {@"skilled"}");
Console.WriteLine($"Num_dependents: {1F}");
Console.WriteLine($"Own_telephone: {@"none"}");
Console.WriteLine($"Class: {@"bad"}");


var sortedScoresWithLabel = MLModel.PredictAllLabels(sampleData);
Console.WriteLine($"{"Class",-40}{"Score",-20}");
Console.WriteLine($"{"-----",-40}{"-----",-20}");

foreach (var score in sortedScoresWithLabel)
{
    Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
}

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();
