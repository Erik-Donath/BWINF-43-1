#pragma once
#include <vector>

struct Result {
    double distance;
    int count;
};

Result find_best_distance(const std::vector<std::vector<int>>& intervals);
