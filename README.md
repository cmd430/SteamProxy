# Install
Place `SteamProxy.exe` into steam install dir i.e `C:\Program Files (x86)\Steam` 

# Usage
 * Select the game you want to change the steam exe for in steam
 * Open the game properties
 * Set the `Launch Options` to `SteamProxy.exe --steam=%command% --app=<path>` adding any other args as required
   * Where <path> is the path to the new exe to launch

> [!TIP]
> #### using OBSE for Oblivion:
> `SteamProxy --steam=%command% --app=obse_loader.exe`
> #### using OBSE64 for Oblivion Remaster:
> `SteamProxy --steam=%command% --app=obse64_loader.exe --ue5`
> #### using OBSE64 for MO2 profile for Oblivion Remaster using OBSE64:
> `SteamProxy --steam=%command% --mo2="c:\modding\MO2\ModOrganizer.exe|Oblivion Remastered:OBSE64"`

### SteamProxy Args

| Arg                 | Description                                                                        | Notes            |
| :------------------ | :--------------------------------------------------------------------------------- | :--------------- |
| `--steam=%command%` | Allows steam to launch the proxy correctly                                         | Required - First |
| `--app=<path>`      | The path (absolute or relative) to the exe to run                                  | Required*        |
| `--mo2=<path>\|<profile:app>`| The path to mod orgainizer 2s exe followed by the profile and app to load | Required*        |
| `--ue5`             | Changes the base path to the games `Binaries\Win64\` directory                     | Optional^        |
| `--debug`           | Output some basic debug text into `SteamProxy.log` in the game dir                 | Optional         |

> [!CAUTION]  
> *You must only use either `--app=<path>` OR `--mo2=<path>|<profile:app>` not both!

> [!WARNING]  
> ^You shouldn't use `--ue5` with `--mo2=<path>|<profile:app>`

> [!NOTE]
> You may also add any args to be passed along to the new exe at the end
