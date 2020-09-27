mkdir build_win64 & pushd build_win64 
cmake -G "Visual Studio 16 2019"  ..  &&  cmake --build . --config Release
cd ..
copy /Y build_win64\Release\kernal.dll output\x86_64\kernal.dll
copy /Y build_win64\Release\kernal.lib output\x86_64\kernal.lib
