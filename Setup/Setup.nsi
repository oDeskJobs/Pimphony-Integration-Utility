!include "nsProcess.nsh"
OutFile "Setup.exe"

installDir "$PROGRAMFILES\PIMPhony Integration Utility"
!define shortcutDir "$SMPROGRAMS\PIMPhony Integration Utility"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
        ${nsProcess::KillProcess} "DesktopNotifier.exe" $R0
	File /r "source\*"
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\Desktop Notifier.lnk" "$INSTDIR\DesktopNotifier.exe"
	createShortCut "${shortcutDir}\Integration Settings.lnk" "$INSTDIR\piu.exe" "-setting"
	createShortCut "${shortcutDir}\Integration Settings.lnk" "$INSTDIR\piu.exe" "-setting"
	createShortcut "${shortcutDir}\Integration Guide.lnk" "$INSTDIR\PIMPhony Integration Utility Guide.pdf"
	createShortCut "${shortcutDir}\Uninstall Pimphony Integration Utility.lnk" "$INSTDIR\uninstaller.exe"
sectionEnd

	section "Uninstall"
	SetShellVarContext all
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd