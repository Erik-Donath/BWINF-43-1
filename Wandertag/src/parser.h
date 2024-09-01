#pragma once
#include <vector>

struct FileContent {
    int n;
    std::vector<std::vector<int>> values;

    inline bool failed() {
        return (n == 0 || values.empty());
    }
};

FileContent parseFile(std::string path);
