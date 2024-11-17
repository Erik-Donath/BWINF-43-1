import sys
import matplotlib.pyplot as plt
from matplotlib.patches import Rectangle


class GardenPlotter:
    def __init__(self, width, height, interested):
        self.total_width = width
        self.total_height = height
        self.min_plots = interested
        self.max_plots = int(interested * 1.1)  # 10% mehr als Minimum

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

    def plot_division(self, division):
        fig, ax = plt.subplots(figsize=(10, 8))
        ax.set_xlim(0, self.total_width)
        ax.set_ylim(0, self.total_height)

        # Zeichne jeden Kleingarten
        for row in range(division['rows']):
            for col in range(division['cols']):
                x = col * division['plot_width']
                y = row * division['plot_height']
                rect = Rectangle((x, y), division['plot_width'], division['plot_height'],
                                 fill=False, edgecolor='green')
                ax.add_patch(rect)

        # Beschriftung
        plt.title(f"Kleingarten-Aufteilung\n{division['rows']}x{division['cols']} = {division['total_plots']} Gärten")
        plt.xlabel(f"Breite: {self.total_width}m")
        plt.ylabel(f"Länge: {self.total_height}m")

        # Zeige die Größe eines einzelnen Gartens an
        plt.text(self.total_width / 2, -self.total_height / 20,
                 f"Gartengröße: {division['plot_width']:.2f}m x {division['plot_height']:.2f}m\n"
                 f"Quadratischkeit: {division['squareness'] * 100:.1f}%",
                 ha='center')

        plt.axis('equal')
        plt.show()


def main():
    if len(sys.argv) >= 2:
        print(f"Lade Daten von: {sys.argv[1]}")
        with open(sys.argv[1], 'r') as f:
            lines = f.readlines()[:3]
            interested = int(lines[0])
            height = int(lines[1])
            width = int(lines[2])

        print(f"Interessenten: {interested}\nHöhe: {height}\nBreite: {width}")
    else:
        interested = int(input("Geben Sie die Anzahl der Interessenten ein: "))
        height = float(input("Geben Sie die Länge des Grundstücks in Metern ein: "))
        width = float(input("Geben Sie die Breite des Grundstücks in Metern ein: "))

    # Berechnung und Visualisierung
    plotter = GardenPlotter(width, height, interested)
    best_division = plotter.find_best_division()

    # Ausgabe der Ergebnisse
    print(f"\nBeste Aufteilung gefunden:")
    print(f"Anzahl der Kleingärten: {best_division['total_plots']} "
          f"({best_division['rows']} Reihen x {best_division['cols']} Spalten)")
    print(f"Größe jedes Kleingartens: {best_division['plot_width']:.2f}m x "
          f"{best_division['plot_height']:.2f}m")
    print(f"Quadratischkeit: {best_division['squareness'] * 100:.1f}% "
          f"(100% wäre ein perfektes Quadrat)")

    # Zeichne die Aufteilung
    plotter.plot_division(best_division)


if __name__ == "__main__":
    main()
