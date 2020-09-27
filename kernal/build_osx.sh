mkdir -p build_osx && cd build_osx

cmake -G "Xcode"  ..  &&  cmake --build . --config Debug

cd ..

cp -rf build_osx/Debug/kernal.bundle output/osx/


