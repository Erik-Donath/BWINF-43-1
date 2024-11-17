
# Lösungsidee

Das Ziel ist eine Gartenfläche in möglichst Quadratische Kleingärten zu unterteilen. 

## Definition von Quadratisch
Zu erst muss eine Definition des Begriffes Quadratisch beschrieben werden. Quadratisch ist das Verhältnis von der kleinen Seite zur großen Seite. Sollte dieses 1 sein, so ist das gegebene Rechteck zu 100% Quadratisch. Der Mathematische Ausdruck lautet wie folgt:
<br>$s(b,h)=\frac{min(b,h)}{max(b,h)}$<br>
b und h beschreiben die Breite und Höhe des Rechtecks und sind immer positiv. Der Funktionswert von s kann zwischen 0 und 1 sein.
## Suchstrategie
Die Suche nach der optimalen Aufteilung ist die Suche nach dem maximalen Funktionswert von s. Hierfür suchen wir in einem Interval von $I=[n;n\cdot1.1]$. Wobei n die Anzahl an Interessenten ist. Für jede mögliche Anzahl werden alle gültigen Kombinationen von Reihen und Spalten untersucht.

Hierbei wird wie folgt vorgegangen:
1. Gehe durch das Interval mit Schrittweite 1. Dies ist die momentane Anzahl der plots
2. Gehe durch alle möglichen Anzahlen an Reihen von 1 zu momentane Anzahl der plots + 1, welche Teiler dieser Anzahl an Plots sind.
3. Berechne für jede Reihe die Anzahl an möglichen Spalten.
4. Bestimme die Breite und Höhe eines einzelnen Plots.
5. Merke dir die Höhe und Breite.
6. Nachdem das Interval untersucht wurde, sortiere die gemerkten Plots nach ihrer Quadratförmigkeit.
7. Die ersten drei Plots nach der Sortierung sind das Ergebnis.

Der  Mathematisch Ausdruck hierfür währe wie folgt:
<br>$max_{n,r} \{  s( \frac{W}{c},\frac{H}{r} ) \space|\space n_{min} \leq n\leq n_{max},c=\frac{r}{n}\}$<br>
Wobei:
- $n$ die Plot Anzahl ist
- $r$ die Anzahl der Reihen ist
- $c$ die Anzahl der Spalten ist
- $W$ die Gesamtbreite ist
- $H$ die Gesamthöhe ist
- $n_{min}$ und $n_{max}$ die Intervalgrenzen sind

Die Formel beschreibt die Suche nach der Kombination von Plot Anzahl und Reihen Anzahl, die die höchste Quadratförmigkeit ergibt, unter Berücksichtigung der Randbedingungen.

# Umsetzung

...
# Beispiel

...
# Quellcode

```python
class GardenPlotter:
    def _init_(self, width, height, interested):
        self.total_width = width
        self.total_height = height
        self.min_plots = interested
        self.max_plots = int(interested * 1.1)

    def calculate_squareness(self, width, height):
        return min(width, height) / max(width, height)

    def find_best_division(self):
        best_squareness = 0
        best_division = None

        for plots in range(self.min_plots, self.max_plots + 1):
            for rows in range(1, plots + 1):
                if plots % rows == 0:
                    cols = plots // rows

                    plot_width = self.total_width / cols
                    plot_height = self.total_height / rows

                    squareness = self.calculate_squareness(plot_width, plot_height)

                    if squareness > best_squareness:
                        best_squareness = squareness
                        best_division = {
                            'rows': rows,
                            'cols': cols,
                            'total_plots': plots,
                            'plot_width': plot_width,
                            'plot_height': plot_height,
                            'squareness': squareness
                        }

        return best_division
```

**Für calculate_squareness(w, h) gilt:**

$\text{Zeitkomplexität: } O(1)$
$\text{Mathematischer Ausdruck: }s(w,h)=\frac{min(w, h)}{max(w, h)}$

**Für find_best_division() gilt:**

$\text{Zeitkomplexität: } O(n^{2})$
$\text{Mathematischer Ausdruck: }$

$\text{1. Menge der möglichen Plotanzahlen:}$
$P=\{p \in \mathbb{N} \space| \space min\_plots \leq p\leq max\_plots\}$

$\text{2. Für jedes } p \in P \text{, ist die Menge der möglichen Reihenzahlen:}$
$R_{p}=\{r \in \mathbb{N} \space| \space 1 \leq p \text{ und }p \space mod \space r = 0 \}$
$\text{3. Berechne für jede Kombination } (p,r) \text{ die Spantenzahl } c=\frac{p}{r} \text{ und die Plotdimensionen: }$
$w=\frac{total\_width}{c}, h=\frac{total\_height}{r}$

$\text{4. Berechne die Quadratförmigkeit für jede Kompination: }$
$s(w,h)=\frac{min(w, h)}{max(w, h)}$
$\text{5. Finde die optimale Aufteilung: }$
$best\_division=\max{s(p,r)}\space |\space p\in P, r\in R_{p}$
