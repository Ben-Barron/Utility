Utility
=======

A set of extension, helper & utility classes written for .NET 4.5.1. (Most classes will compile for .NET version 4.0.)

Consists of the following projects:

- Utility
- Utility.Reactive
- Utility.Logging.Log4Net

Written in C# on Microsoft Visual Studio Express 2013 for Windows Desktop. You will also need NuGet package manager.

**Author:** Benjamin Barron.

Building the solution
---------------------

Ensure you have the following:

- Visual Studios (preferably <= 2013).
- NuGet package manager is installed (this is included with Visual Studios 2013 Express).

Instructions:

- Download the source & open the solution file found in the root (Utility.sln) in Visual Studios.
- Right-click on the Uilitiy solution in the Solution Explorer pane on the right and side and click "Enable NuGet Package Restore". This will begin to download the required packages.
- Now build the solution!

Project: Utility
----------------

Base set of utility classes.

**Dependencies:** Only uses libraries part of the .NET runtime.

Project: Utility.Reactive
-------------------------

Extensions, helper & utility classes that use Reactive Extensions.

**Dependencies:** Reactive Extensions.

Project: Utility.Logging.Log4Net
------------------------

Log4Net implementation for the logging classes in the Utility project.

**Dependencies:** Log4Net; Utility project.

Licence
-------

Copyright (c) 2014 Benjamin Barron

Permission is hereby granted, free of charge, to any person obtaining a copy 
of this software and associated documentation files (the "Software"), to deal 
in the Software without restriction, including without limitation the rights 
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
copies of the Software, and to permit persons to whom the Software is furnished 
to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all 
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
