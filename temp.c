#include <mono/metadata/mono-config.h>
#include <mono/metadata/assembly.h>

extern const unsigned char assembly_data_MysqlDumper_exe [];
static const MonoBundledAssembly assembly_bundle_MysqlDumper_exe = {"MysqlDumper.exe", assembly_data_MysqlDumper_exe, 14336};
extern const unsigned char assembly_config_MysqlDumper_exe [];
extern const unsigned char assembly_data_Renci_SshNet_dll [];
static const MonoBundledAssembly assembly_bundle_Renci_SshNet_dll = {"Renci.SshNet.dll", assembly_data_Renci_SshNet_dll, 420864};
extern const unsigned char assembly_data_mscorlib_dll [];
static const MonoBundledAssembly assembly_bundle_mscorlib_dll = {"mscorlib.dll", assembly_data_mscorlib_dll, 3753984};
extern const unsigned char assembly_data_System_dll [];
static const MonoBundledAssembly assembly_bundle_System_dll = {"System.dll", assembly_data_System_dll, 2240000};
extern const unsigned char assembly_data_Mono_Security_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_Security_dll = {"Mono.Security.dll", assembly_data_Mono_Security_dll, 336384};
extern const unsigned char assembly_data_System_Configuration_dll [];
static const MonoBundledAssembly assembly_bundle_System_Configuration_dll = {"System.Configuration.dll", assembly_data_System_Configuration_dll, 129536};
extern const unsigned char assembly_data_System_Xml_dll [];
static const MonoBundledAssembly assembly_bundle_System_Xml_dll = {"System.Xml.dll", assembly_data_System_Xml_dll, 3208192};
extern const unsigned char assembly_data_System_Security_dll [];
static const MonoBundledAssembly assembly_bundle_System_Security_dll = {"System.Security.dll", assembly_data_System_Security_dll, 133120};
extern const unsigned char assembly_data_System_Core_dll [];
static const MonoBundledAssembly assembly_bundle_System_Core_dll = {"System.Core.dll", assembly_data_System_Core_dll, 900096};
extern const unsigned char assembly_data_Mono_Posix_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_Posix_dll = {"Mono.Posix.dll", assembly_data_Mono_Posix_dll, 207872};
extern const unsigned char assembly_data_Microsoft_CSharp_dll [];
static const MonoBundledAssembly assembly_bundle_Microsoft_CSharp_dll = {"Microsoft.CSharp.dll", assembly_data_Microsoft_CSharp_dll, 30720};
extern const unsigned char assembly_data_Mono_CSharp_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_CSharp_dll = {"Mono.CSharp.dll", assembly_data_Mono_CSharp_dll, 1350656};
extern const unsigned char assembly_data_MySql_Data_dll [];
static const MonoBundledAssembly assembly_bundle_MySql_Data_dll = {"MySql.Data.dll", assembly_data_MySql_Data_dll, 457728};
extern const unsigned char assembly_data_System_Data_dll [];
static const MonoBundledAssembly assembly_bundle_System_Data_dll = {"System.Data.dll", assembly_data_System_Data_dll, 2016256};
extern const unsigned char assembly_data_System_Numerics_dll [];
static const MonoBundledAssembly assembly_bundle_System_Numerics_dll = {"System.Numerics.dll", assembly_data_System_Numerics_dll, 53760};
extern const unsigned char assembly_data_System_Transactions_dll [];
static const MonoBundledAssembly assembly_bundle_System_Transactions_dll = {"System.Transactions.dll", assembly_data_System_Transactions_dll, 33280};
extern const unsigned char assembly_data_Mono_Data_Tds_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_Data_Tds_dll = {"Mono.Data.Tds.dll", assembly_data_Mono_Data_Tds_dll, 104448};
extern const unsigned char assembly_data_System_EnterpriseServices_dll [];
static const MonoBundledAssembly assembly_bundle_System_EnterpriseServices_dll = {"System.EnterpriseServices.dll", assembly_data_System_EnterpriseServices_dll, 48128};
extern const unsigned char assembly_data_System_Configuration_Install_dll [];
static const MonoBundledAssembly assembly_bundle_System_Configuration_Install_dll = {"System.Configuration.Install.dll", assembly_data_System_Configuration_Install_dll, 24576};
extern const unsigned char assembly_data_System_Drawing_dll [];
static const MonoBundledAssembly assembly_bundle_System_Drawing_dll = {"System.Drawing.dll", assembly_data_System_Drawing_dll, 452096};
extern const unsigned char assembly_data_System_Management_dll [];
static const MonoBundledAssembly assembly_bundle_System_Management_dll = {"System.Management.dll", assembly_data_System_Management_dll, 50688};
extern const unsigned char assembly_data_MySqlBackup_dll [];
static const MonoBundledAssembly assembly_bundle_MySqlBackup_dll = {"MySqlBackup.dll", assembly_data_MySqlBackup_dll, 63488};
extern const unsigned char assembly_data_ZipStorer_dll [];
static const MonoBundledAssembly assembly_bundle_ZipStorer_dll = {"ZipStorer.dll", assembly_data_ZipStorer_dll, 11776};
extern const unsigned char assembly_data_System_IO_Compression_dll [];
static const MonoBundledAssembly assembly_bundle_System_IO_Compression_dll = {"System.IO.Compression.dll", assembly_data_System_IO_Compression_dll, 101376};

