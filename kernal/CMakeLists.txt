CMAKE_MINIMUM_REQUIRED(VERSION 2.6)

PROJECT(kernal)

AUX_SOURCE_DIRECTORY(src/. SRC_LIST)

FILE(GLOB_RECURSE HEADER_LIST  src/*.h )
source_group("Header Files" FILES ${HEADER_LIST}) 

if ( WIN32 AND NOT CYGWIN AND NOT ( CMAKE_SYSTEM_NAME STREQUAL "WindowsStore" ) )
    set(CMAKE_C_FLAGS_RELEASE "${CMAKE_C_FLAGS_RELEASE} /MT" CACHE STRING "")
    set(CMAKE_C_FLAGS_DEBUG "${CMAKE_C_FLAGS_DEBUG} /MTd" CACHE STRING "")
    set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /MT" CACHE STRING "")
    set(CMAKE_CXX_FLAGS_DEBUG "${CMAKE_CXX_FLAGS_DEBUG} /MTd" CACHE STRING "")
    set(CompilerFlags
            CMAKE_CXX_FLAGS_DEBUG
            CMAKE_CXX_FLAGS_RELEASE
            CMAKE_C_FLAGS_DEBUG
            CMAKE_C_FLAGS_RELEASE
            )
    foreach(CompilerFlag ${CompilerFlags})
        string(REPLACE "/MD" "/MT" ${CompilerFlag} "${${CompilerFlag}}")
    endforeach()
endif ()

if (APPLE)
    if (IOS)
    	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -fembed-bitcode")
        set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -fembed-bitcode")
    	ADD_Library(kernal  ${HEADER_LIST} ${SRC_LIST} )
		set_xcode_property (kernal IPHONEOS_DEPLOYMENT_TARGET "7.0" "all")
    else ()
		ADD_Library(kernal  MODULE ${HEADER_LIST} ${SRC_LIST} )
		set_target_properties(kernal PROPERTIES BUNDLE TRUE)
	endif ()
elseif (ANDROID)
	ADD_Library(kernal SHARED ${HEADER_LIST} ${SRC_LIST} )
else ()
	ADD_Library(kernal MODULE ${HEADER_LIST} ${SRC_LIST} )
	set_target_properties(kernal PROPERTIES BUNDLE TRUE)
endif ()