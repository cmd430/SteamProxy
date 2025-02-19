# Install
Place `SteamProxy.exe` into steam install dir i.e `C:\Program Files (x86)\Steam` 

# Usage
 * Select the game you want to change the steam exe for in steam
 * Open the game properties
 * Set the `Launch Options` to `SteamProxy.exe --steam=%command% --app=<path>` adding any other args as required
   * Where <path> is the path to the new exe to launch

#### Example using Oblivion:
`SteamProxy.exe --steam=%command% --app=oblivion.exe`

### SteamProxy Args

| Arg               | Description       |
| :---------------- | :---------------- |
| --steam=%command% | Required as is: allows steam to launch the proxy correctly |
| --app=<path> | Required: the path (absolute or relative) to the exe to run |
| --debug | Optional: Output some basic debug text into `SteamProxy.log` in the game dir |

*You may also add any args to be passed along to the new exe at the end
