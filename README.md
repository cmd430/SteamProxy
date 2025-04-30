# Install
Place `SteamProxy.exe` into steam install dir i.e `C:\Program Files (x86)\Steam` 

# Usage
 * Select the game you want to change the steam exe for in steam
 * Open the game properties
 * Set the `Launch Options` to `SteamProxy.exe --steam=%command% --app=<path>` adding any other args as required
   * Where <path> is the path to the new exe to launch

#### Example using OBSE for Oblivion:
`SteamProxy --steam=%command% --app=obse_loader.exe`

#### Another Example using OBSE64 for Oblivion Remaster:
`SteamProxy --steam=%command% --app=obse64_loader.exe --ue5`

### SteamProxy Args

| Arg                 | Description                                                        | Notes            |
| :------------------ | :----------------------------------------------------------------- | :--------------- |
| `--steam=%command%` | Allows steam to launch the proxy correctly                         | Required - First |
| `--app=<path>`      | The path (absolute or relative) to the exe to run                  | Required         |
| `--ue5`             | Changes the base path to the games `Binaries\Win64\` directory     | Optional         |
| `--debug`           | Output some basic debug text into `SteamProxy.log` in the game dir | Optional         |

*You may also add any args to be passed along to the new exe at the end
