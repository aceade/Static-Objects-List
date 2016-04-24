What is this?
This is an Editor script for Unity3D. Its purpose is to list all the static objects and Mesh Colliders in a scene, in a text file for examination.

Why would I want to know that?
Marking objects as static is a great way to improve performance in Unity. Marking them as static tells the physics engine that an object will never move, and therefore it only needs to store the position once. Mesh Colliders can also be expensive, but marking them as convex can offset this, as it reduces the number of vertices that the physics engine must keep track of.

Which version of Unity does this require?
I developed this using 5.3.4, but I see no reason why this shouldn't work with an earlier version.

How do I use it?
Copy this into a folder inside your Assets folder (I recommend the following: Assets/Aceade/ListStaticObjects). A menu button will be added under Tools/Aceade/Gather Static Objects; this will create the staticObjects.txt file inside your Assets folder.

What license is this under?
MIT license (see the Licence file)
