Hockey Editor
by samhaliburton@gmail.com

A library for editing HockeyQuestionMark Memory.

http://www.hockeyquestionmark.com/
https://www.reddit.com/r/hockeyquestionmark/

Instructions:
Build HockeyEditor .dll
Add to your project

Always call HQMEditor.Init() before using any library calls

You can use the HQMEditor class to edit memory in hockey.exe.
It contains fields like PuckPosition, PuckVelocity, PlayerPosition etc.

For Example, to reset the puck to center ice, call:

HQMEditor.PuckPosition = new HQMVector ( 15.5f, 0.5f, 30.5f );
HQMEditor.PuckVelocity = new HQMVector ( 0f, 0f, 0f );
HQMEditor.PuckRotationalVelocity = new HQMVector ( 0f, 0f, 0f );