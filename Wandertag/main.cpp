// Autor: Daniel Hohmann
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>

std::pair<int, std::vector<std::vector<int>>> readfromfile(const std::string& filePath) {
    std::ifstream file(filePath);
    if (!file.is_open()) {
        std::cerr << "Konnte die Datei nicht öffnen! Pfad: " << filePath << std::endl;
        return std::make_pair(0, std::vector<std::vector<int>>{});
    }

    int n;
    file >> n;

    std::vector<std::vector<int>> werte;
    int a, b;
    while (file >> a >> b) { 
        werte.push_back({a, b});
    }

    file.close();
    return std::make_pair(n, werte); 
}

std::pair<double, int> find_best_distance(const std::vector<std::vector<int>>& intervals) {
    // Erzeuge eine Liste von Ereignissen (Start- und Endpunkte der Intervalle)
    std::vector<std::pair<double, int>> events;
    for (const auto& interval : intervals) {
        events.emplace_back(static_cast<double>(interval[0]), 1); 
	events.emplace_back(static_cast<double>(interval[1]), -1);     }

    // Sortiere die Ereignisse
    std::sort(events.begin(), events.end());

    int max_count = 0;
    int current_count = 0;
    double best_distance = 0.0;

    // Gehe durch die sortierten Ereignisse
    for (const auto& event : events) {
        current_count += event.second;
        if (current_count > max_count) {
            max_count = current_count;
            best_distance = event.first;
        }
    }

    return std::make_pair(best_distance, max_count);
}

int main() {
    std::string filePath = "../aufgaben/wandern1.txt"; // alternativer pfad zu der file
    auto result = readfromfile(filePath);
    int n = result.first;
    auto werte = result.second;

    if (n == 0 && werte.empty()) {
        std::cerr << "Fehler beim Lesen der Datei." << std::endl;
        return 1;
    }

    // Berechne die beste Strecke
    auto best_result = find_best_distance(werte);
    double best_distance = best_result.first;
    int max_count = best_result.second;

    // Ausgabe der besten Strecke
    std::cout << "Die beste Strecke ist: " << best_distance << " mit maximal " << max_count << " Teilnehmern." << std::endl;

    return 0;
}

