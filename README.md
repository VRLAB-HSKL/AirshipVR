# AirshipVR
ACHTUNG: Das Projekt ist an die räumlichen Gegebenheiten des VRLabors der Hochschule Kaiserslautern Standort Zweibrücken (Juli 2019) angepasst. 
Die Größe des Lusftschiffs wurde auf die des verwendeten Raumes skaliert (ca. 5m Raumdiagonale). 


Dem Projekt ist die Datei KNOWNPROBLEMS.txt begefügt. Diese beschreibt aufgetretene Problem und entsprechende Lösungsansätze oder bisherige Lösungen.


Was würde im Nachhinein anders angegangen:
	- Eigene Physik implementieren
	- Projekt früher mit der entsprechenden Hardware testen, den Simulator nur bedingt verwenden.

Ausblick:
	- Flugmechanik: 
		- Geschwindigkeiten interpolieren
		- Wind- und Strömungswirkung auf das Airship
		- Masse simulieren
		- Veränderbare Geschwindigkeiten 
	- Model des Luftschiffs anpassen
		- Anstelle eines Korbes komplett auf eine Zeppelin Struktur umsteigen.
	- Treibstoff
		- Kein Kohleofen mehr, sondern Gas als Treibstoff 
	- Sound
	- Bedienmöglichkeiten:
		- Weitere Funktionen des Wands nutzen (beispielsweise das Touchpad, um an einem Ventil zu drehen)
		- Allgemein mehr physikalische Interaktionen
			- Anstelle der Knöpfe Seile zum Ziehen
			- Hebel zum Bestimmen der Geschwindigkeit des Luftschiffs
			- etc.
		- Oder, vollständig auf Controller verzichten -> Tracker und reale Objekte zum steuern verwenden
	- Weltgenerierung anpassen:
		- Objekte generieren (Bäume, Felsen, etc.)
	- Tag- Nachtzyklus
	- Nutzer kann das Airship verlassen / Inseln etc. betreten

Externe Ressourcen:

Das Package Terrain des Projekts stammt von folgendem Repository:
https://github.com/SebLague/Procedural-Landmass-Generation

Das Package HTC.UnityPlugin des Projekts stammt aus dem Untiy AssetStore.
