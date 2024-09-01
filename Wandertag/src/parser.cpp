#include <cstdlib>
#include <fstream>
#include <iostream>
#include "parser.h"

FileContent parseFile(std::string path) {
    std::ifstream file(path);
    if(!file.is_open() || !file.good()) {
        std::cerr << "Failed to open file '" << path << "'" << std::endl;
        file.close();
        std::exit(1);
    }

    FileContent content;
    file >> content.n;

    int a, b;
    while (file >> a >> b)
        content.values.push_back({a, b});

    if(content.failed()) {
        std::cerr << "Failed to read file '" << path << "'" << std::endl;
        file.close();
        std::exit(1);
    }

    file.close();
    return content; 
}
