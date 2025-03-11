cmake_minimum_required(VERSION 3.19 FATAL_ERROR)
project(Blend2NET C CXX)

set(BLEND2D_NO_INSTALL TRUE)
set(CMAKE_BUILD_TYPE Release)

add_subdirectory(blend2d)

install(
	TARGETS blend2d
	LIBRARY DESTINATION "${CMAKE_INSTALL_PREFIX}/runtimes/${RID}/native"
)