; Inno Setup script to create an installer for GreenLife
[Setup]
AppName=GreenLife
AppVersion=1.0
DefaultDirName={pf}\GreenLife
DefaultGroupName=GreenLife
OutputBaseFilename=GreenLifeInstaller
Compression=lzma
SolidCompression=yes

[Files]
Source: "{#ProjectDir}\publish\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs

[Icons]
Name: "{group}\GreenLife"; Filename: "{app}\GreenLife.exe"
Name: "{group}\Uninstall GreenLife"; Filename: "{app}\unins000.exe"
