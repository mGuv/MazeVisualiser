# MazeVisualiser
Project for taking an Image and outputting visualisations of its structure based off old Unity code I wrote.

Currently very hacked together as I've worked on it for 2 hours and was lazy with comments (as in, I didn't write any)

## Requirements
- Dot Net Core 2.0
- Annoyingly, Windows (As ImageMagick's Dotnet Core version only runs on Windows...)

## Usage
- Build the Project
- dotnet Release\Core.dll pathToImage.png

It'll then output the order of pixels it expanded to the command window.

