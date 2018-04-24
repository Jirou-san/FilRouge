Commande à exécuter en admin sur le serveur IIS en cas d'erreur 500.19 Error Code 0x80070021
%windir%\system32\inetsrv\appcmd.exe unlock config -section:system.webServer/handlers
(source : https://forums.iis.net/t/1155232.aspx?HTTP+Error+500+19+Internal+Server+Error+0x80070021+Lock+Violation+with+OWA+Exchange+2007)