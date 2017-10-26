# MazeVisualiser
Project for taking an Image and outputting visualisations of its structure based off old Unity code I wrote.

## Requirements
- Dot Net Core 2.0
- Annoyingly, Windows (As ImageMagick's Dotnet Core version only runs on Windows currently)

## Usage
- Install .Net Core 2.0
- Checkout the project
- Build the project in your IDE/process of choice
- Run: dotnet outputPath\Core.dll somePath\image.png
-- You can optionally add '-a=astar' to change the algorithm to A*, if not specified it defaults to Dijkstra

It'll generate a mess of .pngs in the folder you run it from and then an output.gif

## Note
- It's hard coded to use a Rainbow Gradient at the moment
- It's hard coded to start from the very top left pixel
- It's hard coded to only detect EXACTLY black pixels as wall

## Direction
- Massively tidy up the image output code
- Tidy up the images created as currently it leaves behind a trail of images on disk
- Make it run in isolated folders to avoid file name collision with successive runs
- Wire in .Net Core's DI
- Allow customisable start locations
- Allow customisable colour gradients
- Unit tests

