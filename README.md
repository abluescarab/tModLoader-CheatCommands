# Cheat Commands
Adds a bunch of cheat commands to **single-player** games.

## Command Reference
### Multicommands
```
/mc <name>                                  run a multicommand
```
### NPC Commands
```
/killall [friendly/hostile]                 kill all NPCs
/kill <type/name>                           kill an NPC
/spawn <type/name> [x] [y] [amount]         spawn an NPC
```
### Player Commands
```
/buff <type/name> [time]                    add a buff
/removebuff <type/name>                     remove a buff
/coins <platinum> <gold> <silver> <copper>  give yourself money
/give <type/name> [amount]                  give yourself an item
/god                                        toggle god mode
/ammo                                       toggle infinite ammo
/respawn                                    respawn your character
/pos                                        get your current coordinates
/tp                                         teleport to a coordinate or player
```
#### Home Commands
```
/sethome                                    add a home location
/delhome                                    remove a home location
/clearhomes                                 remove homes from the world or all worlds
/home                                       teleport to a named home location
/homes                                      list available homes in the world
```
### World Commands
```
/freeze                                     toggle freezing time
/setspawn                                   set world spawn to your location
/settle                                     settle liquids
/time                                       change world time
```
## Credits
* jopojelly for code modified for the `killall` command
* tModLoader's ExampleMod for code modified for the `spawn` command
