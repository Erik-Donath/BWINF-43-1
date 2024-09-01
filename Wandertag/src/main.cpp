// Autor: Daniel Hohmann, Helped: Erik Donath
#include <iostream>

#include "parser.h"
#include "algorithm.h"

int main(int argc, char* argv[]) {
    if(argc != 2) {
        std::cout << "Usage: " << argv[0] << " <path/to/file>" << std::endl;
        return 1;
    }

    auto fileContent = parseFile(argv[1]);
    auto result = find_best_distance(fileContent.values);


    std::cout << "Die beste Strecke hat eine Distanz von " << result.distance << "m mit maximal " << result.count << " Teilnehmern." << std::endl;
    return 0;
}
