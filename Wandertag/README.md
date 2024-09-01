# Wandertag
Einmal im Jahr veranstaltet die Informatik-Gesundheitskasse (IGK) für ihre Mitglieder einen Wandertag. Leider hat sich in den letzten Jahren gezeigt, dass viele Mitglieder nicht teilnehmen wollten, weil die Strecke zu lang oder zu kurz war. <br>
Deshalb hat die Krankenkasse jetzt erstmalig eine Befragung zu dem Wandertag durchgeführt. Jedes Mitglied hat dabei eine minimale und maximale Streckenlänge angegeben: Liegt die Länge der angebotenen Strecke in diesem Bereich, nimmt das Mitglied teil.<br>
Es wird schnell offensichtlich, dass viel mehr Mitglieder teilnehmen, wenn es mehrere unterschiedlich lange Strecken zur Auswahl gibt.<br>

### Aufgabe 3
Unterstütze die IGK bei der Planung und schreibe ein Programm, das drei Streckenlängen so berechnet, dass möglichst viele Mitglieder teilnehmen. Es soll ausgeben, wie viele Mitglieder insgesamt teilnehmen würden und bei welcher Streckenlänge welche Mitglieder teilnehmen könnten. 

# Build & Run
``` bash
cmake -DCMAKE_BUILD_TYPE=Release -S . -B build
cmake --build build
./build/Debug/Wandertag.exe <absolut/path/to/input/file>
```

# Authors
Daniel Hohmann, Erik Donath.
