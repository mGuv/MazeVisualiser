# MazeVisualiser
Project for taking an Image and outputting visualisations of its structure based off old Unity code I wrote.

Currently very hacked together as I've worked on it for 2 hours and was lazy with comments (as in, I didn't write any)

## Requirements
- Dot Net Core 2.0
- Annoyingly, Windows (As ImageMagick's Dotnet Core version only runs on Windows...)

## Usage
- Build the Project
- dotnet Release\Core.dll pathToImage.png

It'll generate a mess of .pngs in the folder you run it from and then an output.gif

## Direction
- Massively tidy up the image output code
- Tidy up the images created as currently it leaves behind a trail of images on disk
- Make it run in isolated folders to avoid file name collision with successive runs
- Wire in .Net Core's DI
- Allow customisable start locations
- Allow customisable colour gradients
- Allow different path finding (currently hard coding to Dijkstra's)
- Unit tests

