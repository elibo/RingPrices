; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Alianzas"
#define MyAppVersion "0.30"
#define MyAppPublisher "Akros"
#define MyAppExeName "Prezas.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{CD98F0DA-2A77-496A-9474-6E91FEAFE713}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=Instalar
Compression=lzma
SolidCompression=yes

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\catalogo.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.vshost.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Prezas.vshost.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\eli\Desktop\Prezas\Prezas\bin\Debug\Images\*"; DestDir: "{app}\Images"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

