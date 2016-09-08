Configurable ILMerge Task for MSBuild
=====================================

Adds ILMerge to Visual Studio 2013/2015 or automated builds. This Task is intended to work right out of the box however, it supports a configuration file where you can control every ILMerge property including the list of assemblies to be merged.

Getting Started
---------------

Use Nuget to add ILMerge.MSBuild.Task to your Visual Studio project:

```
Install-Package ILMerge.MSBuild.Task
```

Build your project. The merged assembly will be stored in an ILMerge folder under your project output.
The output directory is configurable.

![Project To Merge Output](Images/project_to_merge_output.png)

How it Works
------------

By default all references with *Copy Local* equals *true* are merged with your project output.

![Copy Local Property](Images/copy_local_property.png)

It is also possible to use a static list of assemblies.
This list can be added to the optional configuration file.

### Using a Configuration File

On the root of your project create a file named:

```
ILMergeConfig.json
```

This snippet instructs the Task to ignore *Copy Local* and use the files listed in the *InputAssemblies* property.

```javascript
{
	"General": {
		"InputAssemblies": [
		  "$(TargetDir)XrmUtils.Plugins.Abstractions", 
		  "$(TargetDir)XrmUtils.Plugins.Utilities" 
		]
	}
}
```

See the wiki for a complete reference of [Configuration File](https://github.com/emerbrito/ILMerge-MSBuild-Task/wiki/Config-File).

Project Wiki
------------

See the project wiki for documentation.
