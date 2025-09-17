using Lab2_1;

Console.WriteLine("=== Common .NET Classes and Types Demo ===\n");

// String operations
StringOperations.DemonstrateStringMethods();
StringOperations.DemonstrateStringComparison();
StringOperations.DemonstrateStringValidation();

// DateTime operations
DateTimeOperations.DemonstrateDateTimeBasics();
DateTimeOperations.DemonstrateDateTimeFormatting();
DateTimeOperations.DemonstrateTimeSpan();
DateTimeOperations.DemonstrateAgeCalculation();

// Math and utilities
MathAndUtilities.DemonstrateMathClass();
MathAndUtilities.DemonstrateRandomClass();
MathAndUtilities.DemonstrateGuidClass();
MathAndUtilities.DemonstrateConvertClass();
MathAndUtilities.DemonstrateTypeChecking();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();