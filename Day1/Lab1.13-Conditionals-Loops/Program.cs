using System;
using Lab1_13;

Console.WriteLine("=== Conditionals and Loops Demo ===\n");

// Conditional statements
ConditionalStatements.DemonstrateIfElse();
ConditionalStatements.DemonstrateSwitchStatement();
ConditionalStatements.DemonstrateSwitchExpressions();

// Loop structures
LoopStructures.DemonstrateForLoop();
LoopStructures.DemonstrateWhileLoop();
LoopStructures.DemonstrateDoWhileLoop();
LoopStructures.DemonstrateForeachLoop();
LoopStructures.DemonstrateAdvancedLoopControl();

// Practical examples
PracticalExamples.NumberGuessingGame();
PracticalExamples.CalculateFactorial();
PracticalExamples.FibonacciSequence();
PracticalExamples.PrimeNumberFinder();
PracticalExamples.MultiplicationTable();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
