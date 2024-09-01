cmake_minimum_required(VERSION 3.10)

# Projektname
project(wandertag)

# Setze den Standard-C++-Standard
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED True)

# Füge die ausführbare Datei hinzu
add_executable(wandertag src/main.cpp src/parser.cpp src/parser.h src/algorithm.cpp src/algorithm.h)
