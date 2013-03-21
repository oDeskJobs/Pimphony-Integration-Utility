@echo off
del source\*.* /S /F /Q
mkdir source
rem NAppUpdate
copy "..\AutoUpdater\NAppUpdate.Framework\bin\release\NAppUpdate.Framework.dll" source
rem Desktop notifier
copy "..\DesktopNotifier\bin\release\DesktopNotifier.exe" source
mkdir source\Media
copy "..\DesktopNotifier\bin\release\Media\newmail.wav" "source\Media\" 
rem PIU
copy "..\Pimphony Integration Utility\bin\release\piu.exe" source
copy resource\*.* source

