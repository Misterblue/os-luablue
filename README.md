# os-luablue
OpenSimulator addon-module to add Lua language scripting to the virtual world.

Don't get your hopes up.

This is an experiment to use [Lua-CSharp] as a script engine in [OpenSimulator].
Remember to re-read the word *experiment*.

There are many barriers to overcome and I may eventually have to fork [Lua-CSharp]
to add [OpenSimulator] required features but that's what experimentation is for.

The initial work will be to follow the pattern of OpenSimulator's YEngine and
solve the problems of managing the script engine threads and figuring out how
to link the "_Api" libraries into the Lua compiler environment.

A larger technical challange will be figuring out how to freeze and serialize
the script state for crossing region boundries and saving scripts in the inventory
but that will be step two.

This is currently packaged as an add-module and not a fork or overlay of the
OpenSimulator sources to keep it in a separate repository and not get entangled
with any updates to [OpenSimulator] or its cousins.
Other packaging or inclusion in the source tree will be possible in the future
and will depend on if this experiment is successful and how things work out.

If you would like to support this project, options are:

- volunteer as a developer (email me at "misterblue@misterblue.com")
- make useful comments in the discussion section
- sponsor this project (I'll get all the sponsorship stuff setup soon)

[Lua-CSharp]: https://github.com/nuskey8/Lua-CSharp
[OpenSimulator]: http://opensimulator.org


