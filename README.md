# Mars-Rover
Mars Rover problem

NASA intends to land robotic rovers on Mars to explore a particularly curious-looking plateau. The rovers must navigate this rectangular plateau in a way so that their on board cameras can get a complete image of the surrounding terrain to send back to Earth.

A simple two-dimensional coordinate grid is mapped to thhe plateau to aid in rover navigation. Each point on the grid is represented by a pair of numbers X Y which correspond to the number of points East or North, respectively, from the origin. The origin of the grid is represented by 0 0 which corresponds to the southwest corner of the plateau. 0 1 is the point directly north of 0 0, 1 1 is the point immmediately east of 0 1, etc. A rover's current position and heading are represented by a triple X Y Z consisting of its current grid position X Y plus a letter Z corresponding to one of the four cardinal commpass points, N E W S. For example, 0 0 N indicated that the rover is in the very southwest corner of the plateau,, facing north.

NASA remotely controls rovers via instructions consisting of strings of letters. Possible instruction letters are L, R, and M. L and R instruct the rover to turn 90 degrees left or right, respectively (without moving from its current spot), while M instructs the rover to move forwardd one grid point along its current heading. 

Your task is write an application that takes test input (instructions from NASA) and provides the expected output (the feedback from the rovers to NASA). Each rover will move in sries, i.e. tthe next rover will not start moving until the one preceding it finishes.

INPUT:
Assumme the southwest corner of the grid is 0,0 (the origin). The first line of input establishes the exploration grid bounds by indicating the coordinates corresponding to the northeastt corner of the plateau.

Next, each rover is given its instructions in turn. Each rover's instructions consists of two lines of strings. The first string confirms the rover's current position and heading. The second string consists of turn / move instructions.

OUTPUT:
Once each rover has received and completely executed its given instructions, it transmits its updated position and heading to NASA.

TEST INPUT
_________________
5 5

1 2 N

LMLMLMLMM

3 3 E

MMRMMRMRRM
_________________
EXPECTED OUTPUT:

1 3 N

5 1 E
_________________