static const MonoBundledAssembly *bundled [] = {
	&assembly_bundle_MysqlDumper_exe,
	&assembly_bundle_Renci_SshNet_dll,
	&assembly_bundle_mscorlib_dll,
	&assembly_bundle_System_dll,
	&assembly_bundle_Mono_Security_dll,
	&assembly_bundle_System_Configuration_dll,
	&assembly_bundle_System_Xml_dll,
	&assembly_bundle_System_Security_dll,
	&assembly_bundle_System_Core_dll,
	&assembly_bundle_Mono_Posix_dll,
	&assembly_bundle_Microsoft_CSharp_dll,
	&assembly_bundle_Mono_CSharp_dll,
	&assembly_bundle_MySql_Data_dll,
	&assembly_bundle_System_Data_dll,
	&assembly_bundle_System_Numerics_dll,
	&assembly_bundle_System_Transactions_dll,
	&assembly_bundle_Mono_Data_Tds_dll,
	&assembly_bundle_System_EnterpriseServices_dll,
	&assembly_bundle_System_Configuration_Install_dll,
	&assembly_bundle_System_Drawing_dll,
	&assembly_bundle_System_Management_dll,
	&assembly_bundle_MySqlBackup_dll,
	&assembly_bundle_ZipStorer_dll,
	&assembly_bundle_System_IO_Compression_dll,
	NULL
};

static char *image_name = "MysqlDumper.exe";

static void install_dll_config_files (void) {

	mono_register_config_for_assembly ("MysqlDumper.exe", assembly_config_MysqlDumper_exe);

}

static const char *config_dir = NULL;
void mono_mkbundle_init ()
{
	install_dll_config_files ();
	mono_register_bundled_assemblies(bundled);
}
int mono_main (int argc, char* argv[]);

#include <stdlib.h>
#include <string.h>
#ifdef _WIN32
#include <windows.h>
#endif

static char **mono_options = NULL;

static int count_mono_options_args (void)
{
	const char *e = getenv ("MONO_BUNDLED_OPTIONS");
	const char *p, *q;
	int i, n;

	if (e == NULL)
		return 0;

	/* Don't bother with any quoting here. It is unlikely one would
	 * want to pass options containing spaces anyway.
	 */

	p = e;
	n = 1;
	while ((q = strchr (p, ' ')) != NULL) {
		n++;
		p = q + 1;
	}

	mono_options = malloc (sizeof (char *) * (n + 1));

	p = e;
	i = 0;
	while ((q = strchr (p, ' ')) != NULL) {
		mono_options[i] = malloc ((q - p) + 1);
		memcpy (mono_options[i], p, q - p);
		mono_options[i][q - p] = '\0';
		i++;
		p = q + 1;
	}
	mono_options[i++] = strdup (p);
	mono_options[i] = NULL;

	return n;
}


int main (int argc, char* argv[])
{
	char **newargs;
	int i, k = 0;

	newargs = (char **) malloc (sizeof (char *) * (argc + 2 + count_mono_options_args ()));

	newargs [k++] = argv [0];

	if (mono_options != NULL) {
		i = 0;
		while (mono_options[i] != NULL)
			newargs[k++] = mono_options[i++];
	}

	newargs [k++] = image_name;

	for (i = 1; i < argc; i++) {
		newargs [k++] = argv [i];
	}
	newargs [k] = NULL;
	
	if (config_dir != NULL && getenv ("MONO_CFG_DIR") == NULL)
		mono_set_dirs (getenv ("MONO_PATH"), config_dir);
	
	mono_mkbundle_init();

	return mono_main (k, newargs);
}
