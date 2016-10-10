#!/bin/bash

# Notes:
# You will need the Mono SDK 3.x series as the 2.x SDK cannot build for 64bit architectures.
# It appears that Mono 3.x still cannot compile for 64bit without having to manually compile Mono yourself.
# Since we don't strictly need 64bit support the below forces a 32bit build.

# Ensure it can find pkg-config:
export PKG_CONFIG_PATH=$PKG_CONFIG_PATH:/usr/lib/pkgconfig:/Library/Frameworks/Mono.framework/Versions/3.4.0/lib/pkgconfig

# Force 32bit build and manually set some clang linker properties:
export AS="as -arch i386"
export CC="cc -arch i386 -lobjc -liconv -framework Foundation"

# Build:
mkbundle MysqlDumper/bin/Release/MysqlDumper.exe --static -o MysqlDumper/bin/Release/MysqlDumper MysqlDumper/bin/Release/*.dll mscorlib.dll System.dll System.Data.dll System.Core.dll System.IO.Compression.dll --deps
