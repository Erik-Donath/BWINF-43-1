// Autor: Daniel Hohmann, Helped: Erik Donath
#include <iostream>
#include <chrono>

#include "parser.h"
#include "algorithm.h"

#define now() std::chrono::system_clock::now()
#define duration(cast, time) std::chrono::duration_cast<cast>(time).count()

int main(int argc, char* argv[]) {
    if(argc != 2) {
        std::cout << "Usage: " << argv[0] << " <path/to/file>" << std::endl;
        return 1;
    }

    auto fileContent = parseFile(argv[1]);
    auto start = now();
    auto result = find_best_distance(fileContent.values);
    auto time = now() - start;

    std::cout << "Die beste Strecke hat eine Distanz von " << result.distance << "m mit maximal " << result.count << " Teilnehmern." << std::endl;
    std::cout << "Der Algorythmus hat " << duration(std::chrono::nanoseconds, time) << "ns (" << duration(std::chrono::milliseconds, time) << "ms) gebraucht." << std::endl;
    return 0;
}
