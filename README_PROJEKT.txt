ACHTUNG: Das Projekt ist an die r�umlichen Gegebenheiten des VRLabors der Hochschule Kaiserslautern Standort Zweibr�cken (Juli 2019) angepasst. 
Die Gr��e des Lusftschiffs wurde auf die des verwendeten Raumes skaliert (ca. 5m Raumdiagonale). 


Dem Projekt ist die Datei KNOWNPROBLEMS.txt begef�gt. Diese beschreibt aufgetretene Problem und entsprechende L�sungsans�tze oder bisherige L�sungen.


Was w�rde im Nachhinein anders angegangen:
	- Eigene Physik implementieren
	- Projekt fr�her mit der entsprechenden Hardware testen, den Simulator nur bedingt verwenden.

Ausblick:
	- Flugmechanik: 
		- Geschwindigkeiten interpolieren
		- Wind- und Str�mungswirkung auf das Airship
		- Masse simulieren
		- Ver�nderbare Geschwindigkeiten 
	- Model des Luftschiffs anpassen
		- Anstelle eines Korbes komplett auf eine Zeppelin Struktur umsteigen.
	- Treibstoff
		- Kein Kohleofen mehr, sondern Gas als Treibstoff 
	- Sound
	- Bedienm�glichkeiten:
		- Weitere Funktionen des Wands nutzen (beispielsweise das Touchpad, um an einem Ventil zu drehen)
		- Allgemein mehr physikalische Interaktionen
			- Anstelle der Kn�pfe Seile zum Ziehen
			- Hebel zum Bestimmen der Geschwindigkeit des Luftschiffs
			- etc.
		- Oder, vollst�ndig auf Controller verzichten -> Tracker und reale Objekte zum steuern verwenden
	- Weltgenerierung anpassen:
		- Objekte generieren (B�ume, Felsen, etc.)
	- Tag- Nachtzyklus
	- Nutzer kann das Airship verlassen / Inseln etc. betreten

Externe Ressourcen:

Das Package Terrain des Projekts stammt von folgendem Repository:
https://github.com/SebLague/Procedural-Landmass-Generation

Das Package HTC.UnityPlugin des Projekts stammt aus dem Untiy AssetStore.