!include "nsProcess.nsh"
OutFile "Setup.exe"

installDir "$PROGRAMFILES\PIMPhony Integration Utility\Desktop Notifier"
!define shortcutDir "$SMPROGRAMS\PIMPhony Integration Utility\Desktop Notifier"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
	${nsProcess::KillProcess} "DesktopNotifier.exe" $R0
	File /r "source\*"
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\Desktop Notifier.lnk" "$INSTDIR\DesktopNotifier.exe"
	createShortCut "${shortcutDir}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
sectionEnd

	section "Uninstall"
	SetShellVarContext all
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd