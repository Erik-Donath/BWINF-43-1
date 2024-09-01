#include <vector>
#include <algorithm>
#include "algorithm.h"

Result find_best_distance(const std::vector<std::vector<int>>& intervals) {
    std::vector<std::pair<double, int>> events;
    for (const auto& interval : intervals) {
        events.emplace_back(static_cast<double>(interval[0]), 1); 
	    events.emplace_back(static_cast<double>(interval[1]), -1);
    }

    std::sort(events.begin(), events.end());

    int max_count = 0, current_count = 0;
    double best_distance = 0.0;

    for (const auto& event : events) {
        current_count += event.second;
        if (current_count > max_count) {
            max_count = current_count;
            best_distance = event.first;
        }
    }

    return { best_distance, max_count };
}