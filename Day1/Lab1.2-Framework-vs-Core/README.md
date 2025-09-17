# Lab 1.2: .NET Framework vs .NET Core/5+

## Objective
Understand the evolution of .NET and the key differences between .NET Framework and modern .NET.

## Duration: 30 minutes

## Theory
.NET has evolved significantly over the years:
- **.NET Framework**: Windows-only, legacy platform (4.8 is final version)
- **.NET Core**: Cross-platform, open-source rewrite
- **.NET 5+**: Unified platform combining .NET Core and Framework

## Exercise

### Part A: Understanding the Differences (15 minutes)
Create comparison projects to see the differences in project files and capabilities.

### Part B: Migration Concepts (15 minutes)
Explore what it means to migrate from Framework to modern .NET.

## Hands-On Tasks

### Task 1: Create .NET Framework Style Project
```bash
# This simulates old .NET Framework project structure
mkdir FrameworkStyleApp
cd FrameworkStyleApp
```

Create a traditional Program.cs:
```csharp
using System;

namespace FrameworkStyleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from .NET Framework style!");
            Console.WriteLine($"Runtime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
            Console.ReadLine();
        }
    }
}
```

### Task 2: Create Modern .NET Project
```bash
dotnet new console -n ModernDotNetApp
cd ModernDotNetApp
```

Examine the generated Program.cs (top-level statements):
```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello from Modern .NET!");
Console.WriteLine($"Runtime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
```

### Task 3: Compare Project Files
Compare the .csproj files:

**Framework Style** (verbose):
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{GUID}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <RootNamespace>FrameworkStyleApp</RootNamespace>
    <AssemblyName>FrameworkStyleApp</AssemblyName>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
  </PropertyGroup>
  <!-- More verbose configuration -->
</Project>
```

**Modern .NET** (minimal):
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

## Key Differences Table

| Feature | .NET Framework | Modern .NET |
|---------|----------------|-------------|
| Platform | Windows only | Cross-platform |
| Open Source | No | Yes |
| Performance | Good | Excellent |
| Project Files | Verbose XML | Minimal SDK-style |
| Deployment | Framework required | Self-contained possible |
| Package Management | packages.config | PackageReference |
| Top-level statements | No | Yes (C# 9+) |

## Expected Output
- Understanding of .NET evolution
- Ability to identify Framework vs modern .NET projects
- Knowledge of migration considerations

## Key Takeaways
- Modern .NET is the future of .NET development
- Cross-platform capabilities open new deployment options
- SDK-style projects are much simpler to manage
- Performance improvements are significant

## Next Lab
Lab 1.3 will guide you through creating your first complete project.
