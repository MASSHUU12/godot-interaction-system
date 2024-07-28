# Usage

Here you can find information about using this extension and its basic configuration.

## Getting started

To get started with this plugin, you must first do two things:

### Create C# solution

To create a C# solution in your project, you must select `Project > Tools > C# > Create C# solution` in the upper left corner of the window. This is a required action for any project created in C#.

### Configure .csproj

Unfortunately, the official template in the generated .csproj file is inadequate and cannot cope with more advanced projects, and as a result, several improvements need to be made to it.

```xml
<Project Sdk="Godot.NET.Sdk/4.2.1">
  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <TargetFramework Condition=" '$(GodotTargetPlatform)' == 'android' ">net7.0</TargetFramework>
    <TargetFramework Condition=" '$(GodotTargetPlatform)' == 'ios' ">net8.0</TargetFramework>
    <EnableDynamicLoading>true</EnableDynamicLoading>
    <LangVersion>11.0</LangVersion>
  </PropertyGroup>
  <ItemGroup>
    <Compile Remove="script_templates/**/*.cs" />
  </ItemGroup>
</Project>
```

After performing these two actions, you can now compile the project and activate this plugin.
