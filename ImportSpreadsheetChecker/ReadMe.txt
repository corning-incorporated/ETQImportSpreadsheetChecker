' **************************************************
'   Copyright 2022 Corning Incorporated
'   Author: Tom Gee
' **************************************************

This solution requires both Microsoft Office and WinSCP (client) to be installed in order to add the following references.

The following references will need to be manually added to the solution before the project will successfully start/compile.

1. Once Microsoft Office has been installed, right-click References from the solution explorer and select "Add Reference..."
2. Expand the "Assemblies" list and select the "Extensions" option.
3. Scroll through the list of references, check the box to select "Microsoft.Office.Interop.Excel", and click the OK button to close the References dialog.

	Reference Name:	Microsoft.Office.Interop.Excel
	Type:			.NET
	Version:		v14.0.0.0 (or higher)
	File:			Microsoft.Office.Interop.Excel.dll


1. Once WinSCP has been installed, right-click References from the solution explorer and select "Add Reference..."
2. Click the "Browse..." button
3. Navigate to the folder where you have WinSCP installed (typically "C:\Program Files (x86)\WinSCP\")
4. Select the "WinSCPnet.dll" file and click the Add button
5. Click OK to close the References dialog.

	Reference Name:	WinSCPnet.dll
	Type:			.NET
	Version:		1.8.3.11614 (or higher)
	File:			WinSCPnet.dll

You should now be able to start/compile the application.
Enjoy!