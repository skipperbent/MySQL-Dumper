# MySQL-Dumper
Command-line tool created in Xamarin C# useful for creating SQL-dumps on remote MySQL-servers using SSH-tunnels.

## Compiling

Please make sure that you have the required dependencies installed in order for Mono to compile on your platform.

`sudo apt-get install git autoconf libtool automake build-essential mono-devel gettext`

Compile to your environment by running the included `build.sh` script.

More information on compiling Mono on Linux availible here:
http://www.mono-project.com/docs/compiling-mono/linux/

## Arguments

### --mysqlhost

Host name for the remote MySQL server.

### --mysqluser

Username for the remote MySQL server.

### --mysqlpass

Password for the remote MySQL server.

### --tunnelhost

Hostname for the SSH-tunnel.

### --tunneluser

Username for the SSH-tunnel.

### --tunnelpass

Password for the SSH-tunnel.

### --outputfile

Output file for the database dump.

### --mysqldb

Database to dump.
