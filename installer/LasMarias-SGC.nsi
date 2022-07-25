!include "MUI2.nsh"

Name "Sistema de Gestion - Hotel & Resort Las Maria's"
OutFile "SGC-LasMarias.exe"
Unicode true
InstallDir "$LOCALAPPDATA\LasMarias"
InstallDirRegKey HKCU "Software\LasMarias" ""
RequestExecutionLevel admin

!define APP_NAME "LasMarias"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "banner.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP "side.bmp"
!define MUI_ABORTWARNING

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "..\License.txt"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "Spanish"

Section "PostgreSQL" SecDatabase
    File /nonfatal /r "components\PostgreSQL"
SectionEnd

Section "NginX (Servidor Web)" SecNginx
    File /nonfatal /r "components\nginx"
SectionEnd

Section "Panel de control" SecControlPanel
    ; register so we launch control panel at startup
;   WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Run" "Notepad" "$WinDir\Notepad.exe"
SectionEnd

Section "Sistema Gestor Principal" SecServer
   File /nonfatal /r "components\backend"
SectionEnd

Section "Nssm (Gestor de Servicios)" SecNssm
    File /nonfatal /r "components\nssm"
SectionEnd

Section "VC++ Redistributable" SecVCRedist
    ; File /nonfatal /r "components\vcredist"
SectionEnd

Section ".NET 6 Runime" SecAspNET
;   File /nonfatal /r "components\aspnetruntime"
;   ExecWait '"$INSTDIR\dotnetruntime\dotnet-runtime-6.0.1-win-x64.exe" "/install" "/passive"'
SectionEnd

LangString DESC_SecDatabase ${LANG_SPANISH} "Servidor de base de datos."
LangString DESC_SecNginx ${LANG_SPANISH} "Servidor web y proxy inverso."
LangString DESC_SecServer ${LANG_SPANISH} "Servidor de backend de API."
LangString DESC_SecNssm ${LANG_SPANISH} "Gestor de servicios de windows."
LangString DESC_SecVCRedist ${LANG_SPANISH} "Paquete de redistribucion de VC++."
LangString DESC_SecControlPanel ${LANG_SPANISH} "Panel de control de servicios."
LangString DESC_SecAspNET ${LANG_SPANISH} "Paquete de redistribucino de .NET 6"

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${SecDatabase} $(DESC_SecDatabase)
!insertmacro MUI_DESCRIPTION_TEXT ${SecNginx} $(DESC_SecNginx)
!insertmacro MUI_DESCRIPTION_TEXT ${SecServer} $(DESC_SecServer)
!insertmacro MUI_DESCRIPTION_TEXT ${SecNssm} $(DESC_SecNssm)
!insertmacro MUI_DESCRIPTION_TEXT ${SecVCRedist} $(DESC_SecVCRedist)
!insertmacro MUI_DESCRIPTION_TEXT ${SecControlPanel} $(DESC_SecControlPanel)
!insertmacro MUI_DESCRIPTION_TEXT ${SecAspNET} $(DESC_SecAspNET)
!insertmacro MUI_FUNCTION_DESCRIPTION_END

; Function finishpageaction
; CreateShortcut "$DESKTOP\foo.lnk" "$INSTDIR\ControlPanel.exe"
; FunctionEnd

; !define MUI_FINISHPAGE_SHOWREADME ""
; !define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
; !define MUI_FINISHPAGE_SHOWREADME_TEXT "Crear acceso directo en el Escritorio"
; !define MUI_FINISHPAGE_SHOWREADME_FUNCTION finishpageaction

; after install register services and start them
Function .oninstsuccess 
    SetOutPath $INSTDIR
    ;register services
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "install" "MariasNginx" "$INSTDIR\nginx\nginx.exe"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasNginx" "SERVICE_AUTO_START"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasNginx"'
; "C:\Users\Michel\Desktop\test\LasMarias\PostgreSQL\bin\pg_ctl.exe" runservice -N " MariasPostgreSQL" -D "C:\Users\Michel\Desktop\test\LasMarias\ C:\Users\Michel\Desktop\test\LasMarias\db_data"
    ExecWait '"$INStDIR\nssm\Win64\nssm.exe" "install" "MariasPostgreSQL" "$INSTDIR\PostgreSQL\bin\pg_ctl.exe" "-D $INSTDIR\PostgreSQL\data"'
    ; ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "set" "MariasPostgreSQL" "PATH="$INSTDIR\PostgreSQL\bin";%PATH%"'
    ; ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "set" "MariasPostgreSQL" "PGDATA="$INSTDIR\PostgreSQL\data"'
    ; ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "set" "MariasPostgreSQL" "PGUSER=marias"'
    ; ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "set" "MariasPostgreSQL" "PGPORT=5433"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasPostgreSQL" "SERVICE_AUTO_START"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasPostgreSQL"'

    ExecWait '"$INStDIR\nssm\Win64\nssm.exe" "install" "MariasBackend" "$INSTDIR\backend\LasMarias.exe"'
    ExecWait '"$INStDIR\nssm\Win64\nssm.exe" "start" "MariasBackend" "SERVICE_AUTO_START"'
    ExecWait '"$INStDIR\nssm\Win64\nssm.exe" "start" "MariasBackend"'

    ExecShell "open" "http://localhost/" SW_SHOWNORMAL
FunctionEnd

Function .onInit
    SetOutPath "$INSTDIR"
    WriteRegStr HKCU "Software\LasMarias" "" $INSTDIR
    WriteUninstaller "$INSTDIR\Uninstall.exe"
FunctionEnd

Section "Uninstall"
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "stop" "MariasNginx"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "remove" "MariasNginx" "confirm"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "stop" "MariasPostgreSQL"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "remove" "MariasPostgreSQL" "confirm"' 
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "stop" "MariasBackend"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "remove" "MariasBackend" "confirm"' 

    Delete "$INSTDIR\Uninstall.exe"
    RMDir /r "$INSTDIR"
    DeleteRegKey /ifempty HKCU "Software\LasMarias"
SectionEnd