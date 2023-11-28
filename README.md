# Picswitch
Picswitch is a puzzle mobile game made with Unity!

**Presentation**
- [Game Images](https://drive.google.com/drive/folders/1b1Lj_2X-SzWMK-QqQ0xCdeMqVumYIPGG?usp=share_link)
- [Game Video](https://drive.google.com/drive/folders/1OOzeGnc59JWaHpzgugORXHpvevsRmBDZ?usp=share_link)

**Release**
- You can download a pre-release of the game [HERE](https://github.com/drcipri/Picswitch/releases/tag/v1.0-beta)
> The pre-release works only on **Android** mobile phones and **Android** tablets.

# IMPORTANT NOTE
- You might notice that i don't have to many commits on this project. That is because i did not know git at that time. I was starting to make games to
get used to C# language i was learning.
- I will explain how i made this game, the challenges i faced, and a few important scripts. I won't explain unity features like UnityAds, ScriptableObjects,
UI System, Scene System etc.

## GAME INSTRUCTIONS

**RANKS**
- The game has the following ranks:
1. Smart
2. Genius
3. Davinci
4. Einstein
5. Stark

**DIFFICULTY**
- There are 5 Levels of difficulty:
1. 9 Slides: this is a puzzle with 9 slides and is the easiest to solve.
2. 16 Slides
3. 25 Slides
4. 36 Slides
5. 49 Slides: this is the toughest one , it has 49 slides.
> The complexity of the picture can add to the difficulty of the puzzle.

**GAME SECTIONS**
- The game has two sections: **SOLVED** and **UNSOLVED** puzzles.
   - You can replay anytime SOLVED puzzles.
   - UNSLOVED puzzle can be played only if you have the same rank as the puzzle or Higher.
> To unlock more complex puzzles you need to rank up by solving puzzles.

**CHOOSING THE GAME TYPE**
- You can choose between a game on TIME or a game with MOVES
  - If you choose to play on TIME , you can move the slides as many times as you want, but you have a limited time.
  - If you choose to play with MOVES, you have all the time in the world, but your moves are limited.

**GAMEPLAY**
-When you start the game you will see a messed up picture. Move the slides with your finger until you get it right.
> If you are stuck, in the left you have a button to see the original picture if you have gems.

> You can also choose to watch an AD to get gems if you do not have. Do not worry the ad is not real, its only for development.



### How I made this game
#### Why i decided to go with 9,16,25,36,49 slides?
- 9 slides mean 3 columns and 3 rows and 16 slides means 4 columns and 4 rows, each time i added a new row and column i had to adjust the camera to fit the 
new rows and columns on the screen, so the slides became smaller. After a few tests i decided that 49 would be the limit because going further the slides would have
became to small to be touched by the finger on normal mobiles phones.

#### How i created the matrice?
- to create the matrice i instantiated a **2DSquare** object in a loop for a number of rows and columns given as values.
> you can find the method called *GenerateMatrice()* in a script called ```MatriceManager.cs``` with the path in ```Scripts->Manager->MatriceManager.cs```

#### How each piece of the puzzle know its original place?
- when the table is generated each piece/slide its at the original place and then is shuffled by a method called ***RandomizePuzzle()*** that is declared  inside 
the **MatriceManager.cs**. I have taken advantage of this and i have created a script called ```SquareBehaviour.cs``` that is attached to each square/slide. The script 
store its Vector position at the original location before its shuffled. Then with a *Couroutine* called ***CheckSquareLocation()*** created in *SquareBehaviour.cs* i 
check each time the slide is moved to see if the position of the square/slide it is at the original location.

#### How are the puzzle pieces shuffled?
-this was a big challenge because i had to shuffle the slides and make sure that each slide/piece of the puzzle is not at the original location. 
-To be able to shuffle them i needed to know all the locations, wich i stored when the game started in a script called ```LocationManager.cs```. Then in the 
**MatriceManger.cs** a method called **RandomizePuzzle()** get those stored locations then moves each slide to a new location that is not the original location of
the puzzle piece/slide.

#### How slides swap places? 
- Each slide has attached a script called **SquareBehaviour.cs**, this contains, 3 methods responsible for this, **LockSquare()**, **TargetSquare()** and**MoveSquare**.
*LockSquare()*method will lock the slide that you pressed on, this means you can't lock another slide with another finger. Then **TargetSquare()** method uses a
**RaycastHit2d** object to use a raycast from the location of the square to your finger touch, when the raycast hit another slide , the *MoveSquare()* method enter
in action and swap the places of the slides.
> you can find the script in: ```Scripts->Manager->SquareBehaviour.cs```

#### How progress is calculated?
- I have a script called **LocationManager.cs** that holds a int field called *squaresInPlace*. Each time a Slide is in original location, Or moves from the original
location this variable increases or decreases. Then another script called ```PuzzleProgress.cs``` has a *Coroutine* method called **Progress()**, this method 
calculate the progress based on the number of slides in place. It knows what type the matrice is,(49,25,9 etc) then it divide the total slides of the matrice to the
slides that are in place, then multiply the result by 100 to get the progress.
> you can find this class in: ```Scripts->Manager->PuzzleProgress.cs```


#### How i sliced the images?
-To slice the image i used the ***SpriteEditor*** wich is a tool provided by Unity.Before slicing i had to adjust a few settings, like *pixels per unit* and
*Sprite Mode*.

#### How i added the image to the matrice?
-The 2d square has a SpriteRenderer component. I simply changed the sprite of the component with the sliced pieces.

#### How each image piece fit the size of the matrice piece?
- This was a tricky one, and all chosen images needed to be equal in width and height.Because the images have different resolutions i had to calculate how many 
pixles per unit an image should have. A *normal 2dSquare* has sprite with 256 pixels per unit. Lets say i have an image with 1280/1280 width and height. If i wanted
the image to match a matrice type of 36 squares, i had to divide the the 1280 to 6(6x6=36), wich is aprox. 213 pixels per unit. Then the sliced pieces would match
exactly the square.

#### Did i create tools to help me make this game?
- I have created two tools to help me:
  - First tool is called the ***SliceOrder*** . I needed this tool to reorder the sliced pieces in a list to match exactly the places in the matrice. However later 
  i realised that i could have generated the matrice differently to match the list , this way i would not have to create this tool, but it was a nice experience
  creating it. The tool target a scriptable object called *PuzzleDataSO* , on the scriptable object you will find a button called **OpenPuzzleDataEditor** that will
  open the window with the tool.
  > you can find the script in : ```CustomTools->SliceOrder->Editor->SliceOrder.cs --and-- SliceOrderWindow.cs```
 
  - Second tool is called ***TexturePrepare*** . As i said before i had to adjust each image , and calculate the pixels per unit , and add a few settings, so i made
  this tool that automatically did that for me. I only had to drag the picture into the field. If you have the project in the top bar on `Tools` , you will find this
  tool called TexturePrepare.
  > You can find the script in: ```CustomTools->Slicer->Editor->TexturePrepare.cs```
