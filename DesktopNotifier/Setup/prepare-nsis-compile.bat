@echo off
mkdir source
copy "..\bin\release\DesktopNotifier.exe" source
mkdir source\Media
copy "..\bin\release\Media\newmail.wav" "source\Media\" 

