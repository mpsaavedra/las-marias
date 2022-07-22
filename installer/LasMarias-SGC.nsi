!include "MUI2.nsh"
Name "Sistema de Gestion - Hotel & Resort Las Maria's"
OutFile "SGC-LasMarias.exe"
Unicode true
InstallDir "$LOCALAPPDATA\LasMarias"
InstallDirRegKey HKCU "Software\LasMarias" ""
RequestExecutionLevel admin

!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Header\nsis.bmp"
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
    ; FileOpen $9 "$INSTDIR\PostgreSQL\pg_env.bat" w 
    ; FileWrite $9 "@ECHO OFF\r$\n"
    ; FileWrite $9 "REM The script sets environment variables helpful for PostgreSQL\r$\r$\n"
    ; FileWrite $9 @SET PATH="$INSTDIR\PostgreSQL\bin";%PATH%\r$\n"
    ; FileWrite $9 @SET PGDATA="$INSTDIR\PostgreSQL\data"\r$\n"
    ; FileWrite $9 @SET PGDATABASE=postgres"\r$\n"
    ; FileWrite $9 @SET PGUSER=marias"\r$\n"
    ; FileWrite $9 @SET PGPORT=5433"\r$\n"
    ; FileWrite $9 @SET PGLOCALEDIR=$INSTDIR\share\locale"\r$\n"
    ; FileClose $9 ;Closes the filled file
SectionEnd

Section "NginX (Servidor Web)" SecNginx
    File /nonfatal /r "components\nginx"
SectionEnd

Section "Panel de control" SecControlPanel
    ; register so we launch control panel at startup
;   WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Run" "Notepad" "$WinDir\Notepad.exe"
SectionEnd

Section "Sistema Gestor Principal" SecServer
SectionEnd

Section "Nssm (Gestor de Servicios)" SecNssm
    File /nonfatal /r "components\nssm"
SectionEnd

Section "vcredist" SecVCRedist
    File /nonfatal /r "components\nssm"
SectionEnd

LangString DESC_SecDatabase ${LANG_SPANISH} "Servidor de base de datos."
LangString DESC_SecNginx ${LANG_SPANISH} "Servidor web y proxy inverso."
LangString DESC_SecServer ${LANG_SPANISH} "Servidor de backend de API."
LangString DESC_SecNssm ${LANG_SPANISH} "Gestor de servicios de windows."
LangString DESC_SecVCRedist ${LANG_SPANISH} "Paquete de redistribucion de VC++."
LangString DESC_SecControlPanel ${LANG_SPANISH} "Panel de control de servicios."

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${SecDatabase} $(DESC_SecDatabase)
!insertmacro MUI_DESCRIPTION_TEXT ${SecNginx} $(DESC_SecNginx)
!insertmacro MUI_DESCRIPTION_TEXT ${SecServer} $(DESC_SecServer)
!insertmacro MUI_DESCRIPTION_TEXT ${SecNssm} $(DESC_SecNssm)
!insertmacro MUI_DESCRIPTION_TEXT ${SecVCRedist} $(DESC_SecVCRedist)
!insertmacro MUI_DESCRIPTION_TEXT ${SecControlPanel} $(DESC_SecControlPanel)
!insertmacro MUI_FUNCTION_DESCRIPTION_END


; launch
Function .oninstsuccess 
    SetOutPath $INSTDIR
    ;register services
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "install" "MariasNginx" "$INSTDIR\nginx\nginx.exe"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasNginx"'
    ExecWait '"$INSTDIR\PostgreSQL\bin\pg_ctl.exe" "register" "-N MariasPostgreSQL"  "-D $INSTDIR\db_data"'
    ExecWait '"$INSTDIR\nssm\Win64\nssm.exe" "start" "MariasPostgreSQL"'

;    ShellExecAsUser::ShellExecAsUser "" "$INSTDIR\Application.exe" ""
    ; Exec '"$WinDir\Notepad.exe"'
    ExecShell "open" "http://localhost/" SW_SHOWNORMAL
    ; ExecWait '"$WinDir\Notepad.exe"'
    ; ExecWait '"$instdir\myapp.exe"'
    ; Exec '"$instdir\otherapp.exe" param1 "par am 2" param3'
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

    Delete "$INSTDIR\Uninstall.exe"
    RMDir /r "$INSTDIR"
    DeleteRegKey /ifempty HKCU "Software\LasMarias"
SectionEnd