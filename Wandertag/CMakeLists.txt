cmake_minimum_required(VERSION 3.10)

# Projektname
project(Wandertag VERSION 1.0.0 DESCRIPTION "Lösung der Aufgabe Wandertag." LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED True)
set(CMAKE_BUILD_TYPE Release)

# Füge die ausführbare Datei hinzu
add_executable(Wandertag src/main.cpp src/parser.cpp src/parser.h src/algorithm.cpp src/algorithm.h)

# Projektmetadaten
set_property(TARGET Wandertag PROPERTY VERSION ${PROJECT_VERSION})
set_property(TARGET Wandertag PROPERTY DESCRIPTION ${PROJECT_DESCRIPTION})
