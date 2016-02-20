Hockey Editor
by samhaliburton@gmail.com

A library for editing HockeyQuestionMark Memory.

http://www.hockeyquestionmark.com/
https://www.reddit.com/r/hockeyquestionmark/

Instructions:
Build HockeyEditor .dll
Add to your project

Always call MemoryWriter.Init() before using any library calls

You can use the HockeyEditor.Client class to edit memory in hockey.exe.
It contains fields like PuckPosition, PuckVelocity, PlayerPosition etc.

For Example, to reset the puck to center ice, call:

Client.PuckPosition = new float[3] { 15.5f, 0.5f, 30.5f };
Client.PuckVelocity = new float[3] { 0f, 0f, 0f };
Client.PuckRotationalVelocity = new float[3] { 0f, 0f, 0f };

To pass the puck to your stick (pseudocode):

Client.PuckVelocity = (Client.PlayerStickPosition - Client.PuckPosition).normalized * passSpeed;