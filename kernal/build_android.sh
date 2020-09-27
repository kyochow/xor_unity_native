if [ -n "$ANDROID_NDK" ]; then
    export NDK=${ANDROID_NDK}
elif [ -n "$ANDROID_NDK_HOME" ]; then
    export NDK=${ANDROID_NDK_HOME}
elif [ -n "$ANDROID_NDK_HOME" ]; then
    export NDK=${ANDROID_NDK_HOME}
else
    export NDK=/Applications/Unity/Hub/Editor/2019.4.0f1/PlaybackEngines/AndroidPlayer/NDK
fi

if [ ! -d "$NDK" ]; then
    echo "Please set ANDROID_NDK environment to the root of NDK."
    exit 1
fi

function build() {
    API=$1
    ABI=$2
    TOOLCHAIN_ANME=$3
    BUILD_PATH=build_android_${ABI}
    cmake -H. -B${BUILD_PATH} -DANDROID_ABI=${ABI} -DCMAKE_TOOLCHAIN_FILE=${NDK}/build/cmake/android.toolchain.cmake -DANDROID_NATIVE_API_LEVEL=${API} -DANDROID_TOOLCHAIN=clang -DANDROID_TOOLCHAIN_NAME=${TOOLCHAIN_ANME}
    cmake --build ${BUILD_PATH} --config Release
    cp ${BUILD_PATH}/libkernal.so output/android/libs/${ABI}/libkernal.so
#    cp ${BUILD_PATH}/libkernal.so ../unity/Assets/Plugins/kernal/Android/libs/${ABI}/libkernal.so
}

build android-16 armeabi-v7a arm-linux-androideabi-4.9
build android-16 arm64-v8a  arm-linux-androideabi-clang
build android-16 x86 x86-4.9