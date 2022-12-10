# Sokoban--Unity3D-2022 :

Game made during my bachelor 3 year (2022/2023) for a Unity3D module at Ynov Bordeaux.

## Summary :

- Presentation
- Game keys
- Main mechanics
- How to open the project
- How to build the project

## Presentation :

In this **sokoban** type game, your goal is to move your character to **push the crates to reach the markers** on the ground. Once **all the crates are placed on the ground**, you have **won**.

![](https://i.imgur.com/YPw64Ak.png)

![](https://i.imgur.com/02rAoQ2.png)

![](https://i.imgur.com/IIX2rid.png)

![](https://i.imgur.com/XMLKYB5.png)

## Game keys :

- _Movement_:

  - Move forward: **Z**
  - Move to the left: **Q**
  - Move to the right: **D**
  - Move downward: **S**

- _Back to the past_:
  - Arrow-shaped interface **button** located at the bottom left of the screen.

## Main mechanics :

### Move the boxes :

In order to move a crate, you must move your character into a crate next to it and move towards the crate in the direction you wish to move it. Crates can't go through walls and you can't push 2 crates at the same time.

### Go back in time :

If you didn't push the crate in the right direction or if you made a blocking move, you can go back in time to the previous step and restart your move with the Undo button located at the bottom left of the game.

## How to open the project :

- Clone the git repository to your computer with the following command :

```
git@github.com:LeoSery/Sokoban--Unity3D-2022.git
```

or

```
https://github.com/LeoSery/Sokoban--Unity3D-2022.git
```

- open Unity Hub and do "_Add project from disk_"

  Select "`..\Sokoban--Unity3D-2022`"

- Check that the project opens with the Unity editor in version "**2022.1.21f1**"

## How to build the project :

- Once the project is open in Unity, do _"File" > "Build Settings"_

- In the window that has just appeared, in the _"Scenes In Build"_ section, make sure that _"scenes/Game"_ is checked.

- for the platform choose: _"PC, Mac & Linux Standalone"_

- then choose your platform in _"Target Platform"_

- and finally press _"Build And Run"_
