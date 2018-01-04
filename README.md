# Get Out : a VR escape game

Get Out! You wake up locked up in a strange room which seems abandoned for a while. No way to know where you are, and all exits are locked off. You're stucked here. Unless... An old TV learns you to interact with your environment : look for the hints, discover the room secrets and solve the puzzles ! Will you finally get out ?

![](image.png?raw=true)

## Play the game

GetOut is an escape game made with Unity made for the RV01 course in UTC (Virtual Reality initiation). Your goal is to get out of the room by solving puzzles.

It has been tested with an HTC Vive. To play the game, just open the project with Unity, load the main scene, make sur that the `PCSpecific` game object is **disabled** and that the `VRSpecific` game object is **enabled**.

The game is also playable on PC with minor ergonomic issues, such as the impossibility of moving objects vertically without jumping. This mode is essentially available for testing and development purpose. To enable it, just enable `PCSpecific` and disable `VRSpecific`.

## Controls

The minidoc PDF in root directory shows how to play the game VR (in french). To sum up :
* The right controller is used for interacting and the left to move.
* Point and click an objet surrounding with a halo to get informations from it. Touch it to use it. Touch it and hold the trigger button to move it.
* Use the left controller pad to move, or just walk.

Note there is a tutorial ingame to learn these steps.

On PC, things are different but feel free to choose whatever configuration you want in the input manager. Currently, Z = top, S = bottom, Q = left, D = right. Left click to observe, right click to use, and middle click or t to take. Additionnal jump capability is provided with the space key, and classic walking / moving down is provided with the FPSController standard asset.

## Framework

A micro framework has been build to speed up development and remove tightly coupling of objects in game. It manages interactions and events. See the report in the root directory (in french) for more details.

Credits to jobro for piano sounds ( https://freesound.org/people/jobro/packs/2489/ ). All sounds of this pack are used.
