
<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

# Vorlesung 1
## CAS - (Complex Adaptive Systems)
- mehrere zusammenhängende Elemente
- adaptiv (Anpassungsvermögen an Umfeld)
- Aus Erfahrung lernend

#### Links
- Buch: Kompexität von Klaus Mainzer
- An Introduction to Multiagent Systems - Michael Wooldridge. John Wiley & Sons 2009+
- Multiagent Systems: A modern approach
- Multiagent Systems: Algorithmic, Game-Theoretic and Lofical Foundations


## Notes
deklarativ vs iterativ programmieren
Große Systeme != Komplexe Systeme
Agenten: Interne Verarbeitung, Externe Wahrnehmung
bdi - beliefs-desires-intention
Multiagentensysteme - Bottom Up, Sozialität, Kohärenz
Preis der Anarchie: Verhältnis zwischen keine Absprache und vollkommene Vorabsprache
**Lineare-Systeme:**
zum Faktor \*n
Beispiel: 2*Rauschen auf 2*Sinuskurve
**Nicht-Lineare-Systeme:**
zum Faktor ^n
Beispiel: Rauschen² auf Sinuskurve²

#### Agentenentscheidungen
- 1: ad-hoc
- 2: Regelwerke (Komplexität der Regeln * Anzahl der Regeln)
- 3: Adaption

#### Nutzen
Belohnungsbilanz mit Regeln/Belohnungsbilanz ohne Regeln

## Sprachen
- Logo
- Net Logo

# Vorlesung 2
#### Offene Fragen:
- Heuristik vs V-Wert
- Bibliotheken für verwendbare Algorithmen durchforsten
#### Masterfrage:
- Wie sollten Regeln strukturiert sein?
- Wie sollte das Regelwerk aussehen
- Wie groß ist der Nutzen des Regelwerks?
Belohnungsbilanz mit Regeln/Belohnungsbilanz ohne Regeln

#### Vorgehensweise
Regelwerke vs learning
1. Regelwerk KI implementieren
- Regelkomplexität: relativ
- Regelwerkkomplexität: mit Baumstruktur for log(n) Komplexität statt 2^n
- Rechenaufwand: Agenten * Regelkomplexität
Wie werden Regeln implementiert/realisiert?

2. Adaption

3. agent beliefs desires intentions bdi?

# Vorlesung 3
https://www.cs.cornell.edu/home/kleinber/networks-book/
Vergeben: 3,4, 18
Gewählt: 5 - Positive and Negative Relationships 20min vortrag

Schachbrett ->von neumann umgebung
->von nuhr umgebung googeln

idee: züge vorausberechnen gegen ressourcen pro vorhergesehener aktion
Agenten haben: Sensoren füttern Planungskomponente, dieses importiert Regelwerk und trifft daraufgehend Entscheidungen. Sensoren und Planungskomponente können Parameter für Regelwerk anpassen
Planung limitieren: Planungsressourcen bereitstellen und nach Verbrauch Planen beenden und erfolgversprechensten Pfad - Aktion wählen

verhandlungen: erfahrungen anhand vorheriger aktion des gegenübers
-> tit for tat (kooperieren vs lügen)
Prägung durch Grundeinstellung + Umgebung + (Änderung der Grundeinstellung durch Umegbung)

evolution: eltern mit besseren regeln kriegen mehr kinder -> es existieren öfter die besseren regeln

# Vorlesung 4
Graph mit Ressourcenbalance(Gewinn/Verlust) Y vs Regelmenge X
Quantifizieren -> Regeliteration/Aktion/Plan mit Kosten belegen
Frage: Wie kriege ich Messwerte? (Graphen?)
      Wie gehe ich dabei vor?
      Listener Methoden
      Wie logge ich die Daten?
      Wo werden sie aus dem Code abgegriffen

# Vorlesung 5
Hemmschwelle zur Übernahme
Achte auf alle verbundenen Knoten/Nachbarn
Ermittle das Verhältnis von Fraktion Y zu Gesamtnachbarn
Wenn Hemmschwelle q < Verhältnis, dann Wechsel
q = Y/(Gesamt-Y)

Vergleiche in Anzahl als Komplexität des Regelwerks
Staffelung der dynamisch generierten Agenten anhand Anzahl verwendeter regeln
Regeln auffächern für partielle Anwendungen

Regeln kriegen eine statische ID
Zu Beginn generieren Agenten zufällige Listen von true/false entsprechend der Größe
des Regelwerks. (Ausbau zu Baum? Kann man Regeln in Listen/Bäumen übergeben?)
Nach einigen Durchläufen wird die Effizienz der Regelauswahl bestimmt (Durchschnitt)
Es könnte eine Selektion stattfinden
Optional?: Reihenfolge der Regeln variabel

Todo: Regelwerk feingranular modularisieren
      Regeln mit Id's versehen
      Regelwerke können nach Zufall generiert werden
      Regelwerke können bewertet werden
      Regelwerke können verglichen werden

Zusatz:
Fraktionsübergreifende Abmachungen anhand globaler Regeln.
- z.B. nicht Angriffspakt
- In welchen Fällen rentieren sich Kooperationen? (nicht)
- Kooperationen kosten ebenfalls
